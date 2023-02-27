using Eric.Morrison.Harmony.Intervals;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony.Chords
{
    public partial class ChordFormula
    {
        #region static Chords

        static public readonly ChordFormula BSharpaug;
        static public readonly ChordFormula BSharpdim;
        static public readonly ChordFormula BSharpm7b5;
        static public readonly ChordFormula BSharpdim7;
        static public readonly ChordFormula BSharpSus2;
        static public readonly ChordFormula BSharp7Sus2;
        static public readonly ChordFormula BSharpSus4;
        static public readonly ChordFormula BSharp7Sus4;
        static public readonly ChordFormula BSharpSus2Sus4;
        static public readonly ChordFormula BSharpm;
        static public readonly ChordFormula BSharpm7;
        static public readonly ChordFormula BSharpmM7;
        static public readonly ChordFormula BSharpmMaj7aug5;
        static public readonly ChordFormula BSharpm6;
        static public readonly ChordFormula BSharpm9;
        static public readonly ChordFormula BSharpm11;
        static public readonly ChordFormula BSharpm13;
        static public readonly ChordFormula BSharpmAdd9;
        static public readonly ChordFormula BSharpMaj;
        static public readonly ChordFormula BSharp6;
        static public readonly ChordFormula BSharpMaj7;
        static public readonly ChordFormula BSharpMaj9;
        static public readonly ChordFormula BSharpMaj11;
        static public readonly ChordFormula BSharpMaj13;
        static public readonly ChordFormula BSharpAdd9;
        static public readonly ChordFormula BSharpMajMu;
        static public readonly ChordFormula BSharpMaj7b5;
        static public readonly ChordFormula BSharpMaj7aug5;
        static public readonly ChordFormula BSharp7;
        static public readonly ChordFormula BSharp9;
        static public readonly ChordFormula BSharp11;
        static public readonly ChordFormula BSharp13;
        static public readonly ChordFormula BSharp7b5;
        static public readonly ChordFormula BSharp7b9;
        static public readonly ChordFormula Caug;
        static public readonly ChordFormula Cdim;
        static public readonly ChordFormula Cm7b5;
        static public readonly ChordFormula Cdim7;
        static public readonly ChordFormula CSus2;
        static public readonly ChordFormula C7Sus2;
        static public readonly ChordFormula CSus4;
        static public readonly ChordFormula C7Sus4;
        static public readonly ChordFormula CSus2Sus4;
        static public readonly ChordFormula Cm;
        static public readonly ChordFormula Cm7;
        static public readonly ChordFormula CmM7;
        static public readonly ChordFormula CmMaj7aug5;
        static public readonly ChordFormula Cm6;
        static public readonly ChordFormula Cm9;
        static public readonly ChordFormula Cm11;
        static public readonly ChordFormula Cm13;
        static public readonly ChordFormula CmAdd9;
        static public readonly ChordFormula CMaj;
        static public readonly ChordFormula C6;
        static public readonly ChordFormula CMaj7;
        static public readonly ChordFormula CMaj9;
        static public readonly ChordFormula CMaj11;
        static public readonly ChordFormula CMaj13;
        static public readonly ChordFormula CAdd9;
        static public readonly ChordFormula CMajMu;
        static public readonly ChordFormula CMaj7b5;
        static public readonly ChordFormula CMaj7aug5;
        static public readonly ChordFormula C7;
        static public readonly ChordFormula C9;
        static public readonly ChordFormula C11;
        static public readonly ChordFormula C13;
        static public readonly ChordFormula C7b5;
        static public readonly ChordFormula C7b9;
        static public readonly ChordFormula C7sharp9;
        static public readonly ChordFormula CSharpaug;
        static public readonly ChordFormula CSharpdim;
        static public readonly ChordFormula CSharpm7b5;
        static public readonly ChordFormula CSharpdim7;
        static public readonly ChordFormula CSharpSus2;
        static public readonly ChordFormula CSharp7Sus2;
        static public readonly ChordFormula CSharpSus4;
        static public readonly ChordFormula CSharp7Sus4;
        static public readonly ChordFormula CSharpSus2Sus4;
        static public readonly ChordFormula CSharpm;
        static public readonly ChordFormula CSharpm7;
        static public readonly ChordFormula CSharpmM7;
        static public readonly ChordFormula CSharpmMaj7aug5;
        static public readonly ChordFormula CSharpm6;
        static public readonly ChordFormula CSharpm9;
        static public readonly ChordFormula CSharpm11;
        static public readonly ChordFormula CSharpm13;
        static public readonly ChordFormula CSharpmAdd9;
        static public readonly ChordFormula CSharpMaj;
        static public readonly ChordFormula CSharp6;
        static public readonly ChordFormula CSharpMaj7;
        static public readonly ChordFormula CSharpMaj9;
        static public readonly ChordFormula CSharpMaj11;
        static public readonly ChordFormula CSharpMaj13;
        static public readonly ChordFormula CSharpAdd9;
        static public readonly ChordFormula CSharpMajMu;
        static public readonly ChordFormula CSharpMaj7b5;
        static public readonly ChordFormula CSharpMaj7aug5;
        static public readonly ChordFormula CSharp7;
        static public readonly ChordFormula CSharp9;
        static public readonly ChordFormula CSharp11;
        static public readonly ChordFormula CSharp13;
        static public readonly ChordFormula CSharp7b5;
        static public readonly ChordFormula CSharp7b9;
        static public readonly ChordFormula CSharp7sharp9;
        static public readonly ChordFormula Dbaug;
        static public readonly ChordFormula Dbdim;
        static public readonly ChordFormula Dbm7b5;
        static public readonly ChordFormula Dbdim7;
        static public readonly ChordFormula DbSus2;
        static public readonly ChordFormula Db7Sus2;
        static public readonly ChordFormula DbSus4;
        static public readonly ChordFormula Db7Sus4;
        static public readonly ChordFormula DbSus2Sus4;
        static public readonly ChordFormula Dbm;
        static public readonly ChordFormula Dbm7;
        static public readonly ChordFormula DbmM7;
        static public readonly ChordFormula DbmMaj7aug5;
        static public readonly ChordFormula Dbm6;
        static public readonly ChordFormula Dbm9;
        static public readonly ChordFormula Dbm11;
        static public readonly ChordFormula Dbm13;
        static public readonly ChordFormula DbmAdd9;
        static public readonly ChordFormula DbMaj;
        static public readonly ChordFormula Db6;
        static public readonly ChordFormula DbMaj7;
        static public readonly ChordFormula DbMaj9;
        static public readonly ChordFormula DbMaj11;
        static public readonly ChordFormula DbMaj13;
        static public readonly ChordFormula DbAdd9;
        static public readonly ChordFormula DbMajMu;
        static public readonly ChordFormula DbMaj7b5;
        static public readonly ChordFormula DbMaj7aug5;
        static public readonly ChordFormula Db7;
        static public readonly ChordFormula Db9;
        static public readonly ChordFormula Db11;
        static public readonly ChordFormula Db13;
        static public readonly ChordFormula Db7b5;
        static public readonly ChordFormula Db7b9;
        static public readonly ChordFormula Db7sharp9;
        static public readonly ChordFormula Daug;
        static public readonly ChordFormula Ddim;
        static public readonly ChordFormula Dm7b5;
        static public readonly ChordFormula Ddim7;
        static public readonly ChordFormula DSus2;
        static public readonly ChordFormula D7Sus2;
        static public readonly ChordFormula DSus4;
        static public readonly ChordFormula D7Sus4;
        static public readonly ChordFormula DSus2Sus4;
        static public readonly ChordFormula Dm;
        static public readonly ChordFormula Dm7;
        static public readonly ChordFormula DmM7;
        static public readonly ChordFormula DmMaj7aug5;
        static public readonly ChordFormula Dm6;
        static public readonly ChordFormula Dm9;
        static public readonly ChordFormula Dm11;
        static public readonly ChordFormula Dm13;
        static public readonly ChordFormula DmAdd9;
        static public readonly ChordFormula DMaj;
        static public readonly ChordFormula D6;
        static public readonly ChordFormula DMaj7;
        static public readonly ChordFormula DMaj9;
        static public readonly ChordFormula DMaj11;
        static public readonly ChordFormula DMaj13;
        static public readonly ChordFormula DAdd9;
        static public readonly ChordFormula DMajMu;
        static public readonly ChordFormula DMaj7b5;
        static public readonly ChordFormula DMaj7aug5;
        static public readonly ChordFormula D7;
        static public readonly ChordFormula D9;
        static public readonly ChordFormula D11;
        static public readonly ChordFormula D13;
        static public readonly ChordFormula D7b5;
        static public readonly ChordFormula D7b9;
        static public readonly ChordFormula D7sharp9;
        static public readonly ChordFormula DSharpaug;
        static public readonly ChordFormula DSharpdim;
        static public readonly ChordFormula DSharpm7b5;
        static public readonly ChordFormula DSharpdim7;
        static public readonly ChordFormula DSharpSus2;
        static public readonly ChordFormula DSharp7Sus2;
        static public readonly ChordFormula DSharpSus4;
        static public readonly ChordFormula DSharp7Sus4;
        static public readonly ChordFormula DSharpSus2Sus4;
        static public readonly ChordFormula DSharpm;
        static public readonly ChordFormula DSharpm7;
        static public readonly ChordFormula DSharpmM7;
        static public readonly ChordFormula DSharpmMaj7aug5;
        static public readonly ChordFormula DSharpm6;
        static public readonly ChordFormula DSharpm9;
        static public readonly ChordFormula DSharpm11;
        static public readonly ChordFormula DSharpm13;
        static public readonly ChordFormula DSharpmAdd9;
        static public readonly ChordFormula DSharpMaj;
        static public readonly ChordFormula DSharp6;
        static public readonly ChordFormula DSharpMaj7;
        static public readonly ChordFormula DSharpMaj9;
        static public readonly ChordFormula DSharpMaj11;
        static public readonly ChordFormula DSharpMaj13;
        static public readonly ChordFormula DSharpAdd9;
        static public readonly ChordFormula DSharpMajMu;
        static public readonly ChordFormula DSharpMaj7b5;
        static public readonly ChordFormula DSharpMaj7aug5;
        static public readonly ChordFormula DSharp7;
        static public readonly ChordFormula DSharp9;
        static public readonly ChordFormula DSharp11;
        static public readonly ChordFormula DSharp13;
        static public readonly ChordFormula DSharp7b5;
        static public readonly ChordFormula DSharp7b9;
        static public readonly ChordFormula DSharp7sharp9;
        static public readonly ChordFormula Ebaug;
        static public readonly ChordFormula Ebdim;
        static public readonly ChordFormula Ebm7b5;
        static public readonly ChordFormula Ebdim7;
        static public readonly ChordFormula EbSus2;
        static public readonly ChordFormula Eb7Sus2;
        static public readonly ChordFormula EbSus4;
        static public readonly ChordFormula Eb7Sus4;
        static public readonly ChordFormula EbSus2Sus4;
        static public readonly ChordFormula Ebm;
        static public readonly ChordFormula Ebm7;
        static public readonly ChordFormula EbmM7;
        static public readonly ChordFormula EbmMaj7aug5;
        static public readonly ChordFormula Ebm6;
        static public readonly ChordFormula Ebm9;
        static public readonly ChordFormula Ebm11;
        static public readonly ChordFormula Ebm13;
        static public readonly ChordFormula EbmAdd9;
        static public readonly ChordFormula EbMaj;
        static public readonly ChordFormula Eb6;
        static public readonly ChordFormula EbMaj7;
        static public readonly ChordFormula EbMaj9;
        static public readonly ChordFormula EbMaj11;
        static public readonly ChordFormula EbMaj13;
        static public readonly ChordFormula EbAdd9;
        static public readonly ChordFormula EbMajMu;
        static public readonly ChordFormula EbMaj7b5;
        static public readonly ChordFormula EbMaj7aug5;
        static public readonly ChordFormula Eb7;
        static public readonly ChordFormula Eb9;
        static public readonly ChordFormula Eb11;
        static public readonly ChordFormula Eb13;
        static public readonly ChordFormula Eb7b5;
        static public readonly ChordFormula Eb7b9;
        static public readonly ChordFormula Eb7sharp9;
        static public readonly ChordFormula Eaug;
        static public readonly ChordFormula Edim;
        static public readonly ChordFormula Em7b5;
        static public readonly ChordFormula Edim7;
        static public readonly ChordFormula ESus2;
        static public readonly ChordFormula E7Sus2;
        static public readonly ChordFormula ESus4;
        static public readonly ChordFormula E7Sus4;
        static public readonly ChordFormula ESus2Sus4;
        static public readonly ChordFormula Em;
        static public readonly ChordFormula Em7;
        static public readonly ChordFormula EmM7;
        static public readonly ChordFormula EmMaj7aug5;
        static public readonly ChordFormula Em6;
        static public readonly ChordFormula Em9;
        static public readonly ChordFormula Em11;
        static public readonly ChordFormula Em13;
        static public readonly ChordFormula EmAdd9;
        static public readonly ChordFormula EMaj;
        static public readonly ChordFormula E6;
        static public readonly ChordFormula EMaj7;
        static public readonly ChordFormula EMaj9;
        static public readonly ChordFormula EMaj11;
        static public readonly ChordFormula EMaj13;
        static public readonly ChordFormula EAdd9;
        static public readonly ChordFormula EMajMu;
        static public readonly ChordFormula EMaj7b5;
        static public readonly ChordFormula EMaj7aug5;
        static public readonly ChordFormula E7;
        static public readonly ChordFormula E9;
        static public readonly ChordFormula E11;
        static public readonly ChordFormula E13;
        static public readonly ChordFormula E7b5;
        static public readonly ChordFormula E7b9;
        static public readonly ChordFormula E7sharp9;
        static public readonly ChordFormula Fbaug;
        static public readonly ChordFormula Fbdim;
        static public readonly ChordFormula Fbm7b5;
        static public readonly ChordFormula Fbdim7;
        static public readonly ChordFormula FbSus2;
        static public readonly ChordFormula Fb7Sus2;
        static public readonly ChordFormula FbSus4;
        static public readonly ChordFormula Fb7Sus4;
        static public readonly ChordFormula FbSus2Sus4;
        static public readonly ChordFormula Fbm;
        static public readonly ChordFormula Fbm7;
        static public readonly ChordFormula FbmM7;
        static public readonly ChordFormula FbmMaj7aug5;
        static public readonly ChordFormula Fbm6;
        static public readonly ChordFormula Fbm9;
        static public readonly ChordFormula Fbm11;
        static public readonly ChordFormula Fbm13;
        static public readonly ChordFormula FbmAdd9;
        static public readonly ChordFormula FbMaj;
        static public readonly ChordFormula Fb6;
        static public readonly ChordFormula FbMaj7;
        static public readonly ChordFormula FbMaj9;
        static public readonly ChordFormula FbMaj11;
        static public readonly ChordFormula FbMaj13;
        static public readonly ChordFormula FbAdd9;
        static public readonly ChordFormula FbMajMu;
        static public readonly ChordFormula FbMaj7b5;
        static public readonly ChordFormula FbMaj7aug5;
        static public readonly ChordFormula Fb7;
        static public readonly ChordFormula Fb9;
        static public readonly ChordFormula Fb11;
        static public readonly ChordFormula Fb13;
        static public readonly ChordFormula Fb7b5;
        static public readonly ChordFormula Fb7b9;
        static public readonly ChordFormula Fb7sharp9;
        static public readonly ChordFormula ESharpaug;
        static public readonly ChordFormula ESharpdim;
        static public readonly ChordFormula ESharpm7b5;
        static public readonly ChordFormula ESharpdim7;
        static public readonly ChordFormula ESharpSus2;
        static public readonly ChordFormula ESharp7Sus2;
        static public readonly ChordFormula ESharpSus4;
        static public readonly ChordFormula ESharp7Sus4;
        static public readonly ChordFormula ESharpSus2Sus4;
        static public readonly ChordFormula ESharpm;
        static public readonly ChordFormula ESharpm7;
        static public readonly ChordFormula ESharpmM7;
        static public readonly ChordFormula ESharpmMaj7aug5;
        static public readonly ChordFormula ESharpm6;
        static public readonly ChordFormula ESharpm9;
        static public readonly ChordFormula ESharpm11;
        static public readonly ChordFormula ESharpm13;
        static public readonly ChordFormula ESharpmAdd9;
        static public readonly ChordFormula ESharpMaj;
        static public readonly ChordFormula ESharp6;
        static public readonly ChordFormula ESharpMaj7;
        static public readonly ChordFormula ESharpMaj9;
        static public readonly ChordFormula ESharpMaj11;
        static public readonly ChordFormula ESharpMaj13;
        static public readonly ChordFormula ESharpAdd9;
        static public readonly ChordFormula ESharpMajMu;
        static public readonly ChordFormula ESharpMaj7b5;
        static public readonly ChordFormula ESharpMaj7aug5;
        static public readonly ChordFormula ESharp7;
        static public readonly ChordFormula ESharp9;
        static public readonly ChordFormula ESharp11;
        static public readonly ChordFormula ESharp13;
        static public readonly ChordFormula ESharp7b5;
        static public readonly ChordFormula ESharp7b9;
        static public readonly ChordFormula Faug;
        static public readonly ChordFormula Fdim;
        static public readonly ChordFormula Fm7b5;
        static public readonly ChordFormula Fdim7;
        static public readonly ChordFormula FSus2;
        static public readonly ChordFormula F7Sus2;
        static public readonly ChordFormula FSus4;
        static public readonly ChordFormula F7Sus4;
        static public readonly ChordFormula FSus2Sus4;
        static public readonly ChordFormula Fm;
        static public readonly ChordFormula Fm7;
        static public readonly ChordFormula FmM7;
        static public readonly ChordFormula FmMaj7aug5;
        static public readonly ChordFormula Fm6;
        static public readonly ChordFormula Fm9;
        static public readonly ChordFormula Fm11;
        static public readonly ChordFormula Fm13;
        static public readonly ChordFormula FmAdd9;
        static public readonly ChordFormula FMaj;
        static public readonly ChordFormula F6;
        static public readonly ChordFormula FMaj7;
        static public readonly ChordFormula FMaj9;
        static public readonly ChordFormula FMaj11;
        static public readonly ChordFormula FMaj13;
        static public readonly ChordFormula FAdd9;
        static public readonly ChordFormula FMajMu;
        static public readonly ChordFormula FMaj7b5;
        static public readonly ChordFormula FMaj7aug5;
        static public readonly ChordFormula F7;
        static public readonly ChordFormula F9;
        static public readonly ChordFormula F11;
        static public readonly ChordFormula F13;
        static public readonly ChordFormula F7b5;
        static public readonly ChordFormula F7b9;
        static public readonly ChordFormula F7sharp9;
        static public readonly ChordFormula FSharpaug;
        static public readonly ChordFormula FSharpdim;
        static public readonly ChordFormula FSharpm7b5;
        static public readonly ChordFormula FSharpdim7;
        static public readonly ChordFormula FSharpSus2;
        static public readonly ChordFormula FSharp7Sus2;
        static public readonly ChordFormula FSharpSus4;
        static public readonly ChordFormula FSharp7Sus4;
        static public readonly ChordFormula FSharpSus2Sus4;
        static public readonly ChordFormula FSharpm;
        static public readonly ChordFormula FSharpm7;
        static public readonly ChordFormula FSharpmM7;
        static public readonly ChordFormula FSharpmMaj7aug5;
        static public readonly ChordFormula FSharpm6;
        static public readonly ChordFormula FSharpm9;
        static public readonly ChordFormula FSharpm11;
        static public readonly ChordFormula FSharpm13;
        static public readonly ChordFormula FSharpmAdd9;
        static public readonly ChordFormula FSharpMaj;
        static public readonly ChordFormula FSharp6;
        static public readonly ChordFormula FSharpMaj7;
        static public readonly ChordFormula FSharpMaj9;
        static public readonly ChordFormula FSharpMaj11;
        static public readonly ChordFormula FSharpMaj13;
        static public readonly ChordFormula FSharpAdd9;
        static public readonly ChordFormula FSharpMajMu;
        static public readonly ChordFormula FSharpMaj7b5;
        static public readonly ChordFormula FSharpMaj7aug5;
        static public readonly ChordFormula FSharp7;
        static public readonly ChordFormula FSharp9;
        static public readonly ChordFormula FSharp11;
        static public readonly ChordFormula FSharp13;
        static public readonly ChordFormula FSharp7b5;
        static public readonly ChordFormula FSharp7b9;
        static public readonly ChordFormula FSharp7sharp9;
        static public readonly ChordFormula Gbaug;
        static public readonly ChordFormula Gbdim;
        static public readonly ChordFormula Gbm7b5;
        static public readonly ChordFormula Gbdim7;
        static public readonly ChordFormula GbSus2;
        static public readonly ChordFormula Gb7Sus2;
        static public readonly ChordFormula GbSus4;
        static public readonly ChordFormula Gb7Sus4;
        static public readonly ChordFormula GbSus2Sus4;
        static public readonly ChordFormula Gbm;
        static public readonly ChordFormula Gbm7;
        static public readonly ChordFormula GbmM7;
        static public readonly ChordFormula GbmMaj7aug5;
        static public readonly ChordFormula Gbm6;
        static public readonly ChordFormula Gbm9;
        static public readonly ChordFormula Gbm11;
        static public readonly ChordFormula Gbm13;
        static public readonly ChordFormula GbmAdd9;
        static public readonly ChordFormula GbMaj;
        static public readonly ChordFormula Gb6;
        static public readonly ChordFormula GbMaj7;
        static public readonly ChordFormula GbMaj9;
        static public readonly ChordFormula GbMaj11;
        static public readonly ChordFormula GbMaj13;
        static public readonly ChordFormula GbAdd9;
        static public readonly ChordFormula GbMajMu;
        static public readonly ChordFormula GbMaj7b5;
        static public readonly ChordFormula GbMaj7aug5;
        static public readonly ChordFormula Gb7;
        static public readonly ChordFormula Gb9;
        static public readonly ChordFormula Gb11;
        static public readonly ChordFormula Gb13;
        static public readonly ChordFormula Gb7b5;
        static public readonly ChordFormula Gb7b9;
        static public readonly ChordFormula Gb7sharp9;
        static public readonly ChordFormula Gaug;
        static public readonly ChordFormula Gdim;
        static public readonly ChordFormula Gm7b5;
        static public readonly ChordFormula Gdim7;
        static public readonly ChordFormula GSus2;
        static public readonly ChordFormula G7Sus2;
        static public readonly ChordFormula GSus4;
        static public readonly ChordFormula G7Sus4;
        static public readonly ChordFormula GSus2Sus4;
        static public readonly ChordFormula Gm;
        static public readonly ChordFormula Gm7;
        static public readonly ChordFormula GmM7;
        static public readonly ChordFormula GmMaj7aug5;
        static public readonly ChordFormula Gm6;
        static public readonly ChordFormula Gm9;
        static public readonly ChordFormula Gm11;
        static public readonly ChordFormula Gm13;
        static public readonly ChordFormula GmAdd9;
        static public readonly ChordFormula GMaj;
        static public readonly ChordFormula G6;
        static public readonly ChordFormula GMaj7;
        static public readonly ChordFormula GMaj9;
        static public readonly ChordFormula GMaj11;
        static public readonly ChordFormula GMaj13;
        static public readonly ChordFormula GAdd9;
        static public readonly ChordFormula GMajMu;
        static public readonly ChordFormula GMaj7b5;
        static public readonly ChordFormula GMaj7aug5;
        static public readonly ChordFormula G7;
        static public readonly ChordFormula G9;
        static public readonly ChordFormula G11;
        static public readonly ChordFormula G13;
        static public readonly ChordFormula G7b5;
        static public readonly ChordFormula G7b9;
        static public readonly ChordFormula G7sharp9;
        static public readonly ChordFormula GSharpaug;
        static public readonly ChordFormula GSharpdim;
        static public readonly ChordFormula GSharpm7b5;
        static public readonly ChordFormula GSharpdim7;
        static public readonly ChordFormula GSharpSus2;
        static public readonly ChordFormula GSharp7Sus2;
        static public readonly ChordFormula GSharpSus4;
        static public readonly ChordFormula GSharp7Sus4;
        static public readonly ChordFormula GSharpSus2Sus4;
        static public readonly ChordFormula GSharpm;
        static public readonly ChordFormula GSharpm7;
        static public readonly ChordFormula GSharpmM7;
        static public readonly ChordFormula GSharpmMaj7aug5;
        static public readonly ChordFormula GSharpm6;
        static public readonly ChordFormula GSharpm9;
        static public readonly ChordFormula GSharpm11;
        static public readonly ChordFormula GSharpm13;
        static public readonly ChordFormula GSharpmAdd9;
        static public readonly ChordFormula GSharpMaj;
        static public readonly ChordFormula GSharp6;
        static public readonly ChordFormula GSharpMaj7;
        static public readonly ChordFormula GSharpMaj9;
        static public readonly ChordFormula GSharpMaj11;
        static public readonly ChordFormula GSharpMaj13;
        static public readonly ChordFormula GSharpAdd9;
        static public readonly ChordFormula GSharpMajMu;
        static public readonly ChordFormula GSharpMaj7b5;
        static public readonly ChordFormula GSharpMaj7aug5;
        static public readonly ChordFormula GSharp7;
        static public readonly ChordFormula GSharp9;
        static public readonly ChordFormula GSharp11;
        static public readonly ChordFormula GSharp13;
        static public readonly ChordFormula GSharp7b5;
        static public readonly ChordFormula GSharp7b9;
        static public readonly ChordFormula GSharp7sharp9;
        static public readonly ChordFormula Abaug;
        static public readonly ChordFormula Abdim;
        static public readonly ChordFormula Abm7b5;
        static public readonly ChordFormula Abdim7;
        static public readonly ChordFormula AbSus2;
        static public readonly ChordFormula Ab7Sus2;
        static public readonly ChordFormula AbSus4;
        static public readonly ChordFormula Ab7Sus4;
        static public readonly ChordFormula AbSus2Sus4;
        static public readonly ChordFormula Abm;
        static public readonly ChordFormula Abm7;
        static public readonly ChordFormula AbmM7;
        static public readonly ChordFormula AbmMaj7aug5;
        static public readonly ChordFormula Abm6;
        static public readonly ChordFormula Abm9;
        static public readonly ChordFormula Abm11;
        static public readonly ChordFormula Abm13;
        static public readonly ChordFormula AbmAdd9;
        static public readonly ChordFormula AbMaj;
        static public readonly ChordFormula Ab6;
        static public readonly ChordFormula AbMaj7;
        static public readonly ChordFormula AbMaj9;
        static public readonly ChordFormula AbMaj11;
        static public readonly ChordFormula AbMaj13;
        static public readonly ChordFormula AbAdd9;
        static public readonly ChordFormula AbMajMu;
        static public readonly ChordFormula AbMaj7b5;
        static public readonly ChordFormula AbMaj7aug5;
        static public readonly ChordFormula Ab7;
        static public readonly ChordFormula Ab9;
        static public readonly ChordFormula Ab11;
        static public readonly ChordFormula Ab13;
        static public readonly ChordFormula Ab7b5;
        static public readonly ChordFormula Ab7b9;
        static public readonly ChordFormula Ab7sharp9;
        static public readonly ChordFormula Aaug;
        static public readonly ChordFormula Adim;
        static public readonly ChordFormula Am7b5;
        static public readonly ChordFormula Adim7;
        static public readonly ChordFormula ASus2;
        static public readonly ChordFormula A7Sus2;
        static public readonly ChordFormula ASus4;
        static public readonly ChordFormula A7Sus4;
        static public readonly ChordFormula ASus2Sus4;
        static public readonly ChordFormula Am;
        static public readonly ChordFormula Am7;
        static public readonly ChordFormula AmM7;
        static public readonly ChordFormula AmMaj7aug5;
        static public readonly ChordFormula Am6;
        static public readonly ChordFormula Am9;
        static public readonly ChordFormula Am11;
        static public readonly ChordFormula Am13;
        static public readonly ChordFormula AmAdd9;
        static public readonly ChordFormula AMaj;
        static public readonly ChordFormula A6;
        static public readonly ChordFormula AMaj7;
        static public readonly ChordFormula AMaj9;
        static public readonly ChordFormula AMaj11;
        static public readonly ChordFormula AMaj13;
        static public readonly ChordFormula AAdd9;
        static public readonly ChordFormula AMajMu;
        static public readonly ChordFormula AMaj7b5;
        static public readonly ChordFormula AMaj7aug5;
        static public readonly ChordFormula A7;
        static public readonly ChordFormula A9;
        static public readonly ChordFormula A11;
        static public readonly ChordFormula A13;
        static public readonly ChordFormula A7b5;
        static public readonly ChordFormula A7b9;
        static public readonly ChordFormula A7sharp9;
        static public readonly ChordFormula ASharpaug;
        static public readonly ChordFormula ASharpdim;
        static public readonly ChordFormula ASharpm7b5;
        static public readonly ChordFormula ASharpdim7;
        static public readonly ChordFormula ASharpSus2;
        static public readonly ChordFormula ASharp7Sus2;
        static public readonly ChordFormula ASharpSus4;
        static public readonly ChordFormula ASharp7Sus4;
        static public readonly ChordFormula ASharpSus2Sus4;
        static public readonly ChordFormula ASharpm;
        static public readonly ChordFormula ASharpm7;
        static public readonly ChordFormula ASharpmM7;
        static public readonly ChordFormula ASharpmMaj7aug5;
        static public readonly ChordFormula ASharpm6;
        static public readonly ChordFormula ASharpm9;
        static public readonly ChordFormula ASharpm11;
        static public readonly ChordFormula ASharpm13;
        static public readonly ChordFormula ASharpmAdd9;
        static public readonly ChordFormula ASharpMaj;
        static public readonly ChordFormula ASharp6;
        static public readonly ChordFormula ASharpMaj7;
        static public readonly ChordFormula ASharpMaj9;
        static public readonly ChordFormula ASharpMaj11;
        static public readonly ChordFormula ASharpMaj13;
        static public readonly ChordFormula ASharpAdd9;
        static public readonly ChordFormula ASharpMajMu;
        static public readonly ChordFormula ASharpMaj7b5;
        static public readonly ChordFormula ASharpMaj7aug5;
        static public readonly ChordFormula ASharp7;
        static public readonly ChordFormula ASharp9;
        static public readonly ChordFormula ASharp11;
        static public readonly ChordFormula ASharp13;
        static public readonly ChordFormula ASharp7b5;
        static public readonly ChordFormula ASharp7b9;
        static public readonly ChordFormula ASharp7sharp9;
        static public readonly ChordFormula Bbaug;
        static public readonly ChordFormula Bbdim;
        static public readonly ChordFormula Bbm7b5;
        static public readonly ChordFormula Bbdim7;
        static public readonly ChordFormula BbSus2;
        static public readonly ChordFormula Bb7Sus2;
        static public readonly ChordFormula BbSus4;
        static public readonly ChordFormula Bb7Sus4;
        static public readonly ChordFormula BbSus2Sus4;
        static public readonly ChordFormula Bbm;
        static public readonly ChordFormula Bbm7;
        static public readonly ChordFormula BbmM7;
        static public readonly ChordFormula BbmMaj7aug5;
        static public readonly ChordFormula Bbm6;
        static public readonly ChordFormula Bbm9;
        static public readonly ChordFormula Bbm11;
        static public readonly ChordFormula Bbm13;
        static public readonly ChordFormula BbmAdd9;
        static public readonly ChordFormula BbMaj;
        static public readonly ChordFormula Bb6;
        static public readonly ChordFormula BbMaj7;
        static public readonly ChordFormula BbMaj9;
        static public readonly ChordFormula BbMaj11;
        static public readonly ChordFormula BbMaj13;
        static public readonly ChordFormula BbAdd9;
        static public readonly ChordFormula BbMajMu;
        static public readonly ChordFormula BbMaj7b5;
        static public readonly ChordFormula BbMaj7aug5;
        static public readonly ChordFormula Bb7;
        static public readonly ChordFormula Bb9;
        static public readonly ChordFormula Bb11;
        static public readonly ChordFormula Bb13;
        static public readonly ChordFormula Bb7b5;
        static public readonly ChordFormula Bb7b9;
        static public readonly ChordFormula Bb7sharp9;
        static public readonly ChordFormula Baug;
        static public readonly ChordFormula Bdim;
        static public readonly ChordFormula Bm7b5;
        static public readonly ChordFormula Bdim7;
        static public readonly ChordFormula BSus2;
        static public readonly ChordFormula B7Sus2;
        static public readonly ChordFormula BSus4;
        static public readonly ChordFormula B7Sus4;
        static public readonly ChordFormula BSus2Sus4;
        static public readonly ChordFormula Bm;
        static public readonly ChordFormula Bm7;
        static public readonly ChordFormula BmM7;
        static public readonly ChordFormula BmMaj7aug5;
        static public readonly ChordFormula Bm6;
        static public readonly ChordFormula Bm9;
        static public readonly ChordFormula Bm11;
        static public readonly ChordFormula Bm13;
        static public readonly ChordFormula BmAdd9;
        static public readonly ChordFormula BMaj;
        static public readonly ChordFormula B6;
        static public readonly ChordFormula BMaj7;
        static public readonly ChordFormula BMaj9;
        static public readonly ChordFormula BMaj11;
        static public readonly ChordFormula BMaj13;
        static public readonly ChordFormula BAdd9;
        static public readonly ChordFormula BMajMu;
        static public readonly ChordFormula BMaj7b5;
        static public readonly ChordFormula BMaj7aug5;
        static public readonly ChordFormula B7;
        static public readonly ChordFormula B9;
        static public readonly ChordFormula B11;
        static public readonly ChordFormula B13;
        static public readonly ChordFormula B7b5;
        static public readonly ChordFormula B7b9;
        static public readonly ChordFormula B7sharp9;
        static public readonly ChordFormula Cbaug;
        static public readonly ChordFormula Cbdim;
        static public readonly ChordFormula Cbm7b5;
        static public readonly ChordFormula Cbdim7;
        static public readonly ChordFormula CbSus2;
        static public readonly ChordFormula Cb7Sus2;
        static public readonly ChordFormula CbSus4;
        static public readonly ChordFormula Cb7Sus4;
        static public readonly ChordFormula CbSus2Sus4;
        static public readonly ChordFormula Cbm;
        static public readonly ChordFormula Cbm7;
        static public readonly ChordFormula CbmM7;
        static public readonly ChordFormula CbmMaj7aug5;
        static public readonly ChordFormula Cbm6;
        static public readonly ChordFormula Cbm9;
        static public readonly ChordFormula Cbm11;
        static public readonly ChordFormula Cbm13;
        static public readonly ChordFormula CbmAdd9;
        static public readonly ChordFormula CbMaj;
        static public readonly ChordFormula Cb6;
        static public readonly ChordFormula CbMaj7;
        static public readonly ChordFormula CbMaj9;
        static public readonly ChordFormula CbMaj11;
        static public readonly ChordFormula CbMaj13;
        static public readonly ChordFormula CbAdd9;
        static public readonly ChordFormula CbMajMu;
        static public readonly ChordFormula CbMaj7b5;
        static public readonly ChordFormula CbMaj7aug5;
        static public readonly ChordFormula Cb7;
        static public readonly ChordFormula Cb9;
        static public readonly ChordFormula Cb11;
        static public readonly ChordFormula Cb13;
        static public readonly ChordFormula Cb7b5;
        static public readonly ChordFormula Cb7b9;
        static public readonly ChordFormula Cb7sharp9;
        #endregion static Chords

        #region Catalog Properties
        static List<ChordFormula> _Catalog { get; set; } = new List<ChordFormula>();
        static List<ChordFormula> _InternalCatalog { get; set; } = new List<ChordFormula>();
        static public IEnumerable<ChordFormula> Catalog { get { return _Catalog; } }
        static public IEnumerable<ChordFormula> InternalCatalog { get { return _InternalCatalog; } }

        #endregion


        static void AddToCatalog(NoteName nn, ChordType ct)
        {
            try
            {
                var result = ChordFormulaFactory.Create(nn, ct, null);
                if (result != null)
                {
                    _Catalog.Add(result);
                }
            }
            catch (Exception)
            {
                Debug.WriteLine($"{nn}, {ct}");
                throw;
            }
        }
        static ChordFormula()
        {
            //GenerateCodeForStaticChord_Catalog();

            try
            {
                #region Instantiate static chord _Catalog.
                #region NoteName.B♯
                _Catalog.Add(BSharpaug = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Augmented, null));
                _Catalog.Add(BSharpdim = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Diminished, null));
                _Catalog.Add(BSharpm7b5 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.HalfDiminished, null));
                _Catalog.Add(BSharpdim7 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Diminished7, null));
                _Catalog.Add(BSharpSus2 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Sus2, null));
                _Catalog.Add(BSharp7Sus2 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.SevenSus2, null));
                _Catalog.Add(BSharpSus4 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Sus4, null));
                _Catalog.Add(BSharp7Sus4 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.SevenSus4, null));
                _Catalog.Add(BSharpSus2Sus4 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Sus2Sus4, null));
                _Catalog.Add(BSharpm = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Minor, null));
                _Catalog.Add(BSharpm7 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Minor7th, null));
                _Catalog.Add(BSharpmM7 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.MinorMaj7th, null));
                _Catalog.Add(BSharpmMaj7aug5 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.MinorMaj7thAug5, null));
                _Catalog.Add(BSharpm6 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Minor6th, null));
                _Catalog.Add(BSharpm9 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Minor9th, null));
                _Catalog.Add(BSharpm11 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Minor11th, null));
                _Catalog.Add(BSharpm13 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Minor13th, null));
                _Catalog.Add(BSharpmAdd9 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.MinorAdd9, null));
                _Catalog.Add(BSharpMaj = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Major, null));
                _Catalog.Add(BSharp6 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Major6th, null));
                _Catalog.Add(BSharpMaj7 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Major7th, null));
                _Catalog.Add(BSharpMaj9 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Major9th, null));
                _Catalog.Add(BSharpMaj11 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Major11th, null));
                _Catalog.Add(BSharpMaj13 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Major13th, null));
                _Catalog.Add(BSharpAdd9 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.MajorAdd9, null));
                _Catalog.Add(BSharpMajMu = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.MajorMu, null));
                _Catalog.Add(BSharpMaj7b5 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Major7b5, null));
                _Catalog.Add(BSharpMaj7aug5 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Major7Aug5, null));
                _Catalog.Add(BSharp7 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Dominant7th, null));
                _Catalog.Add(BSharp9 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Dominant9th, null));
                _Catalog.Add(BSharp11 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Dominant11th, null));
                _Catalog.Add(BSharp13 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Dominant13th, null));
                _Catalog.Add(BSharp7b5 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Dominant7b5, null));
                _Catalog.Add(BSharp7b9 = ChordFormulaFactory.Create(NoteName.BSharp, ChordType.Dominant7b9, null));
                #endregion NoteName.B♯

                #region NoteName.C
                _Catalog.Add(Caug = ChordFormulaFactory.Create(NoteName.C, ChordType.Augmented, null));
                _Catalog.Add(Cdim = ChordFormulaFactory.Create(NoteName.C, ChordType.Diminished, null));
                _Catalog.Add(Cm7b5 = ChordFormulaFactory.Create(NoteName.C, ChordType.HalfDiminished, null));
                _Catalog.Add(Cdim7 = ChordFormulaFactory.Create(NoteName.C, ChordType.Diminished7, null));
                _Catalog.Add(CSus2 = ChordFormulaFactory.Create(NoteName.C, ChordType.Sus2, null));
                _Catalog.Add(C7Sus2 = ChordFormulaFactory.Create(NoteName.C, ChordType.SevenSus2, null));
                _Catalog.Add(CSus4 = ChordFormulaFactory.Create(NoteName.C, ChordType.Sus4, null));
                _Catalog.Add(C7Sus4 = ChordFormulaFactory.Create(NoteName.C, ChordType.SevenSus4, null));
                _Catalog.Add(CSus2Sus4 = ChordFormulaFactory.Create(NoteName.C, ChordType.Sus2Sus4, null));
                _Catalog.Add(Cm = ChordFormulaFactory.Create(NoteName.C, ChordType.Minor, null));
                _Catalog.Add(Cm7 = ChordFormulaFactory.Create(NoteName.C, ChordType.Minor7th, null));
                _Catalog.Add(CmM7 = ChordFormulaFactory.Create(NoteName.C, ChordType.MinorMaj7th, null));
                _Catalog.Add(CmMaj7aug5 = ChordFormulaFactory.Create(NoteName.C, ChordType.MinorMaj7thAug5, null));
                _Catalog.Add(Cm6 = ChordFormulaFactory.Create(NoteName.C, ChordType.Minor6th, null));
                _Catalog.Add(Cm9 = ChordFormulaFactory.Create(NoteName.C, ChordType.Minor9th, null));
                _Catalog.Add(Cm11 = ChordFormulaFactory.Create(NoteName.C, ChordType.Minor11th, null));
                _Catalog.Add(Cm13 = ChordFormulaFactory.Create(NoteName.C, ChordType.Minor13th, null));
                _Catalog.Add(CmAdd9 = ChordFormulaFactory.Create(NoteName.C, ChordType.MinorAdd9, null));
                _Catalog.Add(CMaj = ChordFormulaFactory.Create(NoteName.C, ChordType.Major, null));
                _Catalog.Add(C6 = ChordFormulaFactory.Create(NoteName.C, ChordType.Major6th, null));
                _Catalog.Add(CMaj7 = ChordFormulaFactory.Create(NoteName.C, ChordType.Major7th, null));
                _Catalog.Add(CMaj9 = ChordFormulaFactory.Create(NoteName.C, ChordType.Major9th, null));
                _Catalog.Add(CMaj11 = ChordFormulaFactory.Create(NoteName.C, ChordType.Major11th, null));
                _Catalog.Add(CMaj13 = ChordFormulaFactory.Create(NoteName.C, ChordType.Major13th, null));
                _Catalog.Add(CAdd9 = ChordFormulaFactory.Create(NoteName.C, ChordType.MajorAdd9, null));
                _Catalog.Add(CMajMu = ChordFormulaFactory.Create(NoteName.C, ChordType.MajorMu, null));
                _Catalog.Add(CMaj7b5 = ChordFormulaFactory.Create(NoteName.C, ChordType.Major7b5, null));
                _Catalog.Add(CMaj7aug5 = ChordFormulaFactory.Create(NoteName.C, ChordType.Major7Aug5, null));
                _Catalog.Add(C7 = ChordFormulaFactory.Create(NoteName.C, ChordType.Dominant7th, null));
                _Catalog.Add(C9 = ChordFormulaFactory.Create(NoteName.C, ChordType.Dominant9th, null));
                _Catalog.Add(C11 = ChordFormulaFactory.Create(NoteName.C, ChordType.Dominant11th, null));
                _Catalog.Add(C13 = ChordFormulaFactory.Create(NoteName.C, ChordType.Dominant13th, null));
                _Catalog.Add(C7b5 = ChordFormulaFactory.Create(NoteName.C, ChordType.Dominant7b5, null));
                _Catalog.Add(C7b9 = ChordFormulaFactory.Create(NoteName.C, ChordType.Dominant7b9, null));
                _Catalog.Add(C7sharp9 = ChordFormulaFactory.Create(NoteName.C, ChordType.Dominant7Sharp9, null));
                #endregion NoteName.C

                #region NoteName.C♯
                _Catalog.Add(CSharpaug = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Augmented, null));
                _Catalog.Add(CSharpdim = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Diminished, null));
                _Catalog.Add(CSharpm7b5 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.HalfDiminished, null));
                _Catalog.Add(CSharpdim7 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Diminished7, null));
                _Catalog.Add(CSharpSus2 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Sus2, null));
                _Catalog.Add(CSharp7Sus2 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.SevenSus2, null));
                _Catalog.Add(CSharpSus4 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Sus4, null));
                _Catalog.Add(CSharp7Sus4 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.SevenSus4, null));
                _Catalog.Add(CSharpSus2Sus4 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Sus2Sus4, null));
                _Catalog.Add(CSharpm = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Minor, null));
                _Catalog.Add(CSharpm7 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Minor7th, null));
                _Catalog.Add(CSharpmM7 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.MinorMaj7th, null));
                _Catalog.Add(CSharpmMaj7aug5 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.MinorMaj7thAug5, null));
                _Catalog.Add(CSharpm6 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Minor6th, null));
                _Catalog.Add(CSharpm9 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Minor9th, null));
                _Catalog.Add(CSharpm11 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Minor11th, null));
                _Catalog.Add(CSharpm13 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Minor13th, null));
                _Catalog.Add(CSharpmAdd9 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.MinorAdd9, null));
                _Catalog.Add(CSharpMaj = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Major, null));
                _Catalog.Add(CSharp6 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Major6th, null));
                _Catalog.Add(CSharpMaj7 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Major7th, null));
                _Catalog.Add(CSharpMaj9 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Major9th, null));
                _Catalog.Add(CSharpMaj11 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Major11th, null));
                _Catalog.Add(CSharpMaj13 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Major13th, null));
                _Catalog.Add(CSharpAdd9 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.MajorAdd9, null));
                _Catalog.Add(CSharpMajMu = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.MajorMu, null));
                _Catalog.Add(CSharpMaj7b5 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Major7b5, null));
                _Catalog.Add(CSharpMaj7aug5 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Major7Aug5, null));
                _Catalog.Add(CSharp7 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Dominant7th, null));
                _Catalog.Add(CSharp9 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Dominant9th, null));
                _Catalog.Add(CSharp11 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Dominant11th, null));
                _Catalog.Add(CSharp13 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Dominant13th, null));
                _Catalog.Add(CSharp7b5 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Dominant7b5, null));
                _Catalog.Add(CSharp7b9 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Dominant7b9, null));
                _Catalog.Add(CSharp7sharp9 = ChordFormulaFactory.Create(NoteName.CSharp, ChordType.Dominant7Sharp9, null));
                #endregion NoteName.C♯

                #region NoteName.D♭
                _Catalog.Add(Dbaug = ChordFormulaFactory.Create(NoteName.Db, ChordType.Augmented, null));
                _Catalog.Add(Dbdim = ChordFormulaFactory.Create(NoteName.Db, ChordType.Diminished, null));
                _Catalog.Add(Dbm7b5 = ChordFormulaFactory.Create(NoteName.Db, ChordType.HalfDiminished, null));
                _Catalog.Add(Dbdim7 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Diminished7, null));
                _Catalog.Add(DbSus2 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Sus2, null));
                _Catalog.Add(Db7Sus2 = ChordFormulaFactory.Create(NoteName.Db, ChordType.SevenSus2, null));
                _Catalog.Add(DbSus4 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Sus4, null));
                _Catalog.Add(Db7Sus4 = ChordFormulaFactory.Create(NoteName.Db, ChordType.SevenSus4, null));
                _Catalog.Add(DbSus2Sus4 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Sus2Sus4, null));
                _Catalog.Add(Dbm = ChordFormulaFactory.Create(NoteName.Db, ChordType.Minor, null));
                _Catalog.Add(Dbm7 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Minor7th, null));
                _Catalog.Add(DbmM7 = ChordFormulaFactory.Create(NoteName.Db, ChordType.MinorMaj7th, null));
                _Catalog.Add(DbmMaj7aug5 = ChordFormulaFactory.Create(NoteName.Db, ChordType.MinorMaj7thAug5, null));
                _Catalog.Add(Dbm6 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Minor6th, null));
                _Catalog.Add(Dbm9 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Minor9th, null));
                _Catalog.Add(Dbm11 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Minor11th, null));
                _Catalog.Add(Dbm13 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Minor13th, null));
                _Catalog.Add(DbmAdd9 = ChordFormulaFactory.Create(NoteName.Db, ChordType.MinorAdd9, null));
                _Catalog.Add(DbMaj = ChordFormulaFactory.Create(NoteName.Db, ChordType.Major, null));
                _Catalog.Add(Db6 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Major6th, null));
                _Catalog.Add(DbMaj7 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Major7th, null));
                _Catalog.Add(DbMaj9 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Major9th, null));
                _Catalog.Add(DbMaj11 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Major11th, null));
                _Catalog.Add(DbMaj13 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Major13th, null));
                _Catalog.Add(DbAdd9 = ChordFormulaFactory.Create(NoteName.Db, ChordType.MajorAdd9, null));
                _Catalog.Add(DbMajMu = ChordFormulaFactory.Create(NoteName.Db, ChordType.MajorMu, null));
                _Catalog.Add(DbMaj7b5 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Major7b5, null));
                _Catalog.Add(DbMaj7aug5 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Major7Aug5, null));
                _Catalog.Add(Db7 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Dominant7th, null));
                _Catalog.Add(Db9 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Dominant9th, null));
                _Catalog.Add(Db11 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Dominant11th, null));
                _Catalog.Add(Db13 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Dominant13th, null));
                _Catalog.Add(Db7b5 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Dominant7b5, null));
                _Catalog.Add(Db7b9 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Dominant7b9, null));
                _Catalog.Add(Db7sharp9 = ChordFormulaFactory.Create(NoteName.Db, ChordType.Dominant7Sharp9, null));
                #endregion NoteName.D♭

                #region NoteName.D
                _Catalog.Add(Daug = ChordFormulaFactory.Create(NoteName.D, ChordType.Augmented, null));
                _Catalog.Add(Ddim = ChordFormulaFactory.Create(NoteName.D, ChordType.Diminished, null));
                _Catalog.Add(Dm7b5 = ChordFormulaFactory.Create(NoteName.D, ChordType.HalfDiminished, null));
                _Catalog.Add(Ddim7 = ChordFormulaFactory.Create(NoteName.D, ChordType.Diminished7, null));
                _Catalog.Add(DSus2 = ChordFormulaFactory.Create(NoteName.D, ChordType.Sus2, null));
                _Catalog.Add(D7Sus2 = ChordFormulaFactory.Create(NoteName.D, ChordType.SevenSus2, null));
                _Catalog.Add(DSus4 = ChordFormulaFactory.Create(NoteName.D, ChordType.Sus4, null));
                _Catalog.Add(D7Sus4 = ChordFormulaFactory.Create(NoteName.D, ChordType.SevenSus4, null));
                _Catalog.Add(DSus2Sus4 = ChordFormulaFactory.Create(NoteName.D, ChordType.Sus2Sus4, null));
                _Catalog.Add(Dm = ChordFormulaFactory.Create(NoteName.D, ChordType.Minor, null));
                _Catalog.Add(Dm7 = ChordFormulaFactory.Create(NoteName.D, ChordType.Minor7th, null));
                _Catalog.Add(DmM7 = ChordFormulaFactory.Create(NoteName.D, ChordType.MinorMaj7th, null));
                _Catalog.Add(DmMaj7aug5 = ChordFormulaFactory.Create(NoteName.D, ChordType.MinorMaj7thAug5, null));
                _Catalog.Add(Dm6 = ChordFormulaFactory.Create(NoteName.D, ChordType.Minor6th, null));
                _Catalog.Add(Dm9 = ChordFormulaFactory.Create(NoteName.D, ChordType.Minor9th, null));
                _Catalog.Add(Dm11 = ChordFormulaFactory.Create(NoteName.D, ChordType.Minor11th, null));
                _Catalog.Add(Dm13 = ChordFormulaFactory.Create(NoteName.D, ChordType.Minor13th, null));
                _Catalog.Add(DmAdd9 = ChordFormulaFactory.Create(NoteName.D, ChordType.MinorAdd9, null));
                _Catalog.Add(DMaj = ChordFormulaFactory.Create(NoteName.D, ChordType.Major, null));
                _Catalog.Add(D6 = ChordFormulaFactory.Create(NoteName.D, ChordType.Major6th, null));
                _Catalog.Add(DMaj7 = ChordFormulaFactory.Create(NoteName.D, ChordType.Major7th, null));
                _Catalog.Add(DMaj9 = ChordFormulaFactory.Create(NoteName.D, ChordType.Major9th, null));
                _Catalog.Add(DMaj11 = ChordFormulaFactory.Create(NoteName.D, ChordType.Major11th, null));
                _Catalog.Add(DMaj13 = ChordFormulaFactory.Create(NoteName.D, ChordType.Major13th, null));
                _Catalog.Add(DAdd9 = ChordFormulaFactory.Create(NoteName.D, ChordType.MajorAdd9, null));
                _Catalog.Add(DMajMu = ChordFormulaFactory.Create(NoteName.D, ChordType.MajorMu, null));
                _Catalog.Add(DMaj7b5 = ChordFormulaFactory.Create(NoteName.D, ChordType.Major7b5, null));
                _Catalog.Add(DMaj7aug5 = ChordFormulaFactory.Create(NoteName.D, ChordType.Major7Aug5, null));
                _Catalog.Add(D7 = ChordFormulaFactory.Create(NoteName.D, ChordType.Dominant7th, null));
                _Catalog.Add(D9 = ChordFormulaFactory.Create(NoteName.D, ChordType.Dominant9th, null));
                _Catalog.Add(D11 = ChordFormulaFactory.Create(NoteName.D, ChordType.Dominant11th, null));
                _Catalog.Add(D13 = ChordFormulaFactory.Create(NoteName.D, ChordType.Dominant13th, null));
                _Catalog.Add(D7b5 = ChordFormulaFactory.Create(NoteName.D, ChordType.Dominant7b5, null));
                _Catalog.Add(D7b9 = ChordFormulaFactory.Create(NoteName.D, ChordType.Dominant7b9, null));
                _Catalog.Add(D7sharp9 = ChordFormulaFactory.Create(NoteName.D, ChordType.Dominant7Sharp9, null));
                #endregion NoteName.D

                #region NoteName.D♯
                _Catalog.Add(DSharpaug = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Augmented, null));
                _Catalog.Add(DSharpdim = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Diminished, null));
                _Catalog.Add(DSharpm7b5 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.HalfDiminished, null));
                _Catalog.Add(DSharpdim7 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Diminished7, null));
                _Catalog.Add(DSharpSus2 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Sus2, null));
                _Catalog.Add(DSharp7Sus2 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.SevenSus2, null));
                _Catalog.Add(DSharpSus4 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Sus4, null));
                _Catalog.Add(DSharp7Sus4 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.SevenSus4, null));
                _Catalog.Add(DSharpSus2Sus4 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Sus2Sus4, null));
                _Catalog.Add(DSharpm = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Minor, null));
                _Catalog.Add(DSharpm7 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Minor7th, null));
                _Catalog.Add(DSharpmM7 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.MinorMaj7th, null));
                _Catalog.Add(DSharpmMaj7aug5 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.MinorMaj7thAug5, null));
                _Catalog.Add(DSharpm6 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Minor6th, null));
                _Catalog.Add(DSharpm9 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Minor9th, null));
                _Catalog.Add(DSharpm11 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Minor11th, null));
                _Catalog.Add(DSharpm13 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Minor13th, null));
                _Catalog.Add(DSharpmAdd9 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.MinorAdd9, null));
                _Catalog.Add(DSharpMaj = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Major, null));
                _Catalog.Add(DSharp6 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Major6th, null));
                _Catalog.Add(DSharpMaj7 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Major7th, null));
                _Catalog.Add(DSharpMaj9 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Major9th, null));
                _Catalog.Add(DSharpMaj11 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Major11th, null));
                _Catalog.Add(DSharpMaj13 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Major13th, null));
                _Catalog.Add(DSharpAdd9 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.MajorAdd9, null));
                _Catalog.Add(DSharpMajMu = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.MajorMu, null));
                _Catalog.Add(DSharpMaj7b5 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Major7b5, null));
                _Catalog.Add(DSharpMaj7aug5 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Major7Aug5, null));
                _Catalog.Add(DSharp7 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Dominant7th, null));
                _Catalog.Add(DSharp9 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Dominant9th, null));
                _Catalog.Add(DSharp11 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Dominant11th, null));
                _Catalog.Add(DSharp13 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Dominant13th, null));
                _Catalog.Add(DSharp7b5 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Dominant7b5, null));
                _Catalog.Add(DSharp7b9 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Dominant7b9, null));
                _Catalog.Add(DSharp7sharp9 = ChordFormulaFactory.Create(NoteName.DSharp, ChordType.Dominant7Sharp9, null));
                #endregion NoteName.D♯

                #region NoteName.E♭
                _Catalog.Add(Ebaug = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Augmented, null));
                _Catalog.Add(Ebdim = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Diminished, null));
                _Catalog.Add(Ebm7b5 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.HalfDiminished, null));
                _Catalog.Add(Ebdim7 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Diminished7, null));
                _Catalog.Add(EbSus2 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Sus2, null));
                _Catalog.Add(Eb7Sus2 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.SevenSus2, null));
                _Catalog.Add(EbSus4 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Sus4, null));
                _Catalog.Add(Eb7Sus4 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.SevenSus4, null));
                _Catalog.Add(EbSus2Sus4 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Sus2Sus4, null));
                _Catalog.Add(Ebm = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Minor, null));
                _Catalog.Add(Ebm7 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Minor7th, null));
                _Catalog.Add(EbmM7 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.MinorMaj7th, null));
                _Catalog.Add(EbmMaj7aug5 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.MinorMaj7thAug5, null));
                _Catalog.Add(Ebm6 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Minor6th, null));
                _Catalog.Add(Ebm9 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Minor9th, null));
                _Catalog.Add(Ebm11 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Minor11th, null));
                _Catalog.Add(Ebm13 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Minor13th, null));
                _Catalog.Add(EbmAdd9 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.MinorAdd9, null));
                _Catalog.Add(EbMaj = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Major, null));
                _Catalog.Add(Eb6 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Major6th, null));
                _Catalog.Add(EbMaj7 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Major7th, null));
                _Catalog.Add(EbMaj9 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Major9th, null));
                _Catalog.Add(EbMaj11 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Major11th, null));
                _Catalog.Add(EbMaj13 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Major13th, null));
                _Catalog.Add(EbAdd9 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.MajorAdd9, null));
                _Catalog.Add(EbMajMu = ChordFormulaFactory.Create(NoteName.Eb, ChordType.MajorMu, null));
                _Catalog.Add(EbMaj7b5 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Major7b5, null));
                _Catalog.Add(EbMaj7aug5 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Major7Aug5, null));
                _Catalog.Add(Eb7 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Dominant7th, null));
                _Catalog.Add(Eb9 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Dominant9th, null));
                _Catalog.Add(Eb11 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Dominant11th, null));
                _Catalog.Add(Eb13 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Dominant13th, null));
                _Catalog.Add(Eb7b5 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Dominant7b5, null));
                _Catalog.Add(Eb7b9 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Dominant7b9, null));
                _Catalog.Add(Eb7sharp9 = ChordFormulaFactory.Create(NoteName.Eb, ChordType.Dominant7Sharp9, null));
                #endregion NoteName.E♭

                #region NoteName.E
                _Catalog.Add(Eaug = ChordFormulaFactory.Create(NoteName.E, ChordType.Augmented, null));
                _Catalog.Add(Edim = ChordFormulaFactory.Create(NoteName.E, ChordType.Diminished, null));
                _Catalog.Add(Em7b5 = ChordFormulaFactory.Create(NoteName.E, ChordType.HalfDiminished, null));
                _Catalog.Add(Edim7 = ChordFormulaFactory.Create(NoteName.E, ChordType.Diminished7, null));
                _Catalog.Add(ESus2 = ChordFormulaFactory.Create(NoteName.E, ChordType.Sus2, null));
                _Catalog.Add(E7Sus2 = ChordFormulaFactory.Create(NoteName.E, ChordType.SevenSus2, null));
                _Catalog.Add(ESus4 = ChordFormulaFactory.Create(NoteName.E, ChordType.Sus4, null));
                _Catalog.Add(E7Sus4 = ChordFormulaFactory.Create(NoteName.E, ChordType.SevenSus4, null));
                _Catalog.Add(ESus2Sus4 = ChordFormulaFactory.Create(NoteName.E, ChordType.Sus2Sus4, null));
                _Catalog.Add(Em = ChordFormulaFactory.Create(NoteName.E, ChordType.Minor, null));
                _Catalog.Add(Em7 = ChordFormulaFactory.Create(NoteName.E, ChordType.Minor7th, null));
                _Catalog.Add(EmM7 = ChordFormulaFactory.Create(NoteName.E, ChordType.MinorMaj7th, null));
                _Catalog.Add(EmMaj7aug5 = ChordFormulaFactory.Create(NoteName.E, ChordType.MinorMaj7thAug5, null));
                _Catalog.Add(Em6 = ChordFormulaFactory.Create(NoteName.E, ChordType.Minor6th, null));
                _Catalog.Add(Em9 = ChordFormulaFactory.Create(NoteName.E, ChordType.Minor9th, null));
                _Catalog.Add(Em11 = ChordFormulaFactory.Create(NoteName.E, ChordType.Minor11th, null));
                _Catalog.Add(Em13 = ChordFormulaFactory.Create(NoteName.E, ChordType.Minor13th, null));
                _Catalog.Add(EmAdd9 = ChordFormulaFactory.Create(NoteName.E, ChordType.MinorAdd9, null));
                _Catalog.Add(EMaj = ChordFormulaFactory.Create(NoteName.E, ChordType.Major, null));
                _Catalog.Add(E6 = ChordFormulaFactory.Create(NoteName.E, ChordType.Major6th, null));
                _Catalog.Add(EMaj7 = ChordFormulaFactory.Create(NoteName.E, ChordType.Major7th, null));
                _Catalog.Add(EMaj9 = ChordFormulaFactory.Create(NoteName.E, ChordType.Major9th, null));
                _Catalog.Add(EMaj11 = ChordFormulaFactory.Create(NoteName.E, ChordType.Major11th, null));
                _Catalog.Add(EMaj13 = ChordFormulaFactory.Create(NoteName.E, ChordType.Major13th, null));
                _Catalog.Add(EAdd9 = ChordFormulaFactory.Create(NoteName.E, ChordType.MajorAdd9, null));
                _Catalog.Add(EMajMu = ChordFormulaFactory.Create(NoteName.E, ChordType.MajorMu, null));
                _Catalog.Add(EMaj7b5 = ChordFormulaFactory.Create(NoteName.E, ChordType.Major7b5, null));
                _Catalog.Add(EMaj7aug5 = ChordFormulaFactory.Create(NoteName.E, ChordType.Major7Aug5, null));
                _Catalog.Add(E7 = ChordFormulaFactory.Create(NoteName.E, ChordType.Dominant7th, null));
                _Catalog.Add(E9 = ChordFormulaFactory.Create(NoteName.E, ChordType.Dominant9th, null));
                _Catalog.Add(E11 = ChordFormulaFactory.Create(NoteName.E, ChordType.Dominant11th, null));
                _Catalog.Add(E13 = ChordFormulaFactory.Create(NoteName.E, ChordType.Dominant13th, null));
                _Catalog.Add(E7b5 = ChordFormulaFactory.Create(NoteName.E, ChordType.Dominant7b5, null));
                _Catalog.Add(E7b9 = ChordFormulaFactory.Create(NoteName.E, ChordType.Dominant7b9, null));
                _Catalog.Add(E7sharp9 = ChordFormulaFactory.Create(NoteName.E, ChordType.Dominant7Sharp9, null));
                #endregion NoteName.E

                #region NoteName.F♭
                _Catalog.Add(Fbaug = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Augmented, null));
                _Catalog.Add(Fbdim = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Diminished, null));
                _Catalog.Add(Fbm7b5 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.HalfDiminished, null));
                _Catalog.Add(Fbdim7 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Diminished7, null));
                _Catalog.Add(FbSus2 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Sus2, null));
                _Catalog.Add(Fb7Sus2 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.SevenSus2, null));
                _Catalog.Add(FbSus4 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Sus4, null));
                _Catalog.Add(Fb7Sus4 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.SevenSus4, null));
                _Catalog.Add(FbSus2Sus4 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Sus2Sus4, null));
                _Catalog.Add(Fbm = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Minor, null));
                _Catalog.Add(Fbm7 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Minor7th, null));
                _Catalog.Add(FbmM7 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.MinorMaj7th, null));
                _Catalog.Add(FbmMaj7aug5 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.MinorMaj7thAug5, null));
                _Catalog.Add(Fbm6 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Minor6th, null));
                _Catalog.Add(Fbm9 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Minor9th, null));
                _Catalog.Add(Fbm11 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Minor11th, null));
                _Catalog.Add(Fbm13 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Minor13th, null));
                _Catalog.Add(FbmAdd9 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.MinorAdd9, null));
                _Catalog.Add(FbMaj = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Major, null));
                _Catalog.Add(Fb6 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Major6th, null));
                _Catalog.Add(FbMaj7 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Major7th, null));
                _Catalog.Add(FbMaj9 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Major9th, null));
                _Catalog.Add(FbMaj11 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Major11th, null));
                _Catalog.Add(FbMaj13 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Major13th, null));
                _Catalog.Add(FbAdd9 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.MajorAdd9, null));
                _Catalog.Add(FbMajMu = ChordFormulaFactory.Create(NoteName.Fb, ChordType.MajorMu, null));
                _Catalog.Add(FbMaj7b5 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Major7b5, null));
                _Catalog.Add(FbMaj7aug5 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Major7Aug5, null));
                _Catalog.Add(Fb7 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Dominant7th, null));
                _Catalog.Add(Fb9 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Dominant9th, null));
                _Catalog.Add(Fb11 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Dominant11th, null));
                _Catalog.Add(Fb13 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Dominant13th, null));
                _Catalog.Add(Fb7b5 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Dominant7b5, null));
                _Catalog.Add(Fb7b9 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Dominant7b9, null));
                _Catalog.Add(Fb7sharp9 = ChordFormulaFactory.Create(NoteName.Fb, ChordType.Dominant7Sharp9, null));
                #endregion NoteName.F♭

                #region NoteName.E♯
                _Catalog.Add(ESharpaug = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Augmented, null));
                _Catalog.Add(ESharpdim = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Diminished, null));
                _Catalog.Add(ESharpm7b5 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.HalfDiminished, null));
                _Catalog.Add(ESharpdim7 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Diminished7, null));
                _Catalog.Add(ESharpSus2 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Sus2, null));
                _Catalog.Add(ESharp7Sus2 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.SevenSus2, null));
                _Catalog.Add(ESharpSus4 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Sus4, null));
                _Catalog.Add(ESharp7Sus4 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.SevenSus4, null));
                _Catalog.Add(ESharpSus2Sus4 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Sus2Sus4, null));
                _Catalog.Add(ESharpm = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Minor, null));
                _Catalog.Add(ESharpm7 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Minor7th, null));
                _Catalog.Add(ESharpmM7 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.MinorMaj7th, null));
                _Catalog.Add(ESharpmMaj7aug5 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.MinorMaj7thAug5, null));
                _Catalog.Add(ESharpm6 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Minor6th, null));
                _Catalog.Add(ESharpm9 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Minor9th, null));
                _Catalog.Add(ESharpm11 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Minor11th, null));
                _Catalog.Add(ESharpm13 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Minor13th, null));
                _Catalog.Add(ESharpmAdd9 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.MinorAdd9, null));
                _Catalog.Add(ESharpMaj = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Major, null));
                _Catalog.Add(ESharp6 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Major6th, null));
                _Catalog.Add(ESharpMaj7 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Major7th, null));
                _Catalog.Add(ESharpMaj9 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Major9th, null));
                _Catalog.Add(ESharpMaj11 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Major11th, null));
                _Catalog.Add(ESharpMaj13 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Major13th, null));
                _Catalog.Add(ESharpAdd9 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.MajorAdd9, null));
                _Catalog.Add(ESharpMajMu = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.MajorMu, null));
                _Catalog.Add(ESharpMaj7b5 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Major7b5, null));
                _Catalog.Add(ESharpMaj7aug5 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Major7Aug5, null));
                _Catalog.Add(ESharp7 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Dominant7th, null));
                _Catalog.Add(ESharp9 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Dominant9th, null));
                _Catalog.Add(ESharp11 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Dominant11th, null));
                _Catalog.Add(ESharp13 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Dominant13th, null));
                _Catalog.Add(ESharp7b5 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Dominant7b5, null));
                _Catalog.Add(ESharp7b9 = ChordFormulaFactory.Create(NoteName.ESharp, ChordType.Dominant7b9, null));
                #endregion NoteName.E♯

                #region NoteName.F
                _Catalog.Add(Faug = ChordFormulaFactory.Create(NoteName.F, ChordType.Augmented, null));
                _Catalog.Add(Fdim = ChordFormulaFactory.Create(NoteName.F, ChordType.Diminished, null));
                _Catalog.Add(Fm7b5 = ChordFormulaFactory.Create(NoteName.F, ChordType.HalfDiminished, null));
                _Catalog.Add(Fdim7 = ChordFormulaFactory.Create(NoteName.F, ChordType.Diminished7, null));
                _Catalog.Add(FSus2 = ChordFormulaFactory.Create(NoteName.F, ChordType.Sus2, null));
                _Catalog.Add(F7Sus2 = ChordFormulaFactory.Create(NoteName.F, ChordType.SevenSus2, null));
                _Catalog.Add(FSus4 = ChordFormulaFactory.Create(NoteName.F, ChordType.Sus4, null));
                _Catalog.Add(F7Sus4 = ChordFormulaFactory.Create(NoteName.F, ChordType.SevenSus4, null));
                _Catalog.Add(FSus2Sus4 = ChordFormulaFactory.Create(NoteName.F, ChordType.Sus2Sus4, null));
                _Catalog.Add(Fm = ChordFormulaFactory.Create(NoteName.F, ChordType.Minor, null));
                _Catalog.Add(Fm7 = ChordFormulaFactory.Create(NoteName.F, ChordType.Minor7th, null));
                _Catalog.Add(FmM7 = ChordFormulaFactory.Create(NoteName.F, ChordType.MinorMaj7th, null));
                _Catalog.Add(FmMaj7aug5 = ChordFormulaFactory.Create(NoteName.F, ChordType.MinorMaj7thAug5, null));
                _Catalog.Add(Fm6 = ChordFormulaFactory.Create(NoteName.F, ChordType.Minor6th, null));
                _Catalog.Add(Fm9 = ChordFormulaFactory.Create(NoteName.F, ChordType.Minor9th, null));
                _Catalog.Add(Fm11 = ChordFormulaFactory.Create(NoteName.F, ChordType.Minor11th, null));
                _Catalog.Add(Fm13 = ChordFormulaFactory.Create(NoteName.F, ChordType.Minor13th, null));
                _Catalog.Add(FmAdd9 = ChordFormulaFactory.Create(NoteName.F, ChordType.MinorAdd9, null));
                _Catalog.Add(FMaj = ChordFormulaFactory.Create(NoteName.F, ChordType.Major, null));
                _Catalog.Add(F6 = ChordFormulaFactory.Create(NoteName.F, ChordType.Major6th, null));
                _Catalog.Add(FMaj7 = ChordFormulaFactory.Create(NoteName.F, ChordType.Major7th, null));
                _Catalog.Add(FMaj9 = ChordFormulaFactory.Create(NoteName.F, ChordType.Major9th, null));
                _Catalog.Add(FMaj11 = ChordFormulaFactory.Create(NoteName.F, ChordType.Major11th, null));
                _Catalog.Add(FMaj13 = ChordFormulaFactory.Create(NoteName.F, ChordType.Major13th, null));
                _Catalog.Add(FAdd9 = ChordFormulaFactory.Create(NoteName.F, ChordType.MajorAdd9, null));
                _Catalog.Add(FMajMu = ChordFormulaFactory.Create(NoteName.F, ChordType.MajorMu, null));
                _Catalog.Add(FMaj7b5 = ChordFormulaFactory.Create(NoteName.F, ChordType.Major7b5, null));
                _Catalog.Add(FMaj7aug5 = ChordFormulaFactory.Create(NoteName.F, ChordType.Major7Aug5, null));
                _Catalog.Add(F7 = ChordFormulaFactory.Create(NoteName.F, ChordType.Dominant7th, null));
                _Catalog.Add(F9 = ChordFormulaFactory.Create(NoteName.F, ChordType.Dominant9th, null));
                _Catalog.Add(F11 = ChordFormulaFactory.Create(NoteName.F, ChordType.Dominant11th, null));
                _Catalog.Add(F13 = ChordFormulaFactory.Create(NoteName.F, ChordType.Dominant13th, null));
                _Catalog.Add(F7b5 = ChordFormulaFactory.Create(NoteName.F, ChordType.Dominant7b5, null));
                _Catalog.Add(F7b9 = ChordFormulaFactory.Create(NoteName.F, ChordType.Dominant7b9, null));
                _Catalog.Add(F7sharp9 = ChordFormulaFactory.Create(NoteName.F, ChordType.Dominant7Sharp9, null));
                #endregion NoteName.F

                #region NoteName.F♯
                _Catalog.Add(FSharpaug = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Augmented, null));
                _Catalog.Add(FSharpdim = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Diminished, null));
                _Catalog.Add(FSharpm7b5 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.HalfDiminished, null));
                _Catalog.Add(FSharpdim7 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Diminished7, null));
                _Catalog.Add(FSharpSus2 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Sus2, null));
                _Catalog.Add(FSharp7Sus2 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.SevenSus2, null));
                _Catalog.Add(FSharpSus4 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Sus4, null));
                _Catalog.Add(FSharp7Sus4 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.SevenSus4, null));
                _Catalog.Add(FSharpSus2Sus4 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Sus2Sus4, null));
                _Catalog.Add(FSharpm = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Minor, null));
                _Catalog.Add(FSharpm7 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Minor7th, null));
                _Catalog.Add(FSharpmM7 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.MinorMaj7th, null));
                _Catalog.Add(FSharpmMaj7aug5 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.MinorMaj7thAug5, null));
                _Catalog.Add(FSharpm6 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Minor6th, null));
                _Catalog.Add(FSharpm9 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Minor9th, null));
                _Catalog.Add(FSharpm11 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Minor11th, null));
                _Catalog.Add(FSharpm13 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Minor13th, null));
                _Catalog.Add(FSharpmAdd9 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.MinorAdd9, null));
                _Catalog.Add(FSharpMaj = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Major, null));
                _Catalog.Add(FSharp6 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Major6th, null));
                _Catalog.Add(FSharpMaj7 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Major7th, null));
                _Catalog.Add(FSharpMaj9 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Major9th, null));
                _Catalog.Add(FSharpMaj11 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Major11th, null));
                _Catalog.Add(FSharpMaj13 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Major13th, null));
                _Catalog.Add(FSharpAdd9 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.MajorAdd9, null));
                _Catalog.Add(FSharpMajMu = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.MajorMu, null));
                _Catalog.Add(FSharpMaj7b5 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Major7b5, null));
                _Catalog.Add(FSharpMaj7aug5 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Major7Aug5, null));
                _Catalog.Add(FSharp7 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Dominant7th, null));
                _Catalog.Add(FSharp9 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Dominant9th, null));
                _Catalog.Add(FSharp11 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Dominant11th, null));
                _Catalog.Add(FSharp13 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Dominant13th, null));
                _Catalog.Add(FSharp7b5 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Dominant7b5, null));
                _Catalog.Add(FSharp7b9 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Dominant7b9, null));
                _Catalog.Add(FSharp7sharp9 = ChordFormulaFactory.Create(NoteName.FSharp, ChordType.Dominant7Sharp9, null));
                #endregion NoteName.F♯

                #region NoteName.G♭
                _Catalog.Add(Gbaug = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Augmented, null));
                _Catalog.Add(Gbdim = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Diminished, null));
                _Catalog.Add(Gbm7b5 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.HalfDiminished, null));
                _Catalog.Add(Gbdim7 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Diminished7, null));
                _Catalog.Add(GbSus2 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Sus2, null));
                _Catalog.Add(Gb7Sus2 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.SevenSus2, null));
                _Catalog.Add(GbSus4 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Sus4, null));
                _Catalog.Add(Gb7Sus4 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.SevenSus4, null));
                _Catalog.Add(GbSus2Sus4 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Sus2Sus4, null));
                _Catalog.Add(Gbm = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Minor, null));
                _Catalog.Add(Gbm7 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Minor7th, null));
                _Catalog.Add(GbmM7 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.MinorMaj7th, null));
                _Catalog.Add(GbmMaj7aug5 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.MinorMaj7thAug5, null));
                _Catalog.Add(Gbm6 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Minor6th, null));
                _Catalog.Add(Gbm9 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Minor9th, null));
                _Catalog.Add(Gbm11 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Minor11th, null));
                _Catalog.Add(Gbm13 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Minor13th, null));
                _Catalog.Add(GbmAdd9 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.MinorAdd9, null));
                _Catalog.Add(GbMaj = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Major, null));
                _Catalog.Add(Gb6 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Major6th, null));
                _Catalog.Add(GbMaj7 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Major7th, null));
                _Catalog.Add(GbMaj9 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Major9th, null));
                _Catalog.Add(GbMaj11 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Major11th, null));
                _Catalog.Add(GbMaj13 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Major13th, null));
                _Catalog.Add(GbAdd9 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.MajorAdd9, null));
                _Catalog.Add(GbMajMu = ChordFormulaFactory.Create(NoteName.Gb, ChordType.MajorMu, null));
                _Catalog.Add(GbMaj7b5 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Major7b5, null));
                _Catalog.Add(GbMaj7aug5 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Major7Aug5, null));
                _Catalog.Add(Gb7 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Dominant7th, null));
                _Catalog.Add(Gb9 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Dominant9th, null));
                _Catalog.Add(Gb11 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Dominant11th, null));
                _Catalog.Add(Gb13 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Dominant13th, null));
                _Catalog.Add(Gb7b5 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Dominant7b5, null));
                _Catalog.Add(Gb7b9 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Dominant7b9, null));
                _Catalog.Add(Gb7sharp9 = ChordFormulaFactory.Create(NoteName.Gb, ChordType.Dominant7Sharp9, null));
                #endregion NoteName.G♭

                #region NoteName.G
                _Catalog.Add(Gaug = ChordFormulaFactory.Create(NoteName.G, ChordType.Augmented, null));
                _Catalog.Add(Gdim = ChordFormulaFactory.Create(NoteName.G, ChordType.Diminished, null));
                _Catalog.Add(Gm7b5 = ChordFormulaFactory.Create(NoteName.G, ChordType.HalfDiminished, null));
                _Catalog.Add(Gdim7 = ChordFormulaFactory.Create(NoteName.G, ChordType.Diminished7, null));
                _Catalog.Add(GSus2 = ChordFormulaFactory.Create(NoteName.G, ChordType.Sus2, null));
                _Catalog.Add(G7Sus2 = ChordFormulaFactory.Create(NoteName.G, ChordType.SevenSus2, null));
                _Catalog.Add(GSus4 = ChordFormulaFactory.Create(NoteName.G, ChordType.Sus4, null));
                _Catalog.Add(G7Sus4 = ChordFormulaFactory.Create(NoteName.G, ChordType.SevenSus4, null));
                _Catalog.Add(GSus2Sus4 = ChordFormulaFactory.Create(NoteName.G, ChordType.Sus2Sus4, null));
                _Catalog.Add(Gm = ChordFormulaFactory.Create(NoteName.G, ChordType.Minor, null));
                _Catalog.Add(Gm7 = ChordFormulaFactory.Create(NoteName.G, ChordType.Minor7th, null));
                _Catalog.Add(GmM7 = ChordFormulaFactory.Create(NoteName.G, ChordType.MinorMaj7th, null));
                _Catalog.Add(GmMaj7aug5 = ChordFormulaFactory.Create(NoteName.G, ChordType.MinorMaj7thAug5, null));
                _Catalog.Add(Gm6 = ChordFormulaFactory.Create(NoteName.G, ChordType.Minor6th, null));
                _Catalog.Add(Gm9 = ChordFormulaFactory.Create(NoteName.G, ChordType.Minor9th, null));
                _Catalog.Add(Gm11 = ChordFormulaFactory.Create(NoteName.G, ChordType.Minor11th, null));
                _Catalog.Add(Gm13 = ChordFormulaFactory.Create(NoteName.G, ChordType.Minor13th, null));
                _Catalog.Add(GmAdd9 = ChordFormulaFactory.Create(NoteName.G, ChordType.MinorAdd9, null));
                _Catalog.Add(GMaj = ChordFormulaFactory.Create(NoteName.G, ChordType.Major, null));
                _Catalog.Add(G6 = ChordFormulaFactory.Create(NoteName.G, ChordType.Major6th, null));
                _Catalog.Add(GMaj7 = ChordFormulaFactory.Create(NoteName.G, ChordType.Major7th, null));
                _Catalog.Add(GMaj9 = ChordFormulaFactory.Create(NoteName.G, ChordType.Major9th, null));
                _Catalog.Add(GMaj11 = ChordFormulaFactory.Create(NoteName.G, ChordType.Major11th, null));
                _Catalog.Add(GMaj13 = ChordFormulaFactory.Create(NoteName.G, ChordType.Major13th, null));
                _Catalog.Add(GAdd9 = ChordFormulaFactory.Create(NoteName.G, ChordType.MajorAdd9, null));
                _Catalog.Add(GMajMu = ChordFormulaFactory.Create(NoteName.G, ChordType.MajorMu, null));
                _Catalog.Add(GMaj7b5 = ChordFormulaFactory.Create(NoteName.G, ChordType.Major7b5, null));
                _Catalog.Add(GMaj7aug5 = ChordFormulaFactory.Create(NoteName.G, ChordType.Major7Aug5, null));
                _Catalog.Add(G7 = ChordFormulaFactory.Create(NoteName.G, ChordType.Dominant7th, null));
                _Catalog.Add(G9 = ChordFormulaFactory.Create(NoteName.G, ChordType.Dominant9th, null));
                _Catalog.Add(G11 = ChordFormulaFactory.Create(NoteName.G, ChordType.Dominant11th, null));
                _Catalog.Add(G13 = ChordFormulaFactory.Create(NoteName.G, ChordType.Dominant13th, null));
                _Catalog.Add(G7b5 = ChordFormulaFactory.Create(NoteName.G, ChordType.Dominant7b5, null));
                _Catalog.Add(G7b9 = ChordFormulaFactory.Create(NoteName.G, ChordType.Dominant7b9, null));
                _Catalog.Add(G7sharp9 = ChordFormulaFactory.Create(NoteName.G, ChordType.Dominant7Sharp9, null));
                #endregion NoteName.G

                #region NoteName.G♯
                _Catalog.Add(GSharpaug = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Augmented, null));
                _Catalog.Add(GSharpdim = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Diminished, null));
                _Catalog.Add(GSharpm7b5 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.HalfDiminished, null));
                _Catalog.Add(GSharpdim7 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Diminished7, null));
                _Catalog.Add(GSharpSus2 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Sus2, null));
                _Catalog.Add(GSharp7Sus2 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.SevenSus2, null));
                _Catalog.Add(GSharpSus4 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Sus4, null));
                _Catalog.Add(GSharp7Sus4 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.SevenSus4, null));
                _Catalog.Add(GSharpSus2Sus4 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Sus2Sus4, null));
                _Catalog.Add(GSharpm = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Minor, null));
                _Catalog.Add(GSharpm7 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Minor7th, null));
                _Catalog.Add(GSharpmM7 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.MinorMaj7th, null));
                _Catalog.Add(GSharpmMaj7aug5 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.MinorMaj7thAug5, null));
                _Catalog.Add(GSharpm6 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Minor6th, null));
                _Catalog.Add(GSharpm9 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Minor9th, null));
                _Catalog.Add(GSharpm11 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Minor11th, null));
                _Catalog.Add(GSharpm13 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Minor13th, null));
                _Catalog.Add(GSharpmAdd9 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.MinorAdd9, null));
                _Catalog.Add(GSharpMaj = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Major, null));
                _Catalog.Add(GSharp6 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Major6th, null));
                _Catalog.Add(GSharpMaj7 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Major7th, null));
                _Catalog.Add(GSharpMaj9 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Major9th, null));
                _Catalog.Add(GSharpMaj11 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Major11th, null));
                _Catalog.Add(GSharpMaj13 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Major13th, null));
                _Catalog.Add(GSharpAdd9 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.MajorAdd9, null));
                _Catalog.Add(GSharpMajMu = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.MajorMu, null));
                _Catalog.Add(GSharpMaj7b5 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Major7b5, null));
                _Catalog.Add(GSharpMaj7aug5 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Major7Aug5, null));
                _Catalog.Add(GSharp7 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Dominant7th, null));
                _Catalog.Add(GSharp9 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Dominant9th, null));
                _Catalog.Add(GSharp11 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Dominant11th, null));
                _Catalog.Add(GSharp13 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Dominant13th, null));
                _Catalog.Add(GSharp7b5 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Dominant7b5, null));
                _Catalog.Add(GSharp7b9 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Dominant7b9, null));
                _Catalog.Add(GSharp7sharp9 = ChordFormulaFactory.Create(NoteName.GSharp, ChordType.Dominant7Sharp9, null));
                #endregion NoteName.G♯

                #region NoteName.A♭
                _Catalog.Add(Abaug = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Augmented, null));
                _Catalog.Add(Abdim = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Diminished, null));
                _Catalog.Add(Abm7b5 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.HalfDiminished, null));
                _Catalog.Add(Abdim7 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Diminished7, null));
                _Catalog.Add(AbSus2 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Sus2, null));
                _Catalog.Add(Ab7Sus2 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.SevenSus2, null));
                _Catalog.Add(AbSus4 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Sus4, null));
                _Catalog.Add(Ab7Sus4 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.SevenSus4, null));
                _Catalog.Add(AbSus2Sus4 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Sus2Sus4, null));
                _Catalog.Add(Abm = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Minor, null));
                _Catalog.Add(Abm7 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Minor7th, null));
                _Catalog.Add(AbmM7 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.MinorMaj7th, null));
                _Catalog.Add(AbmMaj7aug5 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.MinorMaj7thAug5, null));
                _Catalog.Add(Abm6 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Minor6th, null));
                _Catalog.Add(Abm9 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Minor9th, null));
                _Catalog.Add(Abm11 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Minor11th, null));
                _Catalog.Add(Abm13 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Minor13th, null));
                _Catalog.Add(AbmAdd9 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.MinorAdd9, null));
                _Catalog.Add(AbMaj = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Major, null));
                _Catalog.Add(Ab6 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Major6th, null));
                _Catalog.Add(AbMaj7 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Major7th, null));
                _Catalog.Add(AbMaj9 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Major9th, null));
                _Catalog.Add(AbMaj11 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Major11th, null));
                _Catalog.Add(AbMaj13 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Major13th, null));
                _Catalog.Add(AbAdd9 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.MajorAdd9, null));
                _Catalog.Add(AbMajMu = ChordFormulaFactory.Create(NoteName.Ab, ChordType.MajorMu, null));
                _Catalog.Add(AbMaj7b5 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Major7b5, null));
                _Catalog.Add(AbMaj7aug5 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Major7Aug5, null));
                _Catalog.Add(Ab7 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Dominant7th, null));
                _Catalog.Add(Ab9 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Dominant9th, null));
                _Catalog.Add(Ab11 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Dominant11th, null));
                _Catalog.Add(Ab13 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Dominant13th, null));
                _Catalog.Add(Ab7b5 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Dominant7b5, null));
                _Catalog.Add(Ab7b9 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Dominant7b9, null));
                _Catalog.Add(Ab7sharp9 = ChordFormulaFactory.Create(NoteName.Ab, ChordType.Dominant7Sharp9, null));
                #endregion NoteName.A♭

                #region NoteName.A
                _Catalog.Add(Aaug = ChordFormulaFactory.Create(NoteName.A, ChordType.Augmented, null));
                _Catalog.Add(Adim = ChordFormulaFactory.Create(NoteName.A, ChordType.Diminished, null));
                _Catalog.Add(Am7b5 = ChordFormulaFactory.Create(NoteName.A, ChordType.HalfDiminished, null));
                _Catalog.Add(Adim7 = ChordFormulaFactory.Create(NoteName.A, ChordType.Diminished7, null));
                _Catalog.Add(ASus2 = ChordFormulaFactory.Create(NoteName.A, ChordType.Sus2, null));
                _Catalog.Add(A7Sus2 = ChordFormulaFactory.Create(NoteName.A, ChordType.SevenSus2, null));
                _Catalog.Add(ASus4 = ChordFormulaFactory.Create(NoteName.A, ChordType.Sus4, null));
                _Catalog.Add(A7Sus4 = ChordFormulaFactory.Create(NoteName.A, ChordType.SevenSus4, null));
                _Catalog.Add(ASus2Sus4 = ChordFormulaFactory.Create(NoteName.A, ChordType.Sus2Sus4, null));
                _Catalog.Add(Am = ChordFormulaFactory.Create(NoteName.A, ChordType.Minor, null));
                _Catalog.Add(Am7 = ChordFormulaFactory.Create(NoteName.A, ChordType.Minor7th, null));
                _Catalog.Add(AmM7 = ChordFormulaFactory.Create(NoteName.A, ChordType.MinorMaj7th, null));
                _Catalog.Add(AmMaj7aug5 = ChordFormulaFactory.Create(NoteName.A, ChordType.MinorMaj7thAug5, null));
                _Catalog.Add(Am6 = ChordFormulaFactory.Create(NoteName.A, ChordType.Minor6th, null));
                _Catalog.Add(Am9 = ChordFormulaFactory.Create(NoteName.A, ChordType.Minor9th, null));
                _Catalog.Add(Am11 = ChordFormulaFactory.Create(NoteName.A, ChordType.Minor11th, null));
                _Catalog.Add(Am13 = ChordFormulaFactory.Create(NoteName.A, ChordType.Minor13th, null));
                _Catalog.Add(AmAdd9 = ChordFormulaFactory.Create(NoteName.A, ChordType.MinorAdd9, null));
                _Catalog.Add(AMaj = ChordFormulaFactory.Create(NoteName.A, ChordType.Major, null));
                _Catalog.Add(A6 = ChordFormulaFactory.Create(NoteName.A, ChordType.Major6th, null));
                _Catalog.Add(AMaj7 = ChordFormulaFactory.Create(NoteName.A, ChordType.Major7th, null));
                _Catalog.Add(AMaj9 = ChordFormulaFactory.Create(NoteName.A, ChordType.Major9th, null));
                _Catalog.Add(AMaj11 = ChordFormulaFactory.Create(NoteName.A, ChordType.Major11th, null));
                _Catalog.Add(AMaj13 = ChordFormulaFactory.Create(NoteName.A, ChordType.Major13th, null));
                _Catalog.Add(AAdd9 = ChordFormulaFactory.Create(NoteName.A, ChordType.MajorAdd9, null));
                _Catalog.Add(AMajMu = ChordFormulaFactory.Create(NoteName.A, ChordType.MajorMu, null));
                _Catalog.Add(AMaj7b5 = ChordFormulaFactory.Create(NoteName.A, ChordType.Major7b5, null));
                _Catalog.Add(AMaj7aug5 = ChordFormulaFactory.Create(NoteName.A, ChordType.Major7Aug5, null));
                _Catalog.Add(A7 = ChordFormulaFactory.Create(NoteName.A, ChordType.Dominant7th, null));
                _Catalog.Add(A9 = ChordFormulaFactory.Create(NoteName.A, ChordType.Dominant9th, null));
                _Catalog.Add(A11 = ChordFormulaFactory.Create(NoteName.A, ChordType.Dominant11th, null));
                _Catalog.Add(A13 = ChordFormulaFactory.Create(NoteName.A, ChordType.Dominant13th, null));
                _Catalog.Add(A7b5 = ChordFormulaFactory.Create(NoteName.A, ChordType.Dominant7b5, null));
                _Catalog.Add(A7b9 = ChordFormulaFactory.Create(NoteName.A, ChordType.Dominant7b9, null));
                _Catalog.Add(A7sharp9 = ChordFormulaFactory.Create(NoteName.A, ChordType.Dominant7Sharp9, null));
                #endregion NoteName.A

                #region NoteName.A♯
                _Catalog.Add(ASharpaug = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Augmented, null));
                _Catalog.Add(ASharpdim = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Diminished, null));
                _Catalog.Add(ASharpm7b5 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.HalfDiminished, null));
                _Catalog.Add(ASharpdim7 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Diminished7, null));
                _Catalog.Add(ASharpSus2 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Sus2, null));
                _Catalog.Add(ASharp7Sus2 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.SevenSus2, null));
                _Catalog.Add(ASharpSus4 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Sus4, null));
                _Catalog.Add(ASharp7Sus4 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.SevenSus4, null));
                _Catalog.Add(ASharpSus2Sus4 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Sus2Sus4, null));
                _Catalog.Add(ASharpm = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Minor, null));
                _Catalog.Add(ASharpm7 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Minor7th, null));
                _Catalog.Add(ASharpmM7 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.MinorMaj7th, null));
                _Catalog.Add(ASharpmMaj7aug5 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.MinorMaj7thAug5, null));
                _Catalog.Add(ASharpm6 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Minor6th, null));
                _Catalog.Add(ASharpm9 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Minor9th, null));
                _Catalog.Add(ASharpm11 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Minor11th, null));
                _Catalog.Add(ASharpm13 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Minor13th, null));
                _Catalog.Add(ASharpmAdd9 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.MinorAdd9, null));
                _Catalog.Add(ASharpMaj = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Major, null));
                _Catalog.Add(ASharp6 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Major6th, null));
                _Catalog.Add(ASharpMaj7 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Major7th, null));
                _Catalog.Add(ASharpMaj9 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Major9th, null));
                _Catalog.Add(ASharpMaj11 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Major11th, null));
                _Catalog.Add(ASharpMaj13 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Major13th, null));
                _Catalog.Add(ASharpAdd9 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.MajorAdd9, null));
                _Catalog.Add(ASharpMajMu = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.MajorMu, null));
                _Catalog.Add(ASharpMaj7b5 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Major7b5, null));
                _Catalog.Add(ASharpMaj7aug5 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Major7Aug5, null));
                _Catalog.Add(ASharp7 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Dominant7th, null));
                _Catalog.Add(ASharp9 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Dominant9th, null));
                _Catalog.Add(ASharp11 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Dominant11th, null));
                _Catalog.Add(ASharp13 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Dominant13th, null));
                _Catalog.Add(ASharp7b5 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Dominant7b5, null));
                _Catalog.Add(ASharp7b9 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Dominant7b9, null));
                _Catalog.Add(ASharp7sharp9 = ChordFormulaFactory.Create(NoteName.ASharp, ChordType.Dominant7Sharp9, null));
                #endregion NoteName.A♯

                #region NoteName.B♭
                _Catalog.Add(Bbaug = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Augmented, null));
                _Catalog.Add(Bbdim = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Diminished, null));
                _Catalog.Add(Bbm7b5 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.HalfDiminished, null));
                _Catalog.Add(Bbdim7 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Diminished7, null));
                _Catalog.Add(BbSus2 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Sus2, null));
                _Catalog.Add(Bb7Sus2 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.SevenSus2, null));
                _Catalog.Add(BbSus4 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Sus4, null));
                _Catalog.Add(Bb7Sus4 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.SevenSus4, null));
                _Catalog.Add(BbSus2Sus4 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Sus2Sus4, null));
                _Catalog.Add(Bbm = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Minor, null));
                _Catalog.Add(Bbm7 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Minor7th, null));
                _Catalog.Add(BbmM7 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.MinorMaj7th, null));
                _Catalog.Add(BbmMaj7aug5 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.MinorMaj7thAug5, null));
                _Catalog.Add(Bbm6 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Minor6th, null));
                _Catalog.Add(Bbm9 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Minor9th, null));
                _Catalog.Add(Bbm11 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Minor11th, null));
                _Catalog.Add(Bbm13 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Minor13th, null));
                _Catalog.Add(BbmAdd9 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.MinorAdd9, null));
                _Catalog.Add(BbMaj = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Major, null));
                _Catalog.Add(Bb6 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Major6th, null));
                _Catalog.Add(BbMaj7 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Major7th, null));
                _Catalog.Add(BbMaj9 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Major9th, null));
                _Catalog.Add(BbMaj11 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Major11th, null));
                _Catalog.Add(BbMaj13 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Major13th, null));
                _Catalog.Add(BbAdd9 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.MajorAdd9, null));
                _Catalog.Add(BbMajMu = ChordFormulaFactory.Create(NoteName.Bb, ChordType.MajorMu, null));
                _Catalog.Add(BbMaj7b5 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Major7b5, null));
                _Catalog.Add(BbMaj7aug5 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Major7Aug5, null));
                _Catalog.Add(Bb7 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Dominant7th, null));
                _Catalog.Add(Bb9 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Dominant9th, null));
                _Catalog.Add(Bb11 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Dominant11th, null));
                _Catalog.Add(Bb13 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Dominant13th, null));
                _Catalog.Add(Bb7b5 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Dominant7b5, null));
                _Catalog.Add(Bb7b9 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Dominant7b9, null));
                _Catalog.Add(Bb7sharp9 = ChordFormulaFactory.Create(NoteName.Bb, ChordType.Dominant7Sharp9, null));
                #endregion NoteName.B♭

                #region NoteName.B
                _Catalog.Add(Baug = ChordFormulaFactory.Create(NoteName.B, ChordType.Augmented, null));
                _Catalog.Add(Bdim = ChordFormulaFactory.Create(NoteName.B, ChordType.Diminished, null));
                _Catalog.Add(Bm7b5 = ChordFormulaFactory.Create(NoteName.B, ChordType.HalfDiminished, null));
                _Catalog.Add(Bdim7 = ChordFormulaFactory.Create(NoteName.B, ChordType.Diminished7, null));
                _Catalog.Add(BSus2 = ChordFormulaFactory.Create(NoteName.B, ChordType.Sus2, null));
                _Catalog.Add(B7Sus2 = ChordFormulaFactory.Create(NoteName.B, ChordType.SevenSus2, null));
                _Catalog.Add(BSus4 = ChordFormulaFactory.Create(NoteName.B, ChordType.Sus4, null));
                _Catalog.Add(B7Sus4 = ChordFormulaFactory.Create(NoteName.B, ChordType.SevenSus4, null));
                _Catalog.Add(BSus2Sus4 = ChordFormulaFactory.Create(NoteName.B, ChordType.Sus2Sus4, null));
                _Catalog.Add(Bm = ChordFormulaFactory.Create(NoteName.B, ChordType.Minor, null));
                _Catalog.Add(Bm7 = ChordFormulaFactory.Create(NoteName.B, ChordType.Minor7th, null));
                _Catalog.Add(BmM7 = ChordFormulaFactory.Create(NoteName.B, ChordType.MinorMaj7th, null));
                _Catalog.Add(BmMaj7aug5 = ChordFormulaFactory.Create(NoteName.B, ChordType.MinorMaj7thAug5, null));
                _Catalog.Add(Bm6 = ChordFormulaFactory.Create(NoteName.B, ChordType.Minor6th, null));
                _Catalog.Add(Bm9 = ChordFormulaFactory.Create(NoteName.B, ChordType.Minor9th, null));
                _Catalog.Add(Bm11 = ChordFormulaFactory.Create(NoteName.B, ChordType.Minor11th, null));
                _Catalog.Add(Bm13 = ChordFormulaFactory.Create(NoteName.B, ChordType.Minor13th, null));
                _Catalog.Add(BmAdd9 = ChordFormulaFactory.Create(NoteName.B, ChordType.MinorAdd9, null));
                _Catalog.Add(BMaj = ChordFormulaFactory.Create(NoteName.B, ChordType.Major, null));
                _Catalog.Add(B6 = ChordFormulaFactory.Create(NoteName.B, ChordType.Major6th, null));
                _Catalog.Add(BMaj7 = ChordFormulaFactory.Create(NoteName.B, ChordType.Major7th, null));
                _Catalog.Add(BMaj9 = ChordFormulaFactory.Create(NoteName.B, ChordType.Major9th, null));
                _Catalog.Add(BMaj11 = ChordFormulaFactory.Create(NoteName.B, ChordType.Major11th, null));
                _Catalog.Add(BMaj13 = ChordFormulaFactory.Create(NoteName.B, ChordType.Major13th, null));
                _Catalog.Add(BAdd9 = ChordFormulaFactory.Create(NoteName.B, ChordType.MajorAdd9, null));
                _Catalog.Add(BMajMu = ChordFormulaFactory.Create(NoteName.B, ChordType.MajorMu, null));
                _Catalog.Add(BMaj7b5 = ChordFormulaFactory.Create(NoteName.B, ChordType.Major7b5, null));
                _Catalog.Add(BMaj7aug5 = ChordFormulaFactory.Create(NoteName.B, ChordType.Major7Aug5, null));
                _Catalog.Add(B7 = ChordFormulaFactory.Create(NoteName.B, ChordType.Dominant7th, null));
                _Catalog.Add(B9 = ChordFormulaFactory.Create(NoteName.B, ChordType.Dominant9th, null));
                _Catalog.Add(B11 = ChordFormulaFactory.Create(NoteName.B, ChordType.Dominant11th, null));
                _Catalog.Add(B13 = ChordFormulaFactory.Create(NoteName.B, ChordType.Dominant13th, null));
                _Catalog.Add(B7b5 = ChordFormulaFactory.Create(NoteName.B, ChordType.Dominant7b5, null));
                _Catalog.Add(B7b9 = ChordFormulaFactory.Create(NoteName.B, ChordType.Dominant7b9, null));
                _Catalog.Add(B7sharp9 = ChordFormulaFactory.Create(NoteName.B, ChordType.Dominant7Sharp9, null));
                #endregion NoteName.B

                #region NoteName.C♭
                _Catalog.Add(Cbaug = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Augmented, null));
                _Catalog.Add(Cbdim = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Diminished, null));
                _Catalog.Add(Cbm7b5 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.HalfDiminished, null));
                _Catalog.Add(Cbdim7 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Diminished7, null));
                _Catalog.Add(CbSus2 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Sus2, null));
                _Catalog.Add(Cb7Sus2 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.SevenSus2, null));
                _Catalog.Add(CbSus4 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Sus4, null));
                _Catalog.Add(Cb7Sus4 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.SevenSus4, null));
                _Catalog.Add(CbSus2Sus4 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Sus2Sus4, null));
                _Catalog.Add(Cbm = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Minor, null));
                _Catalog.Add(Cbm7 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Minor7th, null));
                _Catalog.Add(CbmM7 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.MinorMaj7th, null));
                _Catalog.Add(CbmMaj7aug5 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.MinorMaj7thAug5, null));
                _Catalog.Add(Cbm6 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Minor6th, null));
                _Catalog.Add(Cbm9 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Minor9th, null));
                _Catalog.Add(Cbm11 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Minor11th, null));
                _Catalog.Add(Cbm13 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Minor13th, null));
                _Catalog.Add(CbmAdd9 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.MinorAdd9, null));
                _Catalog.Add(CbMaj = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Major, null));
                _Catalog.Add(Cb6 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Major6th, null));
                _Catalog.Add(CbMaj7 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Major7th, null));
                _Catalog.Add(CbMaj9 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Major9th, null));
                _Catalog.Add(CbMaj11 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Major11th, null));
                _Catalog.Add(CbMaj13 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Major13th, null));
                _Catalog.Add(CbAdd9 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.MajorAdd9, null));
                _Catalog.Add(CbMajMu = ChordFormulaFactory.Create(NoteName.Cb, ChordType.MajorMu, null));
                _Catalog.Add(CbMaj7b5 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Major7b5, null));
                _Catalog.Add(CbMaj7aug5 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Major7Aug5, null));
                _Catalog.Add(Cb7 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Dominant7th, null));
                _Catalog.Add(Cb9 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Dominant9th, null));
                _Catalog.Add(Cb11 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Dominant11th, null));
                _Catalog.Add(Cb13 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Dominant13th, null));
                _Catalog.Add(Cb7b5 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Dominant7b5, null));
                _Catalog.Add(Cb7b9 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Dominant7b9, null));
                _Catalog.Add(Cb7sharp9 = ChordFormulaFactory.Create(NoteName.Cb, ChordType.Dominant7Sharp9, null));
                #endregion NoteName.C♭

                #endregion Instantiate static chord _Catalog.
            }
            catch (Exception)
            {

                throw;
            }
        }


        private static void GenerateCodeForStaticChord_Catalog()
        {
            var keySignatures = new List<KeySignature>();
            foreach (var key in KeySignature.InternalCatalog)
            {
                keySignatures.Add(key);
            }

            var chordTypes = new List<ChordType>();
            foreach (var ct in ChordType.Catalog)
            {
                chordTypes.Add(ct);
            }
            var noteNames = new List<NoteName>();
            foreach (var noteName in NoteName.Catalog)
            {
                noteNames.Add(noteName);
            }

            GenerateCodeForFieldDeclarations(keySignatures,
                chordTypes,
                noteNames);
            GenerateCode_ForPopulatingCatalog(keySignatures,
                chordTypes,
                noteNames);
            new object();
        }

        private static void GenerateCodeForFieldDeclarations(List<KeySignature> keySignatures,
            List<ChordType> chordTypes,
            List<NoteName> noteNames)
        {//static public readonly ChordFormula C7;
            Debug.WriteLine($"#region static Chords{Environment.NewLine}");

            foreach (var nn in noteNames)
            {
                var nnName = nn.Name.Replace("♭", "b")
                    .Replace("♯", "Sharp");

                foreach (var ct in chordTypes)
                {
                    if ((nn == NoteName.BSharp && ct == ChordType.Dominant7Sharp9)
                        || (nn == NoteName.ESharp && ct == ChordType.Dominant7Sharp9))
                    {// Don't generate chords with triple #s.
                    }
                    else 
                    {
                        var code = $"static public readonly ChordFormula {nnName}{ct};";
                        Debug.WriteLine(code);
                    }
                }
            }
            Debug.WriteLine($"#endregion static Chords{Environment.NewLine}");

        }

        private static void GenerateCode_ForPopulatingCatalog(List<KeySignature> keySignatures,
            List<ChordType> chordTypes,
            List<NoteName> noteNames)
        {//ChordFormula.AddToCatalog(NoteName.BSharp, ChordType.Augmented, null);
            Debug.WriteLine("#region Instantiate static chord _Catalog.");
            var nnTuples = GenerateCode_GetNoteNames_ForCode();
            foreach (var tuple in nnTuples)
            {
                var nn = tuple.Item1;
                var nnName = tuple.Item2;
                Debug.WriteLine($"#region NoteName.{nn}");

                foreach (var ct in chordTypes)
                {
                    var ctFieldName = string.Empty;
                    KeySignature key = null;
                    var ksName = "null";

                    //if (ct.IsDominant)
                    //{
                    //    var ksnn = nn + Interval.Perfect4th;
                    //    key = KeySignature.Catalog
                    //        .Where(x => x.IsMajor 
                    //        && x.NoteName == ksnn)
                    //        .FirstOrDefault();
                    //    if (key != null)
                    //    {
                    //        var fis = key.GetType().GetFields();
                    //        var fi = fis
                    //            .Where(x => (x.GetValue(null) as KeySignature).Name == key.Name)
                    //            .First();

                    //        var fieldName = fi.Name;
                    //        ksName = $"KeySignature.{fieldName}";
                    //        new object();
                    //    }
                    //}


                    #region get ct.FieldName
                    var ctfis = typeof(ChordType).GetFields();
                    var ctfi = ctfis
                        .Where(x => (x.GetValue(null) as ChordType).Name == ct.Name)
                        .First();

                    ctFieldName = ctfi.Name;

                    #endregion

                    //XXXX _Catalog.Add(C7 = ChordFormulaFactory.Create(NoteName.C, ChordType.Dominant7th, KeySignature.FMajor));
                    //ChordFormula.AddToCatalog(NoteName.BSharp, ChordType.Augmented, null);
                    if ((nn == NoteName.BSharp && ct == ChordType.Dominant7Sharp9)
                        || (nn == NoteName.ESharp && ct == ChordType.Dominant7Sharp9))
                    {// Don't generate chords with triple #s.
                    }
                    else
                    {
                        var code = $"_Catalog.Add({nnName}{ct} = ChordFormulaFactory.Create(NoteName.{nnName}, ChordType.{ctFieldName}, {ksName}));";

                        Debug.WriteLine(code);
                    }
                    new object();
                }
                Debug.WriteLine($"#endregion NoteName.{nn}{Environment.NewLine}");

            }
            Debug.WriteLine("#endregion Instantiate static chord _Catalog.");
            new object();
        }

        static List<Tuple<NoteName, string>> GenerateCode_GetNoteNames_ForCode()
        {
            var result = new List<Tuple<NoteName, string>>();
            foreach (var nn in NoteName.Catalog)
            {
                var nnName = nn.Name.Replace("♭", "b")
                    .Replace("♯", "Sharp");
                result.Add(new Tuple<NoteName, string>(nn, nnName));
            }
            return result;
        }

    }//class
}//ns
