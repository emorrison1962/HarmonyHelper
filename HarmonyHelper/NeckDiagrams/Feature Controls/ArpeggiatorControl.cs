using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.MusicXml;


namespace NeckDiagrams.Controls
{
    public partial class ArpeggiatorControl : UserControl
    {
        #region Properties
        ArpeggiatorCreationContext CreationContext { get; set; } = new ArpeggiatorCreationContext();
        Arpeggiator Arpeggiator { get; set; }
        List<ChordFormulaVM> ChordFormulaVMs { get; set; }

        #endregion

        #region Construction
        public ArpeggiatorControl()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.CreationContext.ArpeggiatorCreated += CreationContext_ArpeggiatorCreated;
            this.CreationContext.BeatsPerMeasure = (int)_numericNotesPerMeasure.Value;
            //_errorProviderDirection.SetError(this._rbAscending, "Direction is required.");
            //_errorProviderDirection.SetError(this._rbDescending, "Direction is required.");


            this._noteViewer.Settings.CustomElementPositionRatio = 2;
            this._noteViewer.Settings.IsMusicPaperMode = true;
            this._noteViewer.Scale(new SizeF(2, 2));

        }

        private void CreationContext_ArpeggiatorCreated(object sender, Arpeggiator arpeggiator)
        {
            _noteViewer.DataSource = null;
            var observer = new MusicXmlObservers(arpeggiator);
            arpeggiator.Arpeggiate();
            var part = observer.Part;
            var sw = Stopwatch.StartNew();
            var model = this.CreateModel(part);
            sw.Stop();
            Debug.WriteLine(sw.ElapsedMilliseconds);

            sw = Stopwatch.StartNew();
            var doc = model.ToXDocument();

            Debug.WriteLine(doc.ToString());

            sw.Stop();
            Debug.WriteLine(sw.ElapsedMilliseconds);
            this.PopulateNoteViwer(doc);

            new object();

            //MusicXmlExporterTests.Export($@"c:\temp\{MethodBase.GetCurrentMethod().Name}.xml", model);

            _rtbResults.Text = part.ToXElement().ToString();    
            new object();
        }

        MusicXmlModel CreateModel(Part part)
        {
            var isValid = part.IsValid();
            Debug.Assert(isValid);

            var result = new MusicXmlModel();
            result.Add(part);

            isValid = result.IsValid();
            Debug.Assert(isValid);

            return result;
        }

        #endregion


