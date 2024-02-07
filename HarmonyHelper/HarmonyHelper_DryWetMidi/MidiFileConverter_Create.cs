using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Eric.Morrison.Harmony.MusicXml;

using Melanchall.DryWetMidi.Common;
using Melanchall.DryWetMidi.Core;
using Melanchall.DryWetMidi.Interaction;
using Melanchall.DryWetMidi.Multimedia;
using Melanchall.DryWetMidi.MusicTheory;

using Core = Melanchall.DryWetMidi.Core;

namespace HarmonyHelper_DryWetMidi
{
    public partial class MidiFileConverter
    {
        public MidiFileConverter()
        {
        }

        public const int PPQN = 960;
        public void Create(MusicXmlModel model, string filename)
        {
            var midiFile = new Core.MidiFile();
            midiFile.TimeDivision = new TicksPerQuarterNoteTimeDivision(PPQN);
            var tempoMap = midiFile.GetTempoMap();
            var trackChunk = new Core.TrackChunk();
            midiFile.Chunks.Add(trackChunk);

            var ppm = int.MinValue;
            using (var tempoMapManager = midiFile.ManageTempoMap())
            {
                var ts = new TimeSignature(model.Rhythm.TimeSignature.BeatCount,
                    model.Rhythm.TimeSignature.BeatUnit);
                tempoMapManager.SetTimeSignature(0, ts);

                ppm = this.GetPulsesPerMeasure(ts);
            }

            using (var chordsManager = trackChunk.ManageChords())
            {
                var part = model.Parts.FirstOrDefault();
                var nBar = 0;
                if (part != null)
                {
                    foreach (var section in part.Sections)
                    {
                        foreach (var measure in section.Measures)
                        {
                            foreach (var tecf in measure.Chords)
                            {
                                var formula = tecf.Event;
                                var dstChord = formula.ToDWMChord();
                                dstChord.Channel = (FourBitNumber)1;

                                dstChord.Time = nBar * ppm;
                                var length = LengthConverter.ConvertFrom(
                                    new MidiTimeSpan(ppm),
                                    new BarBeatFractionTimeSpan(++nBar),
                                    tempoMap);
                                dstChord.Length = length;
                                chordsManager.Objects.Add(dstChord);
                                chordsManager.SaveChanges();
                            }
                        }
                    }
                }
            }

            using (var notesManager = trackChunk.ManageNotes())
            {
                var part = model.Parts.FirstOrDefault();
                var nBar = 0;
                if (part != null)
                {
                    foreach (var section in part.Sections)
                    {
                        foreach (var measure in section.Measures)
                        {
                            foreach (var ten in measure.Notes)
                            {
                                var note = ten.Event;
                                var dst = note.ToDWMNote();
                                dst.Channel = (FourBitNumber)1;

                                dst.Time = (nBar * ppm) / 4;
                                var length = LengthConverter.ConvertFrom(
                                    new MidiTimeSpan(ppm),
                                    new BarBeatFractionTimeSpan(++nBar),
                                    tempoMap);
                                dst.Length = length / 4;
                                notesManager.Objects.Add(dst);
                                notesManager.SaveChanges();
                            }
                        }
                    }
                }
            }

            if (File.Exists(filename))
                File.Delete(filename);
            midiFile.Write(filename);

            using (var notesManager = trackChunk.ManageNotes())
            {
                var count = notesManager.Objects.Count;
            }
            using (var chordsManager = trackChunk.ManageChords())
            {
                var count = chordsManager.Objects.Count;
            }

            var devices = OutputDevice.GetAll().ToList();
            //This actually plays the MIDI file!
            //Task.Run(()=> midiFile.Play(OutputDevice.GetAll().First())).Wait();
            new object();
        }

        int GetPulsesPerMeasure(TimeSignature ts)
        {
            var result = int.MinValue;

            var arr = new[] { ts.Numerator, ts.Denominator };
            this.Simplify(arr);
            var numerator = arr[0];
            var denominator = arr[1];

            switch (denominator)
            {
                case 1:
                    {
                        var ppwn = MidiFileConverter.PPQN * 4;
                        result = numerator * ppwn;
                        break;
                    }
                case 2:
                    {
                        var pphn = MidiFileConverter.PPQN * 2;
                        result = numerator * pphn;
                        break;
                    }
                case 4:
                    {
                        var ppqn = MidiFileConverter.PPQN;
                        result = numerator * ppqn;
                        break;
                    }
                case 8:
                    {
                        var ppen = MidiFileConverter.PPQN / 2;
                        result = numerator * ppen;
                        break;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException();
                        break;
                    }
            }

            return result;
        }
        void Simplify(int[] numbers)
        {
            int gcd = GCD(numbers);
            for (int i = 0; i < numbers.Length; i++)
                numbers[i] /= gcd;
        }
        int GCD(int a, int b)
        {
            while (b > 0)
            {
                int rem = a % b;
                a = b;
                b = rem;
            }
            return a;
        }
        int GCD(int[] args)
        {
            // using LINQ:
            return args.Aggregate((gcd, arg) => GCD(gcd, arg));
        }



        public void Open(string filename)
        {
            if (!File.Exists(this.Filename))
                throw new FileNotFoundException(this.Filename);

            var midiFile = Core.MidiFile.Read(filename);
            this.Init();

            //This actually plays the MIDI file!
            midiFile.Play(OutputDevice.GetAll().First());
        }



        void foo()
        {
            var midiFile = new Core.MidiFile();
            var tempoMap = midiFile.GetTempoMap();
            var trackChunk = new Core.TrackChunk();
            using (var chordsManager = trackChunk.ManageChords())
            using (var notesManager = trackChunk.ManageNotes())
            {
                var length = LengthConverter.ConvertFrom(
                    2 * MusicalTimeSpan.Eighth.Triplet(),
                    0,
                    tempoMap);
                var note = new Melanchall.DryWetMidi.Interaction.Note(NoteName.A, 4, length);
                notesManager.Objects.Add(note);
            }

            midiFile.Chunks.Add(trackChunk);
            midiFile.Write("Single note great song.mid");
        }

    }//class
}//ns