        #region EventHandlers
        private void _bnChords_Click(object sender, EventArgs e)
        {
            var dlg = new ChordParserDialog();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                this.CreationContext.Formulas = dlg.ChordFormulaVMs;
            }
        }

        private void _cbUntilPatternRepeats_CheckedChanged(object sender, EventArgs e)
        {
            this.CreationContext.UntilPatternRepeats = _cbUntilPatternRepeats.Checked;
        }

        private void _rbAscending_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbAscending.Checked)
                this.CreationContext.Direction |= DirectionEnum.Ascending;
            else
                this.CreationContext.Direction &= DirectionEnum.Ascending;
        }

        private void _rbDescending_CheckedChanged(object sender, EventArgs e)
        {
            if (_rbDescending.Checked)
                this.CreationContext.Direction |= DirectionEnum.Descending;
            else
                this.CreationContext.Direction &= DirectionEnum.Descending;
        }

        private void _cbTemporaryReversal_CheckedChanged(object sender, EventArgs e)
        {
            this.CreationContext.TemporaryReversal = _cbTemporaryReversal.Checked;
        }

        private void _comboNoteRange_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _comboNeckPosition_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void _numericNotesPerMeasure_ValueChanged(object sender, EventArgs e)
        {
            this.CreationContext.BeatsPerMeasure = (int)_numericNotesPerMeasure.Value;
        }

        #endregion

    }//class

    class ArpeggiatorCreationContext
    {
        public event EventHandler<Arpeggiator> ArpeggiatorCreated;
        
        #region Properties
        List<ChordFormulaVM> _Formulas { get; set; } = new List<ChordFormulaVM>();
        public List<ChordFormulaVM> Formulas
        {
            get { return this._Formulas; }
            set
            {
                this._Formulas = value;
                this.TryCreateArpeggiator();
            }
        }
        List<Chord> Chords { get; set; } = new List<Chord> { };
        List<ArpeggiationChordContext> ChordContexts { get; set; } = new List<ArpeggiationChordContext> { };
        public NoteRange NoteRange { get; set; } = new FiveStringBassRange(FiveStringBassPositionEnum.FirstPosition);
        int _BeatsPerMeasure { get; set; }
        public int BeatsPerMeasure 
        {
            get { return this._BeatsPerMeasure; }
            set 
            {
                this._BeatsPerMeasure = value;
                this.TryCreateArpeggiator();
            } 
        }

        DirectionEnum _Direction = DirectionEnum.Ascending | DirectionEnum.AllowTemporayReversalForCloserNote;
        public DirectionEnum Direction 
        {
            get { return this._Direction; }
            set 
            {
                this._Direction = value;
                this.TryCreateArpeggiator();
            } 
        } 
        public bool UntilPatternRepeats { get; set; }
        public bool TemporaryReversal { get; set; }

        #endregion

        public bool IsValid()
        {
            var result = false;

            if (this.Formulas.Any()
                && this.NoteRange.IsValid()
                && this.BeatsPerMeasure > 0
                && this.Direction.HasFlag(DirectionEnum.Ascending) || this.Direction.HasFlag(DirectionEnum.Descending)
                )
            {
                result = true;
            }
            return result;
        }

        void CreateChords()
        {
            if (this.IsValid())
            {
                foreach (var formula in this.Formulas)
                {
                    this.Chords.Add(new Chord(formula.ChordFormula, this.NoteRange));
                }
                foreach (var chord in this.Chords)
                {
                    this.ChordContexts
                        .Add(new ArpeggiationChordContext(chord, BeatsPerMeasure));
                }
            }
        }

        public bool TryCreateArpeggiator()
        {
            Arpeggiator arpeggiator = null;
            var result = this.IsValid();
            if (result)
            {
                this.CreateChords();

                arpeggiator = new Arpeggiator(this.ChordContexts,
                    this.Direction,
                    this.NoteRange,
                    this.BeatsPerMeasure,
                    null,
                    this.UntilPatternRepeats);

                if (arpeggiator is not null)
                    this.OnArpeggiatorCreated(arpeggiator);
            }

            return result;
        }

        public void OnArpeggiatorCreated(Arpeggiator arpeggiator)
        {
            this.ArpeggiatorCreated?.Invoke(this, arpeggiator);
        }

    }//class

    public class MusicXmlObservers
    {
        const string FLAT = "♭";
        const string SHARP = "♯";

        public Part Part { get; set; }
        public MusicXmlObservers(Arpeggiator arpeggiator)
        {
            this.Part = new Part(PartTypeEnum.Harmony,
                new PartIdentifier("P1", "Bass"), ClefEnum.Bass);

            this.RegisterMusicXmlObservers(arpeggiator);
        }
        void RegisterMusicXmlObservers(Arpeggiator arpeggiator)
        {
            arpeggiator.Starting += this.Arpeggiator_Starting;
            //arpeggiator.MeasureChanging += Arpeggiator_MeasureChanging;
            arpeggiator.MeasureChanged += this.Arpeggiator_MeasureChanged;
            //arpeggiator.ChordChanging += Arpeggiator_ChordChanging;
            arpeggiator.ChordChanged += this.Arpeggiator_ChordChanged;
            //arpeggiator.NoteChanging += this.Arpeggiator_CurrentNoteChanging;
            arpeggiator.NoteChanged += this.Arpeggiator_CurrentNoteChanged;
            arpeggiator.Ending += this.Arpeggiator_Ending;
        }

        RhythmicContext Rhythm = new RhythmicContext(new Eric.Morrison.Harmony.Rhythm.TimeSignature(4, 4), 480).SetTempo(100);

        private void Arpeggiator_Starting(object? sender, Arpeggiator args)
        {
            Debug.WriteLine("Arpeggiator_Starting");
            new object();
        }
        private void Arpeggiator_MeasureChanging(object? sender, Arpeggiator args)
        {
            //Debug.WriteLine("Arpeggiator_MeasureChanging");
            new object();
            //this.CreateMeasure(ctx);
        }
        private void Arpeggiator_MeasureChanged(object? sender, Arpeggiator args)
        {
            Debug.WriteLine($"\tArpeggiator_MeasureChanged: {args.CurrentMeasure}");
            this.CreateMeasure(args);
            new object();
        }
        private void CreateMeasure(Arpeggiator args)
        {
            if (args.CurrentMeasure > 0)
            {
                var measureNumber = args.CurrentMeasure;
                var measure = new Measure(this.Part, measureNumber);
                if (args.CurrentMeasure == 1)
                    measure.Add(new BarlineContext(BarlineStyleEnum.Light_Light, BarlineSideEnum.Left));
                this.Part.Add(measure);
            }
            new object();

        }

        private void Arpeggiator_ChordChanging(object? sender, Arpeggiator.ChordChangingEventArgs args)
        {
            //Debug.WriteLine("Arpeggiator_ChordChanging");
            new object();
        }

        private void Arpeggiator_ChordChanged(object? sender, Arpeggiator args)
        {
            Debug.WriteLine($"\t\tArpeggiator_ChordChanged: {args.CurrentChord}");
            this.CreateHarmony(args);
            new object();
        }

        private void CreateHarmony(Arpeggiator args)
        {
            var cctx = new TimeContextEx.CreationContext(this.Rhythm);
            cctx.Duration = Eric.Morrison.Harmony.MusicXml.DurationEnum.Duration_Quarter;
            cctx.MeasureNumber = args.CurrentMeasure;
            cctx.RelativeStart = 0;
            cctx.RelativeEnd = 1;
            var tctx = new TimeContextEx(cctx);

            var tecf = new TimedEventChordFormula(args.CurrentChord.Formula, tctx);
            this.Part.CurrentMeasure.Add(tecf);
        }

        private void Arpeggiator_CurrentNoteChanging(object sender, Arpeggiator.NoteChangingEventArgs args)
        {
            Debug.WriteLine("Arpeggiator_CurrentNoteChanging");
            new object();
        }
        private void Arpeggiator_CurrentNoteChanged(object? sender, Arpeggiator args)
        {
            Debug.WriteLine($"\t\t\tArpeggiator_CurrentNoteChanged: {args.CurrentNote}");
            this.CreateNote(args);
            new object();
        }

        private void CreateNote(Arpeggiator args)
        {
            var cctx = new TimeContextEx.CreationContext(this.Rhythm);
            cctx.Duration = DurationEnum.Duration_Quarter;
            cctx.MeasureNumber = args.CurrentMeasure;
            cctx.RelativeStart = 0;
            cctx.RelativeEnd = 1;
            var tctx = new TimeContextEx(cctx);
            var tecf = new TimedEventNote(args.CurrentNote, tctx);
            this.Part.CurrentMeasure.Add(tecf);
        }

        private void Arpeggiator_Ending(object? sender, Arpeggiator args)
        {
            //throw new NotImplementedException();
            //XmlCtx.Document.Save(@"c:\temp\_xml.xml");
            new object();
        }
    }//class

}//ns
