﻿using Eric.Morrison.Harmony.Intervals;

using HarmonyHelper.Interfaces;

using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony.Chords
{
    public partial class ChordFormula
    {
        #region Catalog Properties
        static CatalogBase<ChordFormula> _Catalog { get; set; } = new CatalogBase<ChordFormula>();
        static CatalogBase<ChordFormula> _InternalCatalog { get; set; } = new CatalogBase<ChordFormula>();
        static public CatalogBase<ChordFormula> Catalog { get { return _Catalog; } }
        static public CatalogBase<ChordFormula> InternalCatalog { get { return _InternalCatalog; } }

        #endregion

        #region static Chords

        static public readonly ChordFormula BSharpAugmented;
        static public readonly ChordFormula BSharpDominant11;
        static public readonly ChordFormula BSharpDominant11b9;
        static public readonly ChordFormula BSharpDominant13;
        static public readonly ChordFormula BSharpDominant13Aug11;
        static public readonly ChordFormula BSharpDominant13b9;
        static public readonly ChordFormula BSharpMajor6;
        static public readonly ChordFormula BSharpDominant7;
        static public readonly ChordFormula BSharpDominant7Sharp5;
        static public readonly ChordFormula BSharpDominant7Sharp5b9;
        static public readonly ChordFormula BSharpDominant7Sharp5Nine;
        static public readonly ChordFormula BSharpDominant7b5;
        static public readonly ChordFormula BSharpDominant7b5Sharp9;
        static public readonly ChordFormula BSharpDominant7b5b9;
        static public readonly ChordFormula BSharpDominant7b9;
        static public readonly ChordFormula BSharpDominant7Sus2;
        static public readonly ChordFormula BSharpDominant7Sus4;
        static public readonly ChordFormula BSharpDominant9;
        static public readonly ChordFormula BSharpDiminished;
        static public readonly ChordFormula BSharpDiminished7;
        static public readonly ChordFormula BSharpMinor;
        static public readonly ChordFormula BSharpMinorAugmented;
        static public readonly ChordFormula BSharpMinor11;
        static public readonly ChordFormula BSharpMinor13;
        static public readonly ChordFormula BSharpMinor6;
        static public readonly ChordFormula BSharpMinor6Add9;
        static public readonly ChordFormula BSharpMinor7;
        static public readonly ChordFormula BSharpMinor7Sharp5;
        static public readonly ChordFormula BSharpMinor9;
        static public readonly ChordFormula BSharpMinorAdd9;
        static public readonly ChordFormula BSharpMajor;
        static public readonly ChordFormula BSharpMajor11;
        static public readonly ChordFormula BSharpMajor13;
        static public readonly ChordFormula BSharpMajor13Aug11;
        static public readonly ChordFormula BSharpMajor7;
        static public readonly ChordFormula BSharpMajor7Aug;
        static public readonly ChordFormula BSharpMajor7b5;
        static public readonly ChordFormula BSharpMajor9;
        static public readonly ChordFormula BSharpMajor9thSharp11;
        static public readonly ChordFormula BSharpMajorMu;
        static public readonly ChordFormula BSharpMinorMajor7;
        static public readonly ChordFormula BSharpMinorMajor7Aug;
        static public readonly ChordFormula BSharpMinorMajor9;
        static public readonly ChordFormula BSharpSus2Sus4;
        static public readonly ChordFormula BSharpSus2;
        static public readonly ChordFormula BSharpSus4;
        static public readonly ChordFormula CAugmented;
        static public readonly ChordFormula CDominant11;
        static public readonly ChordFormula CDominant11b9;
        static public readonly ChordFormula CDominant13;
        static public readonly ChordFormula CDominant13Aug11;
        static public readonly ChordFormula CDominant13b9;
        static public readonly ChordFormula CMajor6;
        static public readonly ChordFormula CDominant7;
        static public readonly ChordFormula CDominant7Sharp9;
        static public readonly ChordFormula CDominant7Sharp5;
        static public readonly ChordFormula CDominant7Sharp5b9;
        static public readonly ChordFormula CDominant7Sharp5Nine;
        static public readonly ChordFormula CDominant7b5;
        static public readonly ChordFormula CDominant7b5Sharp9;
        static public readonly ChordFormula CDominant7b5b9;
        static public readonly ChordFormula CDominant7b9;
        static public readonly ChordFormula CDominant7Sus2;
        static public readonly ChordFormula CDominant7Sus4;
        static public readonly ChordFormula CDominant9;
        static public readonly ChordFormula CDiminished;
        static public readonly ChordFormula CDiminished7;
        static public readonly ChordFormula CMinor;
        static public readonly ChordFormula CMinorAugmented;
        static public readonly ChordFormula CMinor11;
        static public readonly ChordFormula CMinor13;
        static public readonly ChordFormula CMinor6;
        static public readonly ChordFormula CMinor6Add9;
        static public readonly ChordFormula CMinor7;
        static public readonly ChordFormula CMinor7Sharp5;
        static public readonly ChordFormula CMinor9;
        static public readonly ChordFormula CMinorAdd9;
        static public readonly ChordFormula CMajor;
        static public readonly ChordFormula CMajor11;
        static public readonly ChordFormula CMajor13;
        static public readonly ChordFormula CMajor13Aug11;
        static public readonly ChordFormula CMajor7;
        static public readonly ChordFormula CMajor7Aug;
        static public readonly ChordFormula CMajor7b5;
        static public readonly ChordFormula CMajor9;
        static public readonly ChordFormula CMajor9thSharp11;
        static public readonly ChordFormula CMajorMu;
        static public readonly ChordFormula CMinorMajor7;
        static public readonly ChordFormula CMinorMajor7Aug;
        static public readonly ChordFormula CMinorMajor9;
        static public readonly ChordFormula CSus2Sus4;
        static public readonly ChordFormula CSus2;
        static public readonly ChordFormula CSus4;
        static public readonly ChordFormula CSharpAugmented;
        static public readonly ChordFormula CSharpDominant11;
        static public readonly ChordFormula CSharpDominant11b9;
        static public readonly ChordFormula CSharpDominant13;
        static public readonly ChordFormula CSharpDominant13Aug11;
        static public readonly ChordFormula CSharpDominant13b9;
        static public readonly ChordFormula CSharpMajor6;
        static public readonly ChordFormula CSharpDominant7;
        static public readonly ChordFormula CSharpDominant7Sharp9;
        static public readonly ChordFormula CSharpDominant7Sharp5;
        static public readonly ChordFormula CSharpDominant7Sharp5b9;
        static public readonly ChordFormula CSharpDominant7Sharp5Nine;
        static public readonly ChordFormula CSharpDominant7b5;
        static public readonly ChordFormula CSharpDominant7b5Sharp9;
        static public readonly ChordFormula CSharpDominant7b5b9;
        static public readonly ChordFormula CSharpDominant7b9;
        static public readonly ChordFormula CSharpDominant7Sus2;
        static public readonly ChordFormula CSharpDominant7Sus4;
        static public readonly ChordFormula CSharpDominant9;
        static public readonly ChordFormula CSharpDiminished;
        static public readonly ChordFormula CSharpDiminished7;
        static public readonly ChordFormula CSharpMinor;
        static public readonly ChordFormula CSharpMinorAugmented;
        static public readonly ChordFormula CSharpMinor11;
        static public readonly ChordFormula CSharpMinor13;
        static public readonly ChordFormula CSharpMinor6;
        static public readonly ChordFormula CSharpMinor6Add9;
        static public readonly ChordFormula CSharpMinor7;
        static public readonly ChordFormula CSharpMinor7Sharp5;
        static public readonly ChordFormula CSharpMinor9;
        static public readonly ChordFormula CSharpMinorAdd9;
        static public readonly ChordFormula CSharpMajor;
        static public readonly ChordFormula CSharpMajor11;
        static public readonly ChordFormula CSharpMajor13;
        static public readonly ChordFormula CSharpMajor13Aug11;
        static public readonly ChordFormula CSharpMajor7;
        static public readonly ChordFormula CSharpMajor7Aug;
        static public readonly ChordFormula CSharpMajor7b5;
        static public readonly ChordFormula CSharpMajor9;
        static public readonly ChordFormula CSharpMajor9thSharp11;
        static public readonly ChordFormula CSharpMajorMu;
        static public readonly ChordFormula CSharpMinorMajor7;
        static public readonly ChordFormula CSharpMinorMajor7Aug;
        static public readonly ChordFormula CSharpMinorMajor9;
        static public readonly ChordFormula CSharpSus2Sus4;
        static public readonly ChordFormula CSharpSus2;
        static public readonly ChordFormula CSharpSus4;
        static public readonly ChordFormula DbAugmented;
        static public readonly ChordFormula DbDominant11;
        static public readonly ChordFormula DbDominant11b9;
        static public readonly ChordFormula DbDominant13;
        static public readonly ChordFormula DbDominant13Aug11;
        static public readonly ChordFormula DbDominant13b9;
        static public readonly ChordFormula DbMajor6;
        static public readonly ChordFormula DbDominant7;
        static public readonly ChordFormula DbDominant7Sharp9;
        static public readonly ChordFormula DbDominant7Sharp5;
        static public readonly ChordFormula DbDominant7Sharp5b9;
        static public readonly ChordFormula DbDominant7Sharp5Nine;
        static public readonly ChordFormula DbDominant7b5;
        static public readonly ChordFormula DbDominant7b5Sharp9;
        static public readonly ChordFormula DbDominant7b5b9;
        static public readonly ChordFormula DbDominant7b9;
        static public readonly ChordFormula DbDominant7Sus2;
        static public readonly ChordFormula DbDominant7Sus4;
        static public readonly ChordFormula DbDominant9;
        static public readonly ChordFormula DbDiminished;
        static public readonly ChordFormula DbDiminished7;
        static public readonly ChordFormula DbMinor;
        static public readonly ChordFormula DbMinorAugmented;
        static public readonly ChordFormula DbMinor11;
        static public readonly ChordFormula DbMinor13;
        static public readonly ChordFormula DbMinor6;
        static public readonly ChordFormula DbMinor6Add9;
        static public readonly ChordFormula DbMinor7;
        static public readonly ChordFormula DbMinor7Sharp5;
        static public readonly ChordFormula DbMinor9;
        static public readonly ChordFormula DbMinorAdd9;
        static public readonly ChordFormula DbMajor;
        static public readonly ChordFormula DbMajor11;
        static public readonly ChordFormula DbMajor13;
        static public readonly ChordFormula DbMajor13Aug11;
        static public readonly ChordFormula DbMajor7;
        static public readonly ChordFormula DbMajor7Aug;
        static public readonly ChordFormula DbMajor7b5;
        static public readonly ChordFormula DbMajor9;
        static public readonly ChordFormula DbMajor9thSharp11;
        static public readonly ChordFormula DbMajorMu;
        static public readonly ChordFormula DbMinorMajor7;
        static public readonly ChordFormula DbMinorMajor7Aug;
        static public readonly ChordFormula DbMinorMajor9;
        static public readonly ChordFormula DbSus2Sus4;
        static public readonly ChordFormula DbSus2;
        static public readonly ChordFormula DbSus4;
        static public readonly ChordFormula DAugmented;
        static public readonly ChordFormula DDominant11;
        static public readonly ChordFormula DDominant11b9;
        static public readonly ChordFormula DDominant13;
        static public readonly ChordFormula DDominant13Aug11;
        static public readonly ChordFormula DDominant13b9;
        static public readonly ChordFormula DMajor6;
        static public readonly ChordFormula DDominant7;
        static public readonly ChordFormula DDominant7Sharp9;
        static public readonly ChordFormula DDominant7Sharp5;
        static public readonly ChordFormula DDominant7Sharp5b9;
        static public readonly ChordFormula DDominant7Sharp5Nine;
        static public readonly ChordFormula DDominant7b5;
        static public readonly ChordFormula DDominant7b5Sharp9;
        static public readonly ChordFormula DDominant7b5b9;
        static public readonly ChordFormula DDominant7b9;
        static public readonly ChordFormula DDominant7Sus2;
        static public readonly ChordFormula DDominant7Sus4;
        static public readonly ChordFormula DDominant9;
        static public readonly ChordFormula DDiminished;
        static public readonly ChordFormula DDiminished7;
        static public readonly ChordFormula DMinor;
        static public readonly ChordFormula DMinorAugmented;
        static public readonly ChordFormula DMinor11;
        static public readonly ChordFormula DMinor13;
        static public readonly ChordFormula DMinor6;
        static public readonly ChordFormula DMinor6Add9;
        static public readonly ChordFormula DMinor7;
        static public readonly ChordFormula DMinor7Sharp5;
        static public readonly ChordFormula DMinor9;
        static public readonly ChordFormula DMinorAdd9;
        static public readonly ChordFormula DMajor;
        static public readonly ChordFormula DMajor11;
        static public readonly ChordFormula DMajor13;
        static public readonly ChordFormula DMajor13Aug11;
        static public readonly ChordFormula DMajor7;
        static public readonly ChordFormula DMajor7Aug;
        static public readonly ChordFormula DMajor7b5;
        static public readonly ChordFormula DMajor9;
        static public readonly ChordFormula DMajor9thSharp11;
        static public readonly ChordFormula DMajorMu;
        static public readonly ChordFormula DMinorMajor7;
        static public readonly ChordFormula DMinorMajor7Aug;
        static public readonly ChordFormula DMinorMajor9;
        static public readonly ChordFormula DSus2Sus4;
        static public readonly ChordFormula DSus2;
        static public readonly ChordFormula DSus4;
        static public readonly ChordFormula DSharpAugmented;
        static public readonly ChordFormula DSharpDominant11;
        static public readonly ChordFormula DSharpDominant11b9;
        static public readonly ChordFormula DSharpDominant13;
        static public readonly ChordFormula DSharpDominant13Aug11;
        static public readonly ChordFormula DSharpDominant13b9;
        static public readonly ChordFormula DSharpMajor6;
        static public readonly ChordFormula DSharpDominant7;
        static public readonly ChordFormula DSharpDominant7Sharp9;
        static public readonly ChordFormula DSharpDominant7Sharp5;
        static public readonly ChordFormula DSharpDominant7Sharp5b9;
        static public readonly ChordFormula DSharpDominant7Sharp5Nine;
        static public readonly ChordFormula DSharpDominant7b5;
        static public readonly ChordFormula DSharpDominant7b5Sharp9;
        static public readonly ChordFormula DSharpDominant7b5b9;
        static public readonly ChordFormula DSharpDominant7b9;
        static public readonly ChordFormula DSharpDominant7Sus2;
        static public readonly ChordFormula DSharpDominant7Sus4;
        static public readonly ChordFormula DSharpDominant9;
        static public readonly ChordFormula DSharpDiminished;
        static public readonly ChordFormula DSharpDiminished7;
        static public readonly ChordFormula DSharpMinor;
        static public readonly ChordFormula DSharpMinorAugmented;
        static public readonly ChordFormula DSharpMinor11;
        static public readonly ChordFormula DSharpMinor13;
        static public readonly ChordFormula DSharpMinor6;
        static public readonly ChordFormula DSharpMinor6Add9;
        static public readonly ChordFormula DSharpMinor7;
        static public readonly ChordFormula DSharpMinor7Sharp5;
        static public readonly ChordFormula DSharpMinor9;
        static public readonly ChordFormula DSharpMinorAdd9;
        static public readonly ChordFormula DSharpMajor;
        static public readonly ChordFormula DSharpMajor11;
        static public readonly ChordFormula DSharpMajor13;
        static public readonly ChordFormula DSharpMajor13Aug11;
        static public readonly ChordFormula DSharpMajor7;
        static public readonly ChordFormula DSharpMajor7Aug;
        static public readonly ChordFormula DSharpMajor7b5;
        static public readonly ChordFormula DSharpMajor9;
        static public readonly ChordFormula DSharpMajor9thSharp11;
        static public readonly ChordFormula DSharpMajorMu;
        static public readonly ChordFormula DSharpMinorMajor7;
        static public readonly ChordFormula DSharpMinorMajor7Aug;
        static public readonly ChordFormula DSharpMinorMajor9;
        static public readonly ChordFormula DSharpSus2Sus4;
        static public readonly ChordFormula DSharpSus2;
        static public readonly ChordFormula DSharpSus4;
        static public readonly ChordFormula EbAugmented;
        static public readonly ChordFormula EbDominant11;
        static public readonly ChordFormula EbDominant11b9;
        static public readonly ChordFormula EbDominant13;
        static public readonly ChordFormula EbDominant13Aug11;
        static public readonly ChordFormula EbDominant13b9;
        static public readonly ChordFormula EbMajor6;
        static public readonly ChordFormula EbDominant7;
        static public readonly ChordFormula EbDominant7Sharp9;
        static public readonly ChordFormula EbDominant7Sharp5;
        static public readonly ChordFormula EbDominant7Sharp5b9;
        static public readonly ChordFormula EbDominant7Sharp5Nine;
        static public readonly ChordFormula EbDominant7b5;
        static public readonly ChordFormula EbDominant7b5Sharp9;
        static public readonly ChordFormula EbDominant7b5b9;
        static public readonly ChordFormula EbDominant7b9;
        static public readonly ChordFormula EbDominant7Sus2;
        static public readonly ChordFormula EbDominant7Sus4;
        static public readonly ChordFormula EbDominant9;
        static public readonly ChordFormula EbDiminished;
        static public readonly ChordFormula EbDiminished7;
        static public readonly ChordFormula EbMinor;
        static public readonly ChordFormula EbMinorAugmented;
        static public readonly ChordFormula EbMinor11;
        static public readonly ChordFormula EbMinor13;
        static public readonly ChordFormula EbMinor6;
        static public readonly ChordFormula EbMinor6Add9;
        static public readonly ChordFormula EbMinor7;
        static public readonly ChordFormula EbMinor7Sharp5;
        static public readonly ChordFormula EbMinor9;
        static public readonly ChordFormula EbMinorAdd9;
        static public readonly ChordFormula EbMajor;
        static public readonly ChordFormula EbMajor11;
        static public readonly ChordFormula EbMajor13;
        static public readonly ChordFormula EbMajor13Aug11;
        static public readonly ChordFormula EbMajor7;
        static public readonly ChordFormula EbMajor7Aug;
        static public readonly ChordFormula EbMajor7b5;
        static public readonly ChordFormula EbMajor9;
        static public readonly ChordFormula EbMajor9thSharp11;
        static public readonly ChordFormula EbMajorMu;
        static public readonly ChordFormula EbMinorMajor7;
        static public readonly ChordFormula EbMinorMajor7Aug;
        static public readonly ChordFormula EbMinorMajor9;
        static public readonly ChordFormula EbSus2Sus4;
        static public readonly ChordFormula EbSus2;
        static public readonly ChordFormula EbSus4;
        static public readonly ChordFormula EAugmented;
        static public readonly ChordFormula EDominant11;
        static public readonly ChordFormula EDominant11b9;
        static public readonly ChordFormula EDominant13;
        static public readonly ChordFormula EDominant13Aug11;
        static public readonly ChordFormula EDominant13b9;
        static public readonly ChordFormula EMajor6;
        static public readonly ChordFormula EDominant7;
        static public readonly ChordFormula EDominant7Sharp9;
        static public readonly ChordFormula EDominant7Sharp5;
        static public readonly ChordFormula EDominant7Sharp5b9;
        static public readonly ChordFormula EDominant7Sharp5Nine;
        static public readonly ChordFormula EDominant7b5;
        static public readonly ChordFormula EDominant7b5Sharp9;
        static public readonly ChordFormula EDominant7b5b9;
        static public readonly ChordFormula EDominant7b9;
        static public readonly ChordFormula EDominant7Sus2;
        static public readonly ChordFormula EDominant7Sus4;
        static public readonly ChordFormula EDominant9;
        static public readonly ChordFormula EDiminished;
        static public readonly ChordFormula EDiminished7;
        static public readonly ChordFormula EMinor;
        static public readonly ChordFormula EMinorAugmented;
        static public readonly ChordFormula EMinor11;
        static public readonly ChordFormula EMinor13;
        static public readonly ChordFormula EMinor6;
        static public readonly ChordFormula EMinor6Add9;
        static public readonly ChordFormula EMinor7;
        static public readonly ChordFormula EMinor7Sharp5;
        static public readonly ChordFormula EMinor9;
        static public readonly ChordFormula EMinorAdd9;
        static public readonly ChordFormula EMajor;
        static public readonly ChordFormula EMajor11;
        static public readonly ChordFormula EMajor13;
        static public readonly ChordFormula EMajor13Aug11;
        static public readonly ChordFormula EMajor7;
        static public readonly ChordFormula EMajor7Aug;
        static public readonly ChordFormula EMajor7b5;
        static public readonly ChordFormula EMajor9;
        static public readonly ChordFormula EMajor9thSharp11;
        static public readonly ChordFormula EMajorMu;
        static public readonly ChordFormula EMinorMajor7;
        static public readonly ChordFormula EMinorMajor7Aug;
        static public readonly ChordFormula EMinorMajor9;
        static public readonly ChordFormula ESus2Sus4;
        static public readonly ChordFormula ESus2;
        static public readonly ChordFormula ESus4;
        static public readonly ChordFormula FbAugmented;
        static public readonly ChordFormula FbDominant11;
        static public readonly ChordFormula FbDominant11b9;
        static public readonly ChordFormula FbDominant13;
        static public readonly ChordFormula FbDominant13Aug11;
        static public readonly ChordFormula FbDominant13b9;
        static public readonly ChordFormula FbMajor6;
        static public readonly ChordFormula FbDominant7;
        static public readonly ChordFormula FbDominant7Sharp9;
        static public readonly ChordFormula FbDominant7Sharp5;
        static public readonly ChordFormula FbDominant7Sharp5b9;
        static public readonly ChordFormula FbDominant7Sharp5Nine;
        static public readonly ChordFormula FbDominant7b5;
        static public readonly ChordFormula FbDominant7b5Sharp9;
        static public readonly ChordFormula FbDominant7b5b9;
        static public readonly ChordFormula FbDominant7b9;
        static public readonly ChordFormula FbDominant7Sus2;
        static public readonly ChordFormula FbDominant7Sus4;
        static public readonly ChordFormula FbDominant9;
        static public readonly ChordFormula FbDiminished;
        static public readonly ChordFormula FbDiminished7;
        static public readonly ChordFormula FbMinor;
        static public readonly ChordFormula FbMinorAugmented;
        static public readonly ChordFormula FbMinor11;
        static public readonly ChordFormula FbMinor13;
        static public readonly ChordFormula FbMinor6;
        static public readonly ChordFormula FbMinor6Add9;
        static public readonly ChordFormula FbMinor7;
        static public readonly ChordFormula FbMinor7Sharp5;
        static public readonly ChordFormula FbMinor9;
        static public readonly ChordFormula FbMinorAdd9;
        static public readonly ChordFormula FbMajor;
        static public readonly ChordFormula FbMajor11;
        static public readonly ChordFormula FbMajor13;
        static public readonly ChordFormula FbMajor13Aug11;
        static public readonly ChordFormula FbMajor7;
        static public readonly ChordFormula FbMajor7Aug;
        static public readonly ChordFormula FbMajor7b5;
        static public readonly ChordFormula FbMajor9;
        static public readonly ChordFormula FbMajor9thSharp11;
        static public readonly ChordFormula FbMajorMu;
        static public readonly ChordFormula FbMinorMajor7;
        static public readonly ChordFormula FbMinorMajor7Aug;
        static public readonly ChordFormula FbMinorMajor9;
        static public readonly ChordFormula FbSus2Sus4;
        static public readonly ChordFormula FbSus2;
        static public readonly ChordFormula FbSus4;
        static public readonly ChordFormula ESharpAugmented;
        static public readonly ChordFormula ESharpDominant11;
        static public readonly ChordFormula ESharpDominant11b9;
        static public readonly ChordFormula ESharpDominant13;
        static public readonly ChordFormula ESharpDominant13Aug11;
        static public readonly ChordFormula ESharpDominant13b9;
        static public readonly ChordFormula ESharpMajor6;
        static public readonly ChordFormula ESharpDominant7;
        static public readonly ChordFormula ESharpDominant7Sharp5;
        static public readonly ChordFormula ESharpDominant7Sharp5b9;
        static public readonly ChordFormula ESharpDominant7Sharp5Nine;
        static public readonly ChordFormula ESharpDominant7b5;
        static public readonly ChordFormula ESharpDominant7b5Sharp9;
        static public readonly ChordFormula ESharpDominant7b5b9;
        static public readonly ChordFormula ESharpDominant7b9;
        static public readonly ChordFormula ESharpDominant7Sus2;
        static public readonly ChordFormula ESharpDominant7Sus4;
        static public readonly ChordFormula ESharpDominant9;
        static public readonly ChordFormula ESharpDiminished;
        static public readonly ChordFormula ESharpDiminished7;
        static public readonly ChordFormula ESharpMinor;
        static public readonly ChordFormula ESharpMinorAugmented;
        static public readonly ChordFormula ESharpMinor11;
        static public readonly ChordFormula ESharpMinor13;
        static public readonly ChordFormula ESharpMinor6;
        static public readonly ChordFormula ESharpMinor6Add9;
        static public readonly ChordFormula ESharpMinor7;
        static public readonly ChordFormula ESharpMinor7Sharp5;
        static public readonly ChordFormula ESharpMinor9;
        static public readonly ChordFormula ESharpMinorAdd9;
        static public readonly ChordFormula ESharpMajor;
        static public readonly ChordFormula ESharpMajor11;
        static public readonly ChordFormula ESharpMajor13;
        static public readonly ChordFormula ESharpMajor13Aug11;
        static public readonly ChordFormula ESharpMajor7;
        static public readonly ChordFormula ESharpMajor7Aug;
        static public readonly ChordFormula ESharpMajor7b5;
        static public readonly ChordFormula ESharpMajor9;
        static public readonly ChordFormula ESharpMajor9thSharp11;
        static public readonly ChordFormula ESharpMajorMu;
        static public readonly ChordFormula ESharpMinorMajor7;
        static public readonly ChordFormula ESharpMinorMajor7Aug;
        static public readonly ChordFormula ESharpMinorMajor9;
        static public readonly ChordFormula ESharpSus2Sus4;
        static public readonly ChordFormula ESharpSus2;
        static public readonly ChordFormula ESharpSus4;
        static public readonly ChordFormula FAugmented;
        static public readonly ChordFormula FDominant11;
        static public readonly ChordFormula FDominant11b9;
        static public readonly ChordFormula FDominant13;
        static public readonly ChordFormula FDominant13Aug11;
        static public readonly ChordFormula FDominant13b9;
        static public readonly ChordFormula FMajor6;
        static public readonly ChordFormula FDominant7;
        static public readonly ChordFormula FDominant7Sharp9;
        static public readonly ChordFormula FDominant7Sharp5;
        static public readonly ChordFormula FDominant7Sharp5b9;
        static public readonly ChordFormula FDominant7Sharp5Nine;
        static public readonly ChordFormula FDominant7b5;
        static public readonly ChordFormula FDominant7b5Sharp9;
        static public readonly ChordFormula FDominant7b5b9;
        static public readonly ChordFormula FDominant7b9;
        static public readonly ChordFormula FDominant7Sus2;
        static public readonly ChordFormula FDominant7Sus4;
        static public readonly ChordFormula FDominant9;
        static public readonly ChordFormula FDiminished;
        static public readonly ChordFormula FDiminished7;
        static public readonly ChordFormula FMinor;
        static public readonly ChordFormula FMinorAugmented;
        static public readonly ChordFormula FMinor11;
        static public readonly ChordFormula FMinor13;
        static public readonly ChordFormula FMinor6;
        static public readonly ChordFormula FMinor6Add9;
        static public readonly ChordFormula FMinor7;
        static public readonly ChordFormula FMinor7Sharp5;
        static public readonly ChordFormula FMinor9;
        static public readonly ChordFormula FMinorAdd9;
        static public readonly ChordFormula FMajor;
        static public readonly ChordFormula FMajor11;
        static public readonly ChordFormula FMajor13;
        static public readonly ChordFormula FMajor13Aug11;
        static public readonly ChordFormula FMajor7;
        static public readonly ChordFormula FMajor7Aug;
        static public readonly ChordFormula FMajor7b5;
        static public readonly ChordFormula FMajor9;
        static public readonly ChordFormula FMajor9thSharp11;
        static public readonly ChordFormula FMajorMu;
        static public readonly ChordFormula FMinorMajor7;
        static public readonly ChordFormula FMinorMajor7Aug;
        static public readonly ChordFormula FMinorMajor9;
        static public readonly ChordFormula FSus2Sus4;
        static public readonly ChordFormula FSus2;
        static public readonly ChordFormula FSus4;
        static public readonly ChordFormula FSharpAugmented;
        static public readonly ChordFormula FSharpDominant11;
        static public readonly ChordFormula FSharpDominant11b9;
        static public readonly ChordFormula FSharpDominant13;
        static public readonly ChordFormula FSharpDominant13Aug11;
        static public readonly ChordFormula FSharpDominant13b9;
        static public readonly ChordFormula FSharpMajor6;
        static public readonly ChordFormula FSharpDominant7;
        static public readonly ChordFormula FSharpDominant7Sharp9;
        static public readonly ChordFormula FSharpDominant7Sharp5;
        static public readonly ChordFormula FSharpDominant7Sharp5b9;
        static public readonly ChordFormula FSharpDominant7Sharp5Nine;
        static public readonly ChordFormula FSharpDominant7b5;
        static public readonly ChordFormula FSharpDominant7b5Sharp9;
        static public readonly ChordFormula FSharpDominant7b5b9;
        static public readonly ChordFormula FSharpDominant7b9;
        static public readonly ChordFormula FSharpDominant7Sus2;
        static public readonly ChordFormula FSharpDominant7Sus4;
        static public readonly ChordFormula FSharpDominant9;
        static public readonly ChordFormula FSharpDiminished;
        static public readonly ChordFormula FSharpDiminished7;
        static public readonly ChordFormula FSharpMinor;
        static public readonly ChordFormula FSharpMinorAugmented;
        static public readonly ChordFormula FSharpMinor11;
        static public readonly ChordFormula FSharpMinor13;
        static public readonly ChordFormula FSharpMinor6;
        static public readonly ChordFormula FSharpMinor6Add9;
        static public readonly ChordFormula FSharpMinor7;
        static public readonly ChordFormula FSharpMinor7Sharp5;
        static public readonly ChordFormula FSharpMinor9;
        static public readonly ChordFormula FSharpMinorAdd9;
        static public readonly ChordFormula FSharpMajor;
        static public readonly ChordFormula FSharpMajor11;
        static public readonly ChordFormula FSharpMajor13;
        static public readonly ChordFormula FSharpMajor13Aug11;
        static public readonly ChordFormula FSharpMajor7;
        static public readonly ChordFormula FSharpMajor7Aug;
        static public readonly ChordFormula FSharpMajor7b5;
        static public readonly ChordFormula FSharpMajor9;
        static public readonly ChordFormula FSharpMajor9thSharp11;
        static public readonly ChordFormula FSharpMajorMu;
        static public readonly ChordFormula FSharpMinorMajor7;
        static public readonly ChordFormula FSharpMinorMajor7Aug;
        static public readonly ChordFormula FSharpMinorMajor9;
        static public readonly ChordFormula FSharpSus2Sus4;
        static public readonly ChordFormula FSharpSus2;
        static public readonly ChordFormula FSharpSus4;
        static public readonly ChordFormula GbAugmented;
        static public readonly ChordFormula GbDominant11;
        static public readonly ChordFormula GbDominant11b9;
        static public readonly ChordFormula GbDominant13;
        static public readonly ChordFormula GbDominant13Aug11;
        static public readonly ChordFormula GbDominant13b9;
        static public readonly ChordFormula GbMajor6;
        static public readonly ChordFormula GbDominant7;
        static public readonly ChordFormula GbDominant7Sharp9;
        static public readonly ChordFormula GbDominant7Sharp5;
        static public readonly ChordFormula GbDominant7Sharp5b9;
        static public readonly ChordFormula GbDominant7Sharp5Nine;
        static public readonly ChordFormula GbDominant7b5;
        static public readonly ChordFormula GbDominant7b5Sharp9;
        static public readonly ChordFormula GbDominant7b5b9;
        static public readonly ChordFormula GbDominant7b9;
        static public readonly ChordFormula GbDominant7Sus2;
        static public readonly ChordFormula GbDominant7Sus4;
        static public readonly ChordFormula GbDominant9;
        static public readonly ChordFormula GbDiminished;
        static public readonly ChordFormula GbDiminished7;
        static public readonly ChordFormula GbMinor;
        static public readonly ChordFormula GbMinorAugmented;
        static public readonly ChordFormula GbMinor11;
        static public readonly ChordFormula GbMinor13;
        static public readonly ChordFormula GbMinor6;
        static public readonly ChordFormula GbMinor6Add9;
        static public readonly ChordFormula GbMinor7;
        static public readonly ChordFormula GbMinor7Sharp5;
        static public readonly ChordFormula GbMinor9;
        static public readonly ChordFormula GbMinorAdd9;
        static public readonly ChordFormula GbMajor;
        static public readonly ChordFormula GbMajor11;
        static public readonly ChordFormula GbMajor13;
        static public readonly ChordFormula GbMajor13Aug11;
        static public readonly ChordFormula GbMajor7;
        static public readonly ChordFormula GbMajor7Aug;
        static public readonly ChordFormula GbMajor7b5;
        static public readonly ChordFormula GbMajor9;
        static public readonly ChordFormula GbMajor9thSharp11;
        static public readonly ChordFormula GbMajorMu;
        static public readonly ChordFormula GbMinorMajor7;
        static public readonly ChordFormula GbMinorMajor7Aug;
        static public readonly ChordFormula GbMinorMajor9;
        static public readonly ChordFormula GbSus2Sus4;
        static public readonly ChordFormula GbSus2;
        static public readonly ChordFormula GbSus4;
        static public readonly ChordFormula GAugmented;
        static public readonly ChordFormula GDominant11;
        static public readonly ChordFormula GDominant11b9;
        static public readonly ChordFormula GDominant13;
        static public readonly ChordFormula GDominant13Aug11;
        static public readonly ChordFormula GDominant13b9;
        static public readonly ChordFormula GMajor6;
        static public readonly ChordFormula GDominant7;
        static public readonly ChordFormula GDominant7Sharp9;
        static public readonly ChordFormula GDominant7Sharp5;
        static public readonly ChordFormula GDominant7Sharp5b9;
        static public readonly ChordFormula GDominant7Sharp5Nine;
        static public readonly ChordFormula GDominant7b5;
        static public readonly ChordFormula GDominant7b5Sharp9;
        static public readonly ChordFormula GDominant7b5b9;
        static public readonly ChordFormula GDominant7b9;
        static public readonly ChordFormula GDominant7Sus2;
        static public readonly ChordFormula GDominant7Sus4;
        static public readonly ChordFormula GDominant9;
        static public readonly ChordFormula GDiminished;
        static public readonly ChordFormula GDiminished7;
        static public readonly ChordFormula GMinor;
        static public readonly ChordFormula GMinorAugmented;
        static public readonly ChordFormula GMinor11;
        static public readonly ChordFormula GMinor13;
        static public readonly ChordFormula GMinor6;
        static public readonly ChordFormula GMinor6Add9;
        static public readonly ChordFormula GMinor7;
        static public readonly ChordFormula GMinor7Sharp5;
        static public readonly ChordFormula GMinor9;
        static public readonly ChordFormula GMinorAdd9;
        static public readonly ChordFormula GMajor;
        static public readonly ChordFormula GMajor11;
        static public readonly ChordFormula GMajor13;
        static public readonly ChordFormula GMajor13Aug11;
        static public readonly ChordFormula GMajor7;
        static public readonly ChordFormula GMajor7Aug;
        static public readonly ChordFormula GMajor7b5;
        static public readonly ChordFormula GMajor9;
        static public readonly ChordFormula GMajor9thSharp11;
        static public readonly ChordFormula GMajorMu;
        static public readonly ChordFormula GMinorMajor7;
        static public readonly ChordFormula GMinorMajor7Aug;
        static public readonly ChordFormula GMinorMajor9;
        static public readonly ChordFormula GSus2Sus4;
        static public readonly ChordFormula GSus2;
        static public readonly ChordFormula GSus4;
        static public readonly ChordFormula GSharpAugmented;
        static public readonly ChordFormula GSharpDominant11;
        static public readonly ChordFormula GSharpDominant11b9;
        static public readonly ChordFormula GSharpDominant13;
        static public readonly ChordFormula GSharpDominant13Aug11;
        static public readonly ChordFormula GSharpDominant13b9;
        static public readonly ChordFormula GSharpMajor6;
        static public readonly ChordFormula GSharpDominant7;
        static public readonly ChordFormula GSharpDominant7Sharp9;
        static public readonly ChordFormula GSharpDominant7Sharp5;
        static public readonly ChordFormula GSharpDominant7Sharp5b9;
        static public readonly ChordFormula GSharpDominant7Sharp5Nine;
        static public readonly ChordFormula GSharpDominant7b5;
        static public readonly ChordFormula GSharpDominant7b5Sharp9;
        static public readonly ChordFormula GSharpDominant7b5b9;
        static public readonly ChordFormula GSharpDominant7b9;
        static public readonly ChordFormula GSharpDominant7Sus2;
        static public readonly ChordFormula GSharpDominant7Sus4;
        static public readonly ChordFormula GSharpDominant9;
        static public readonly ChordFormula GSharpDiminished;
        static public readonly ChordFormula GSharpDiminished7;
        static public readonly ChordFormula GSharpMinor;
        static public readonly ChordFormula GSharpMinorAugmented;
        static public readonly ChordFormula GSharpMinor11;
        static public readonly ChordFormula GSharpMinor13;
        static public readonly ChordFormula GSharpMinor6;
        static public readonly ChordFormula GSharpMinor6Add9;
        static public readonly ChordFormula GSharpMinor7;
        static public readonly ChordFormula GSharpMinor7Sharp5;
        static public readonly ChordFormula GSharpMinor9;
        static public readonly ChordFormula GSharpMinorAdd9;
        static public readonly ChordFormula GSharpMajor;
        static public readonly ChordFormula GSharpMajor11;
        static public readonly ChordFormula GSharpMajor13;
        static public readonly ChordFormula GSharpMajor13Aug11;
        static public readonly ChordFormula GSharpMajor7;
        static public readonly ChordFormula GSharpMajor7Aug;
        static public readonly ChordFormula GSharpMajor7b5;
        static public readonly ChordFormula GSharpMajor9;
        static public readonly ChordFormula GSharpMajor9thSharp11;
        static public readonly ChordFormula GSharpMajorMu;
        static public readonly ChordFormula GSharpMinorMajor7;
        static public readonly ChordFormula GSharpMinorMajor7Aug;
        static public readonly ChordFormula GSharpMinorMajor9;
        static public readonly ChordFormula GSharpSus2Sus4;
        static public readonly ChordFormula GSharpSus2;
        static public readonly ChordFormula GSharpSus4;
        static public readonly ChordFormula AbAugmented;
        static public readonly ChordFormula AbDominant11;
        static public readonly ChordFormula AbDominant11b9;
        static public readonly ChordFormula AbDominant13;
        static public readonly ChordFormula AbDominant13Aug11;
        static public readonly ChordFormula AbDominant13b9;
        static public readonly ChordFormula AbMajor6;
        static public readonly ChordFormula AbDominant7;
        static public readonly ChordFormula AbDominant7Sharp9;
        static public readonly ChordFormula AbDominant7Sharp5;
        static public readonly ChordFormula AbDominant7Sharp5b9;
        static public readonly ChordFormula AbDominant7Sharp5Nine;
        static public readonly ChordFormula AbDominant7b5;
        static public readonly ChordFormula AbDominant7b5Sharp9;
        static public readonly ChordFormula AbDominant7b5b9;
        static public readonly ChordFormula AbDominant7b9;
        static public readonly ChordFormula AbDominant7Sus2;
        static public readonly ChordFormula AbDominant7Sus4;
        static public readonly ChordFormula AbDominant9;
        static public readonly ChordFormula AbDiminished;
        static public readonly ChordFormula AbDiminished7;
        static public readonly ChordFormula AbMinor;
        static public readonly ChordFormula AbMinorAugmented;
        static public readonly ChordFormula AbMinor11;
        static public readonly ChordFormula AbMinor13;
        static public readonly ChordFormula AbMinor6;
        static public readonly ChordFormula AbMinor6Add9;
        static public readonly ChordFormula AbMinor7;
        static public readonly ChordFormula AbMinor7Sharp5;
        static public readonly ChordFormula AbMinor9;
        static public readonly ChordFormula AbMinorAdd9;
        static public readonly ChordFormula AbMajor;
        static public readonly ChordFormula AbMajor11;
        static public readonly ChordFormula AbMajor13;
        static public readonly ChordFormula AbMajor13Aug11;
        static public readonly ChordFormula AbMajor7;
        static public readonly ChordFormula AbMajor7Aug;
        static public readonly ChordFormula AbMajor7b5;
        static public readonly ChordFormula AbMajor9;
        static public readonly ChordFormula AbMajor9thSharp11;
        static public readonly ChordFormula AbMajorMu;
        static public readonly ChordFormula AbMinorMajor7;
        static public readonly ChordFormula AbMinorMajor7Aug;
        static public readonly ChordFormula AbMinorMajor9;
        static public readonly ChordFormula AbSus2Sus4;
        static public readonly ChordFormula AbSus2;
        static public readonly ChordFormula AbSus4;
        static public readonly ChordFormula AAugmented;
        static public readonly ChordFormula ADominant11;
        static public readonly ChordFormula ADominant11b9;
        static public readonly ChordFormula ADominant13;
        static public readonly ChordFormula ADominant13Aug11;
        static public readonly ChordFormula ADominant13b9;
        static public readonly ChordFormula AMajor6;
        static public readonly ChordFormula ADominant7;
        static public readonly ChordFormula ADominant7Sharp9;
        static public readonly ChordFormula ADominant7Sharp5;
        static public readonly ChordFormula ADominant7Sharp5b9;
        static public readonly ChordFormula ADominant7Sharp5Nine;
        static public readonly ChordFormula ADominant7b5;
        static public readonly ChordFormula ADominant7b5Sharp9;
        static public readonly ChordFormula ADominant7b5b9;
        static public readonly ChordFormula ADominant7b9;
        static public readonly ChordFormula ADominant7Sus2;
        static public readonly ChordFormula ADominant7Sus4;
        static public readonly ChordFormula ADominant9;
        static public readonly ChordFormula ADiminished;
        static public readonly ChordFormula ADiminished7;
        static public readonly ChordFormula AMinor;
        static public readonly ChordFormula AMinorAugmented;
        static public readonly ChordFormula AMinor11;
        static public readonly ChordFormula AMinor13;
        static public readonly ChordFormula AMinor6;
        static public readonly ChordFormula AMinor6Add9;
        static public readonly ChordFormula AMinor7;
        static public readonly ChordFormula AMinor7Sharp5;
        static public readonly ChordFormula AMinor9;
        static public readonly ChordFormula AMinorAdd9;
        static public readonly ChordFormula AMajor;
        static public readonly ChordFormula AMajor11;
        static public readonly ChordFormula AMajor13;
        static public readonly ChordFormula AMajor13Aug11;
        static public readonly ChordFormula AMajor7;
        static public readonly ChordFormula AMajor7Aug;
        static public readonly ChordFormula AMajor7b5;
        static public readonly ChordFormula AMajor9;
        static public readonly ChordFormula AMajor9thSharp11;
        static public readonly ChordFormula AMajorMu;
        static public readonly ChordFormula AMinorMajor7;
        static public readonly ChordFormula AMinorMajor7Aug;
        static public readonly ChordFormula AMinorMajor9;
        static public readonly ChordFormula ASus2Sus4;
        static public readonly ChordFormula ASus2;
        static public readonly ChordFormula ASus4;
        static public readonly ChordFormula ASharpAugmented;
        static public readonly ChordFormula ASharpDominant11;
        static public readonly ChordFormula ASharpDominant11b9;
        static public readonly ChordFormula ASharpDominant13;
        static public readonly ChordFormula ASharpDominant13Aug11;
        static public readonly ChordFormula ASharpDominant13b9;
        static public readonly ChordFormula ASharpMajor6;
        static public readonly ChordFormula ASharpDominant7;
        static public readonly ChordFormula ASharpDominant7Sharp9;
        static public readonly ChordFormula ASharpDominant7Sharp5;
        static public readonly ChordFormula ASharpDominant7Sharp5b9;
        static public readonly ChordFormula ASharpDominant7Sharp5Nine;
        static public readonly ChordFormula ASharpDominant7b5;
        static public readonly ChordFormula ASharpDominant7b5Sharp9;
        static public readonly ChordFormula ASharpDominant7b5b9;
        static public readonly ChordFormula ASharpDominant7b9;
        static public readonly ChordFormula ASharpDominant7Sus2;
        static public readonly ChordFormula ASharpDominant7Sus4;
        static public readonly ChordFormula ASharpDominant9;
        static public readonly ChordFormula ASharpDiminished;
        static public readonly ChordFormula ASharpDiminished7;
        static public readonly ChordFormula ASharpMinor;
        static public readonly ChordFormula ASharpMinorAugmented;
        static public readonly ChordFormula ASharpMinor11;
        static public readonly ChordFormula ASharpMinor13;
        static public readonly ChordFormula ASharpMinor6;
        static public readonly ChordFormula ASharpMinor6Add9;
        static public readonly ChordFormula ASharpMinor7;
        static public readonly ChordFormula ASharpMinor7Sharp5;
        static public readonly ChordFormula ASharpMinor9;
        static public readonly ChordFormula ASharpMinorAdd9;
        static public readonly ChordFormula ASharpMajor;
        static public readonly ChordFormula ASharpMajor11;
        static public readonly ChordFormula ASharpMajor13;
        static public readonly ChordFormula ASharpMajor13Aug11;
        static public readonly ChordFormula ASharpMajor7;
        static public readonly ChordFormula ASharpMajor7Aug;
        static public readonly ChordFormula ASharpMajor7b5;
        static public readonly ChordFormula ASharpMajor9;
        static public readonly ChordFormula ASharpMajor9thSharp11;
        static public readonly ChordFormula ASharpMajorMu;
        static public readonly ChordFormula ASharpMinorMajor7;
        static public readonly ChordFormula ASharpMinorMajor7Aug;
        static public readonly ChordFormula ASharpMinorMajor9;
        static public readonly ChordFormula ASharpSus2Sus4;
        static public readonly ChordFormula ASharpSus2;
        static public readonly ChordFormula ASharpSus4;
        static public readonly ChordFormula BbAugmented;
        static public readonly ChordFormula BbDominant11;
        static public readonly ChordFormula BbDominant11b9;
        static public readonly ChordFormula BbDominant13;
        static public readonly ChordFormula BbDominant13Aug11;
        static public readonly ChordFormula BbDominant13b9;
        static public readonly ChordFormula BbMajor6;
        static public readonly ChordFormula BbDominant7;
        static public readonly ChordFormula BbDominant7Sharp9;
        static public readonly ChordFormula BbDominant7Sharp5;
        static public readonly ChordFormula BbDominant7Sharp5b9;
        static public readonly ChordFormula BbDominant7Sharp5Nine;
        static public readonly ChordFormula BbDominant7b5;
        static public readonly ChordFormula BbDominant7b5Sharp9;
        static public readonly ChordFormula BbDominant7b5b9;
        static public readonly ChordFormula BbDominant7b9;
        static public readonly ChordFormula BbDominant7Sus2;
        static public readonly ChordFormula BbDominant7Sus4;
        static public readonly ChordFormula BbDominant9;
        static public readonly ChordFormula BbDiminished;
        static public readonly ChordFormula BbDiminished7;
        static public readonly ChordFormula BbMinor;
        static public readonly ChordFormula BbMinorAugmented;
        static public readonly ChordFormula BbMinor11;
        static public readonly ChordFormula BbMinor13;
        static public readonly ChordFormula BbMinor6;
        static public readonly ChordFormula BbMinor6Add9;
        static public readonly ChordFormula BbMinor7;
        static public readonly ChordFormula BbMinor7Sharp5;
        static public readonly ChordFormula BbMinor9;
        static public readonly ChordFormula BbMinorAdd9;
        static public readonly ChordFormula BbMajor;
        static public readonly ChordFormula BbMajor11;
        static public readonly ChordFormula BbMajor13;
        static public readonly ChordFormula BbMajor13Aug11;
        static public readonly ChordFormula BbMajor7;
        static public readonly ChordFormula BbMajor7Aug;
        static public readonly ChordFormula BbMajor7b5;
        static public readonly ChordFormula BbMajor9;
        static public readonly ChordFormula BbMajor9thSharp11;
        static public readonly ChordFormula BbMajorMu;
        static public readonly ChordFormula BbMinorMajor7;
        static public readonly ChordFormula BbMinorMajor7Aug;
        static public readonly ChordFormula BbMinorMajor9;
        static public readonly ChordFormula BbSus2Sus4;
        static public readonly ChordFormula BbSus2;
        static public readonly ChordFormula BbSus4;
        static public readonly ChordFormula BAugmented;
        static public readonly ChordFormula BDominant11;
        static public readonly ChordFormula BDominant11b9;
        static public readonly ChordFormula BDominant13;
        static public readonly ChordFormula BDominant13Aug11;
        static public readonly ChordFormula BDominant13b9;
        static public readonly ChordFormula BMajor6;
        static public readonly ChordFormula BDominant7;
        static public readonly ChordFormula BDominant7Sharp9;
        static public readonly ChordFormula BDominant7Sharp5;
        static public readonly ChordFormula BDominant7Sharp5b9;
        static public readonly ChordFormula BDominant7Sharp5Nine;
        static public readonly ChordFormula BDominant7b5;
        static public readonly ChordFormula BDominant7b5Sharp9;
        static public readonly ChordFormula BDominant7b5b9;
        static public readonly ChordFormula BDominant7b9;
        static public readonly ChordFormula BDominant7Sus2;
        static public readonly ChordFormula BDominant7Sus4;
        static public readonly ChordFormula BDominant9;
        static public readonly ChordFormula BDiminished;
        static public readonly ChordFormula BDiminished7;
        static public readonly ChordFormula BMinor;
        static public readonly ChordFormula BMinorAugmented;
        static public readonly ChordFormula BMinor11;
        static public readonly ChordFormula BMinor13;
        static public readonly ChordFormula BMinor6;
        static public readonly ChordFormula BMinor6Add9;
        static public readonly ChordFormula BMinor7;
        static public readonly ChordFormula BMinor7Sharp5;
        static public readonly ChordFormula BMinor9;
        static public readonly ChordFormula BMinorAdd9;
        static public readonly ChordFormula BMajor;
        static public readonly ChordFormula BMajor11;
        static public readonly ChordFormula BMajor13;
        static public readonly ChordFormula BMajor13Aug11;
        static public readonly ChordFormula BMajor7;
        static public readonly ChordFormula BMajor7Aug;
        static public readonly ChordFormula BMajor7b5;
        static public readonly ChordFormula BMajor9;
        static public readonly ChordFormula BMajor9thSharp11;
        static public readonly ChordFormula BMajorMu;
        static public readonly ChordFormula BMinorMajor7;
        static public readonly ChordFormula BMinorMajor7Aug;
        static public readonly ChordFormula BMinorMajor9;
        static public readonly ChordFormula BSus2Sus4;
        static public readonly ChordFormula BSus2;
        static public readonly ChordFormula BSus4;
        static public readonly ChordFormula CbAugmented;
        static public readonly ChordFormula CbDominant11;
        static public readonly ChordFormula CbDominant11b9;
        static public readonly ChordFormula CbDominant13;
        static public readonly ChordFormula CbDominant13Aug11;
        static public readonly ChordFormula CbDominant13b9;
        static public readonly ChordFormula CbMajor6;
        static public readonly ChordFormula CbDominant7;
        static public readonly ChordFormula CbDominant7Sharp9;
        static public readonly ChordFormula CbDominant7Sharp5;
        static public readonly ChordFormula CbDominant7Sharp5b9;
        static public readonly ChordFormula CbDominant7Sharp5Nine;
        static public readonly ChordFormula CbDominant7b5;
        static public readonly ChordFormula CbDominant7b5Sharp9;
        static public readonly ChordFormula CbDominant7b5b9;
        static public readonly ChordFormula CbDominant7b9;
        static public readonly ChordFormula CbDominant7Sus2;
        static public readonly ChordFormula CbDominant7Sus4;
        static public readonly ChordFormula CbDominant9;
        static public readonly ChordFormula CbDiminished;
        static public readonly ChordFormula CbDiminished7;
        static public readonly ChordFormula CbMinor;
        static public readonly ChordFormula CbMinorAugmented;
        static public readonly ChordFormula CbMinor11;
        static public readonly ChordFormula CbMinor13;
        static public readonly ChordFormula CbMinor6;
        static public readonly ChordFormula CbMinor6Add9;
        static public readonly ChordFormula CbMinor7;
        static public readonly ChordFormula CbMinor7Sharp5;
        static public readonly ChordFormula CbMinor9;
        static public readonly ChordFormula CbMinorAdd9;
        static public readonly ChordFormula CbMajor;
        static public readonly ChordFormula CbMajor11;
        static public readonly ChordFormula CbMajor13;
        static public readonly ChordFormula CbMajor13Aug11;
        static public readonly ChordFormula CbMajor7;
        static public readonly ChordFormula CbMajor7Aug;
        static public readonly ChordFormula CbMajor7b5;
        static public readonly ChordFormula CbMajor9;
        static public readonly ChordFormula CbMajor9thSharp11;
        static public readonly ChordFormula CbMajorMu;
        static public readonly ChordFormula CbMinorMajor7;
        static public readonly ChordFormula CbMinorMajor7Aug;
        static public readonly ChordFormula CbMinorMajor9;
        static public readonly ChordFormula CbSus2Sus4;
        static public readonly ChordFormula CbSus2;
        static public readonly ChordFormula CbSus4;
        #endregion static Chords

        static void CreateChordCatalog()
        {
        }

        static void AddKeys()
        {
        }

        static void AddToCatalog(NoteName nn, ChordIntervalsEnum ct)
        {
            try
            {
                var result = ChordFormula.Create(nn, ct);
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
                _Catalog.Add(BSharpAugmented = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Augmented));
                _Catalog.Add(BSharpDominant11 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Dominant11));
                _Catalog.Add(BSharpDominant11b9 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Dominant11b9));
                _Catalog.Add(BSharpDominant13 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Dominant13));
                _Catalog.Add(BSharpDominant13Aug11 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Dominant13Aug11));
                _Catalog.Add(BSharpDominant13b9 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Dominant13b9));
                _Catalog.Add(BSharpMajor6 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Major6));
                _Catalog.Add(BSharpDominant7 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Dominant7));
                _Catalog.Add(BSharpDominant7Sharp5 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Dominant7Sharp5));
                _Catalog.Add(BSharpDominant7Sharp5b9 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Dominant7Sharp5b9));
                _Catalog.Add(BSharpDominant7Sharp5Nine = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Dominant7Sharp5Nine));
                _Catalog.Add(BSharpDominant7b5 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Dominant7b5));
                _Catalog.Add(BSharpDominant7b5Sharp9 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Dominant7b5Sharp9));
                _Catalog.Add(BSharpDominant7b5b9 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Dominant7b5b9));
                _Catalog.Add(BSharpDominant7b9 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Dominant7b9));
                _Catalog.Add(BSharpDominant7Sus2 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Dominant7Sus2));
                _Catalog.Add(BSharpDominant7Sus4 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Dominant7Sus4));
                _Catalog.Add(BSharpDominant9 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Dominant9));
                _Catalog.Add(BSharpDiminished = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Diminished));
                _Catalog.Add(BSharpDiminished7 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Diminished7));
                _Catalog.Add(BSharpMinor = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Minor));
                _Catalog.Add(BSharpMinorAugmented = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.MinorAugmented));
                _Catalog.Add(BSharpMinor11 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Minor11));
                _Catalog.Add(BSharpMinor13 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Minor13));
                _Catalog.Add(BSharpMinor6 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Minor6));
                _Catalog.Add(BSharpMinor6Add9 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Minor6Add9));
                _Catalog.Add(BSharpMinor7 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Minor7));
                _Catalog.Add(BSharpMinor7Sharp5 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Minor7Sharp5));
                _Catalog.Add(BSharpMinor9 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Minor9));
                _Catalog.Add(BSharpMinorAdd9 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.MinorAdd9));
                _Catalog.Add(BSharpMajor = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Major));
                _Catalog.Add(BSharpMajor11 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Major11));
                _Catalog.Add(BSharpMajor13 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Major13));
                _Catalog.Add(BSharpMajor13Aug11 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Major13Aug11));
                _Catalog.Add(BSharpMajor7 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Major7));
                _Catalog.Add(BSharpMajor7Aug = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Major7Aug));
                _Catalog.Add(BSharpMajor7b5 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Major7b5));
                _Catalog.Add(BSharpMajor9 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Major9));
                _Catalog.Add(BSharpMajor9thSharp11 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Major9thSharp11));
                _Catalog.Add(BSharpMajorMu = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.MajorMu));
                _Catalog.Add(BSharpMinorMajor7 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.MinorMajor7));
                _Catalog.Add(BSharpMinorMajor7Aug = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.MinorMajor7Aug));
                _Catalog.Add(BSharpMinorMajor9 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.MinorMajor9));
                _Catalog.Add(BSharpSus2Sus4 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Sus2Sus4));
                _Catalog.Add(BSharpSus2 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Sus2));
                _Catalog.Add(BSharpSus4 = ChordFormula.Create(NoteName.BSharp, ChordIntervalsEnum.Sus4));
                #endregion NoteName.B♯

                #region NoteName.C
                _Catalog.Add(CAugmented = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Augmented));
                _Catalog.Add(CDominant11 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Dominant11));
                _Catalog.Add(CDominant11b9 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Dominant11b9));
                _Catalog.Add(CDominant13 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Dominant13));
                _Catalog.Add(CDominant13Aug11 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Dominant13Aug11));
                _Catalog.Add(CDominant13b9 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Dominant13b9));
                _Catalog.Add(CMajor6 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Major6));
                _Catalog.Add(CDominant7 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Dominant7));
                _Catalog.Add(CDominant7Sharp9 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Dominant7Sharp9));
                _Catalog.Add(CDominant7Sharp5 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Dominant7Sharp5));
                _Catalog.Add(CDominant7Sharp5b9 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Dominant7Sharp5b9));
                _Catalog.Add(CDominant7Sharp5Nine = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Dominant7Sharp5Nine));
                _Catalog.Add(CDominant7b5 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Dominant7b5));
                _Catalog.Add(CDominant7b5Sharp9 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Dominant7b5Sharp9));
                _Catalog.Add(CDominant7b5b9 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Dominant7b5b9));
                _Catalog.Add(CDominant7b9 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Dominant7b9));
                _Catalog.Add(CDominant7Sus2 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Dominant7Sus2));
                _Catalog.Add(CDominant7Sus4 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Dominant7Sus4));
                _Catalog.Add(CDominant9 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Dominant9));
                _Catalog.Add(CDiminished = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Diminished));
                _Catalog.Add(CDiminished7 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Diminished7));
                _Catalog.Add(CMinor = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Minor));
                _Catalog.Add(CMinorAugmented = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.MinorAugmented));
                _Catalog.Add(CMinor11 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Minor11));
                _Catalog.Add(CMinor13 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Minor13));
                _Catalog.Add(CMinor6 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Minor6));
                _Catalog.Add(CMinor6Add9 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Minor6Add9));
                _Catalog.Add(CMinor7 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Minor7));
                _Catalog.Add(CMinor7Sharp5 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Minor7Sharp5));
                _Catalog.Add(CMinor9 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Minor9));
                _Catalog.Add(CMinorAdd9 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.MinorAdd9));
                _Catalog.Add(CMajor = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Major));
                _Catalog.Add(CMajor11 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Major11));
                _Catalog.Add(CMajor13 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Major13));
                _Catalog.Add(CMajor13Aug11 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Major13Aug11));
                _Catalog.Add(CMajor7 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Major7));
                _Catalog.Add(CMajor7Aug = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Major7Aug));
                _Catalog.Add(CMajor7b5 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Major7b5));
                _Catalog.Add(CMajor9 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Major9));
                _Catalog.Add(CMajor9thSharp11 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Major9thSharp11));
                _Catalog.Add(CMajorMu = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.MajorMu));
                _Catalog.Add(CMinorMajor7 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.MinorMajor7));
                _Catalog.Add(CMinorMajor7Aug = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.MinorMajor7Aug));
                _Catalog.Add(CMinorMajor9 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.MinorMajor9));
                _Catalog.Add(CSus2Sus4 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Sus2Sus4));
                _Catalog.Add(CSus2 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Sus2));
                _Catalog.Add(CSus4 = ChordFormula.Create(NoteName.C, ChordIntervalsEnum.Sus4));
                #endregion NoteName.C

                #region NoteName.C♯
                _Catalog.Add(CSharpAugmented = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Augmented));
                _Catalog.Add(CSharpDominant11 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Dominant11));
                _Catalog.Add(CSharpDominant11b9 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Dominant11b9));
                _Catalog.Add(CSharpDominant13 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Dominant13));
                _Catalog.Add(CSharpDominant13Aug11 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Dominant13Aug11));
                _Catalog.Add(CSharpDominant13b9 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Dominant13b9));
                _Catalog.Add(CSharpMajor6 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Major6));
                _Catalog.Add(CSharpDominant7 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Dominant7));
                _Catalog.Add(CSharpDominant7Sharp9 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Dominant7Sharp9));
                _Catalog.Add(CSharpDominant7Sharp5 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Dominant7Sharp5));
                _Catalog.Add(CSharpDominant7Sharp5b9 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Dominant7Sharp5b9));
                _Catalog.Add(CSharpDominant7Sharp5Nine = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Dominant7Sharp5Nine));
                _Catalog.Add(CSharpDominant7b5 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Dominant7b5));
                _Catalog.Add(CSharpDominant7b5Sharp9 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Dominant7b5Sharp9));
                _Catalog.Add(CSharpDominant7b5b9 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Dominant7b5b9));
                _Catalog.Add(CSharpDominant7b9 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Dominant7b9));
                _Catalog.Add(CSharpDominant7Sus2 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Dominant7Sus2));
                _Catalog.Add(CSharpDominant7Sus4 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Dominant7Sus4));
                _Catalog.Add(CSharpDominant9 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Dominant9));
                _Catalog.Add(CSharpDiminished = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Diminished));
                _Catalog.Add(CSharpDiminished7 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Diminished7));
                _Catalog.Add(CSharpMinor = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Minor));
                _Catalog.Add(CSharpMinorAugmented = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.MinorAugmented));
                _Catalog.Add(CSharpMinor11 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Minor11));
                _Catalog.Add(CSharpMinor13 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Minor13));
                _Catalog.Add(CSharpMinor6 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Minor6));
                _Catalog.Add(CSharpMinor6Add9 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Minor6Add9));
                _Catalog.Add(CSharpMinor7 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Minor7));
                _Catalog.Add(CSharpMinor7Sharp5 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Minor7Sharp5));
                _Catalog.Add(CSharpMinor9 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Minor9));
                _Catalog.Add(CSharpMinorAdd9 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.MinorAdd9));
                _Catalog.Add(CSharpMajor = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Major));
                _Catalog.Add(CSharpMajor11 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Major11));
                _Catalog.Add(CSharpMajor13 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Major13));
                _Catalog.Add(CSharpMajor13Aug11 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Major13Aug11));
                _Catalog.Add(CSharpMajor7 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Major7));
                _Catalog.Add(CSharpMajor7Aug = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Major7Aug));
                _Catalog.Add(CSharpMajor7b5 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Major7b5));
                _Catalog.Add(CSharpMajor9 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Major9));
                _Catalog.Add(CSharpMajor9thSharp11 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Major9thSharp11));
                _Catalog.Add(CSharpMajorMu = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.MajorMu));
                _Catalog.Add(CSharpMinorMajor7 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.MinorMajor7));
                _Catalog.Add(CSharpMinorMajor7Aug = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.MinorMajor7Aug));
                _Catalog.Add(CSharpMinorMajor9 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.MinorMajor9));
                _Catalog.Add(CSharpSus2Sus4 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Sus2Sus4));
                _Catalog.Add(CSharpSus2 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Sus2));
                _Catalog.Add(CSharpSus4 = ChordFormula.Create(NoteName.CSharp, ChordIntervalsEnum.Sus4));
                #endregion NoteName.C♯

                #region NoteName.D♭
                _Catalog.Add(DbAugmented = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Augmented));
                _Catalog.Add(DbDominant11 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Dominant11));
                _Catalog.Add(DbDominant11b9 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Dominant11b9));
                _Catalog.Add(DbDominant13 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Dominant13));
                _Catalog.Add(DbDominant13Aug11 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Dominant13Aug11));
                _Catalog.Add(DbDominant13b9 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Dominant13b9));
                _Catalog.Add(DbMajor6 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Major6));
                _Catalog.Add(DbDominant7 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Dominant7));
                _Catalog.Add(DbDominant7Sharp9 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Dominant7Sharp9));
                _Catalog.Add(DbDominant7Sharp5 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Dominant7Sharp5));
                _Catalog.Add(DbDominant7Sharp5b9 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Dominant7Sharp5b9));
                _Catalog.Add(DbDominant7Sharp5Nine = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Dominant7Sharp5Nine));
                _Catalog.Add(DbDominant7b5 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Dominant7b5));
                _Catalog.Add(DbDominant7b5Sharp9 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Dominant7b5Sharp9));
                _Catalog.Add(DbDominant7b5b9 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Dominant7b5b9));
                _Catalog.Add(DbDominant7b9 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Dominant7b9));
                _Catalog.Add(DbDominant7Sus2 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Dominant7Sus2));
                _Catalog.Add(DbDominant7Sus4 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Dominant7Sus4));
                _Catalog.Add(DbDominant9 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Dominant9));
                _Catalog.Add(DbDiminished = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Diminished));
                _Catalog.Add(DbDiminished7 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Diminished7));
                _Catalog.Add(DbMinor = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Minor));
                _Catalog.Add(DbMinorAugmented = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.MinorAugmented));
                _Catalog.Add(DbMinor11 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Minor11));
                _Catalog.Add(DbMinor13 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Minor13));
                _Catalog.Add(DbMinor6 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Minor6));
                _Catalog.Add(DbMinor6Add9 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Minor6Add9));
                _Catalog.Add(DbMinor7 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Minor7));
                _Catalog.Add(DbMinor7Sharp5 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Minor7Sharp5));
                _Catalog.Add(DbMinor9 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Minor9));
                _Catalog.Add(DbMinorAdd9 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.MinorAdd9));
                _Catalog.Add(DbMajor = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Major));
                _Catalog.Add(DbMajor11 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Major11));
                _Catalog.Add(DbMajor13 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Major13));
                _Catalog.Add(DbMajor13Aug11 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Major13Aug11));
                _Catalog.Add(DbMajor7 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Major7));
                _Catalog.Add(DbMajor7Aug = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Major7Aug));
                _Catalog.Add(DbMajor7b5 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Major7b5));
                _Catalog.Add(DbMajor9 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Major9));
                _Catalog.Add(DbMajor9thSharp11 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Major9thSharp11));
                _Catalog.Add(DbMajorMu = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.MajorMu));
                _Catalog.Add(DbMinorMajor7 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.MinorMajor7));
                _Catalog.Add(DbMinorMajor7Aug = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.MinorMajor7Aug));
                _Catalog.Add(DbMinorMajor9 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.MinorMajor9));
                _Catalog.Add(DbSus2Sus4 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Sus2Sus4));
                _Catalog.Add(DbSus2 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Sus2));
                _Catalog.Add(DbSus4 = ChordFormula.Create(NoteName.Db, ChordIntervalsEnum.Sus4));
                #endregion NoteName.D♭

                #region NoteName.D
                _Catalog.Add(DAugmented = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Augmented));
                _Catalog.Add(DDominant11 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Dominant11));
                _Catalog.Add(DDominant11b9 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Dominant11b9));
                _Catalog.Add(DDominant13 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Dominant13));
                _Catalog.Add(DDominant13Aug11 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Dominant13Aug11));
                _Catalog.Add(DDominant13b9 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Dominant13b9));
                _Catalog.Add(DMajor6 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Major6));
                _Catalog.Add(DDominant7 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Dominant7));
                _Catalog.Add(DDominant7Sharp9 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Dominant7Sharp9));
                _Catalog.Add(DDominant7Sharp5 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Dominant7Sharp5));
                _Catalog.Add(DDominant7Sharp5b9 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Dominant7Sharp5b9));
                _Catalog.Add(DDominant7Sharp5Nine = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Dominant7Sharp5Nine));
                _Catalog.Add(DDominant7b5 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Dominant7b5));
                _Catalog.Add(DDominant7b5Sharp9 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Dominant7b5Sharp9));
                _Catalog.Add(DDominant7b5b9 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Dominant7b5b9));
                _Catalog.Add(DDominant7b9 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Dominant7b9));
                _Catalog.Add(DDominant7Sus2 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Dominant7Sus2));
                _Catalog.Add(DDominant7Sus4 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Dominant7Sus4));
                _Catalog.Add(DDominant9 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Dominant9));
                _Catalog.Add(DDiminished = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Diminished));
                _Catalog.Add(DDiminished7 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Diminished7));
                _Catalog.Add(DMinor = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Minor));
                _Catalog.Add(DMinorAugmented = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.MinorAugmented));
                _Catalog.Add(DMinor11 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Minor11));
                _Catalog.Add(DMinor13 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Minor13));
                _Catalog.Add(DMinor6 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Minor6));
                _Catalog.Add(DMinor6Add9 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Minor6Add9));
                _Catalog.Add(DMinor7 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Minor7));
                _Catalog.Add(DMinor7Sharp5 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Minor7Sharp5));
                _Catalog.Add(DMinor9 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Minor9));
                _Catalog.Add(DMinorAdd9 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.MinorAdd9));
                _Catalog.Add(DMajor = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Major));
                _Catalog.Add(DMajor11 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Major11));
                _Catalog.Add(DMajor13 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Major13));
                _Catalog.Add(DMajor13Aug11 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Major13Aug11));
                _Catalog.Add(DMajor7 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Major7));
                _Catalog.Add(DMajor7Aug = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Major7Aug));
                _Catalog.Add(DMajor7b5 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Major7b5));
                _Catalog.Add(DMajor9 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Major9));
                _Catalog.Add(DMajor9thSharp11 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Major9thSharp11));
                _Catalog.Add(DMajorMu = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.MajorMu));
                _Catalog.Add(DMinorMajor7 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.MinorMajor7));
                _Catalog.Add(DMinorMajor7Aug = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.MinorMajor7Aug));
                _Catalog.Add(DMinorMajor9 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.MinorMajor9));
                _Catalog.Add(DSus2Sus4 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Sus2Sus4));
                _Catalog.Add(DSus2 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Sus2));
                _Catalog.Add(DSus4 = ChordFormula.Create(NoteName.D, ChordIntervalsEnum.Sus4));
                #endregion NoteName.D

                #region NoteName.D♯
                _Catalog.Add(DSharpAugmented = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Augmented));
                _Catalog.Add(DSharpDominant11 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Dominant11));
                _Catalog.Add(DSharpDominant11b9 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Dominant11b9));
                _Catalog.Add(DSharpDominant13 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Dominant13));
                _Catalog.Add(DSharpDominant13Aug11 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Dominant13Aug11));
                _Catalog.Add(DSharpDominant13b9 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Dominant13b9));
                _Catalog.Add(DSharpMajor6 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Major6));
                _Catalog.Add(DSharpDominant7 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Dominant7));
                _Catalog.Add(DSharpDominant7Sharp9 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Dominant7Sharp9));
                _Catalog.Add(DSharpDominant7Sharp5 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Dominant7Sharp5));
                _Catalog.Add(DSharpDominant7Sharp5b9 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Dominant7Sharp5b9));
                _Catalog.Add(DSharpDominant7Sharp5Nine = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Dominant7Sharp5Nine));
                _Catalog.Add(DSharpDominant7b5 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Dominant7b5));
                _Catalog.Add(DSharpDominant7b5Sharp9 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Dominant7b5Sharp9));
                _Catalog.Add(DSharpDominant7b5b9 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Dominant7b5b9));
                _Catalog.Add(DSharpDominant7b9 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Dominant7b9));
                _Catalog.Add(DSharpDominant7Sus2 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Dominant7Sus2));
                _Catalog.Add(DSharpDominant7Sus4 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Dominant7Sus4));
                _Catalog.Add(DSharpDominant9 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Dominant9));
                _Catalog.Add(DSharpDiminished = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Diminished));
                _Catalog.Add(DSharpDiminished7 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Diminished7));
                _Catalog.Add(DSharpMinor = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Minor));
                _Catalog.Add(DSharpMinorAugmented = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.MinorAugmented));
                _Catalog.Add(DSharpMinor11 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Minor11));
                _Catalog.Add(DSharpMinor13 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Minor13));
                _Catalog.Add(DSharpMinor6 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Minor6));
                _Catalog.Add(DSharpMinor6Add9 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Minor6Add9));
                _Catalog.Add(DSharpMinor7 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Minor7));
                _Catalog.Add(DSharpMinor7Sharp5 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Minor7Sharp5));
                _Catalog.Add(DSharpMinor9 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Minor9));
                _Catalog.Add(DSharpMinorAdd9 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.MinorAdd9));
                _Catalog.Add(DSharpMajor = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Major));
                _Catalog.Add(DSharpMajor11 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Major11));
                _Catalog.Add(DSharpMajor13 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Major13));
                _Catalog.Add(DSharpMajor13Aug11 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Major13Aug11));
                _Catalog.Add(DSharpMajor7 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Major7));
                _Catalog.Add(DSharpMajor7Aug = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Major7Aug));
                _Catalog.Add(DSharpMajor7b5 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Major7b5));
                _Catalog.Add(DSharpMajor9 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Major9));
                _Catalog.Add(DSharpMajor9thSharp11 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Major9thSharp11));
                _Catalog.Add(DSharpMajorMu = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.MajorMu));
                _Catalog.Add(DSharpMinorMajor7 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.MinorMajor7));
                _Catalog.Add(DSharpMinorMajor7Aug = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.MinorMajor7Aug));
                _Catalog.Add(DSharpMinorMajor9 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.MinorMajor9));
                _Catalog.Add(DSharpSus2Sus4 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Sus2Sus4));
                _Catalog.Add(DSharpSus2 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Sus2));
                _Catalog.Add(DSharpSus4 = ChordFormula.Create(NoteName.DSharp, ChordIntervalsEnum.Sus4));
                #endregion NoteName.D♯

                #region NoteName.E♭
                _Catalog.Add(EbAugmented = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Augmented));
                _Catalog.Add(EbDominant11 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Dominant11));
                _Catalog.Add(EbDominant11b9 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Dominant11b9));
                _Catalog.Add(EbDominant13 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Dominant13));
                _Catalog.Add(EbDominant13Aug11 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Dominant13Aug11));
                _Catalog.Add(EbDominant13b9 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Dominant13b9));
                _Catalog.Add(EbMajor6 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Major6));
                _Catalog.Add(EbDominant7 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Dominant7));
                _Catalog.Add(EbDominant7Sharp9 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Dominant7Sharp9));
                _Catalog.Add(EbDominant7Sharp5 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Dominant7Sharp5));
                _Catalog.Add(EbDominant7Sharp5b9 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Dominant7Sharp5b9));
                _Catalog.Add(EbDominant7Sharp5Nine = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Dominant7Sharp5Nine));
                _Catalog.Add(EbDominant7b5 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Dominant7b5));
                _Catalog.Add(EbDominant7b5Sharp9 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Dominant7b5Sharp9));
                _Catalog.Add(EbDominant7b5b9 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Dominant7b5b9));
                _Catalog.Add(EbDominant7b9 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Dominant7b9));
                _Catalog.Add(EbDominant7Sus2 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Dominant7Sus2));
                _Catalog.Add(EbDominant7Sus4 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Dominant7Sus4));
                _Catalog.Add(EbDominant9 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Dominant9));
                _Catalog.Add(EbDiminished = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Diminished));
                _Catalog.Add(EbDiminished7 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Diminished7));
                _Catalog.Add(EbMinor = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Minor));
                _Catalog.Add(EbMinorAugmented = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.MinorAugmented));
                _Catalog.Add(EbMinor11 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Minor11));
                _Catalog.Add(EbMinor13 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Minor13));
                _Catalog.Add(EbMinor6 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Minor6));
                _Catalog.Add(EbMinor6Add9 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Minor6Add9));
                _Catalog.Add(EbMinor7 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Minor7));
                _Catalog.Add(EbMinor7Sharp5 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Minor7Sharp5));
                _Catalog.Add(EbMinor9 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Minor9));
                _Catalog.Add(EbMinorAdd9 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.MinorAdd9));
                _Catalog.Add(EbMajor = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Major));
                _Catalog.Add(EbMajor11 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Major11));
                _Catalog.Add(EbMajor13 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Major13));
                _Catalog.Add(EbMajor13Aug11 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Major13Aug11));
                _Catalog.Add(EbMajor7 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Major7));
                _Catalog.Add(EbMajor7Aug = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Major7Aug));
                _Catalog.Add(EbMajor7b5 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Major7b5));
                _Catalog.Add(EbMajor9 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Major9));
                _Catalog.Add(EbMajor9thSharp11 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Major9thSharp11));
                _Catalog.Add(EbMajorMu = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.MajorMu));
                _Catalog.Add(EbMinorMajor7 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.MinorMajor7));
                _Catalog.Add(EbMinorMajor7Aug = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.MinorMajor7Aug));
                _Catalog.Add(EbMinorMajor9 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.MinorMajor9));
                _Catalog.Add(EbSus2Sus4 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Sus2Sus4));
                _Catalog.Add(EbSus2 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Sus2));
                _Catalog.Add(EbSus4 = ChordFormula.Create(NoteName.Eb, ChordIntervalsEnum.Sus4));
                #endregion NoteName.E♭

                #region NoteName.E
                _Catalog.Add(EAugmented = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Augmented));
                _Catalog.Add(EDominant11 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Dominant11));
                _Catalog.Add(EDominant11b9 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Dominant11b9));
                _Catalog.Add(EDominant13 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Dominant13));
                _Catalog.Add(EDominant13Aug11 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Dominant13Aug11));
                _Catalog.Add(EDominant13b9 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Dominant13b9));
                _Catalog.Add(EMajor6 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Major6));
                _Catalog.Add(EDominant7 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Dominant7));
                _Catalog.Add(EDominant7Sharp9 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Dominant7Sharp9));
                _Catalog.Add(EDominant7Sharp5 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Dominant7Sharp5));
                _Catalog.Add(EDominant7Sharp5b9 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Dominant7Sharp5b9));
                _Catalog.Add(EDominant7Sharp5Nine = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Dominant7Sharp5Nine));
                _Catalog.Add(EDominant7b5 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Dominant7b5));
                _Catalog.Add(EDominant7b5Sharp9 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Dominant7b5Sharp9));
                _Catalog.Add(EDominant7b5b9 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Dominant7b5b9));
                _Catalog.Add(EDominant7b9 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Dominant7b9));
                _Catalog.Add(EDominant7Sus2 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Dominant7Sus2));
                _Catalog.Add(EDominant7Sus4 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Dominant7Sus4));
                _Catalog.Add(EDominant9 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Dominant9));
                _Catalog.Add(EDiminished = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Diminished));
                _Catalog.Add(EDiminished7 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Diminished7));
                _Catalog.Add(EMinor = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Minor));
                _Catalog.Add(EMinorAugmented = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.MinorAugmented));
                _Catalog.Add(EMinor11 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Minor11));
                _Catalog.Add(EMinor13 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Minor13));
                _Catalog.Add(EMinor6 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Minor6));
                _Catalog.Add(EMinor6Add9 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Minor6Add9));
                _Catalog.Add(EMinor7 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Minor7));
                _Catalog.Add(EMinor7Sharp5 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Minor7Sharp5));
                _Catalog.Add(EMinor9 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Minor9));
                _Catalog.Add(EMinorAdd9 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.MinorAdd9));
                _Catalog.Add(EMajor = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Major));
                _Catalog.Add(EMajor11 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Major11));
                _Catalog.Add(EMajor13 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Major13));
                _Catalog.Add(EMajor13Aug11 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Major13Aug11));
                _Catalog.Add(EMajor7 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Major7));
                _Catalog.Add(EMajor7Aug = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Major7Aug));
                _Catalog.Add(EMajor7b5 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Major7b5));
                _Catalog.Add(EMajor9 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Major9));
                _Catalog.Add(EMajor9thSharp11 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Major9thSharp11));
                _Catalog.Add(EMajorMu = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.MajorMu));
                _Catalog.Add(EMinorMajor7 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.MinorMajor7));
                _Catalog.Add(EMinorMajor7Aug = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.MinorMajor7Aug));
                _Catalog.Add(EMinorMajor9 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.MinorMajor9));
                _Catalog.Add(ESus2Sus4 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Sus2Sus4));
                _Catalog.Add(ESus2 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Sus2));
                _Catalog.Add(ESus4 = ChordFormula.Create(NoteName.E, ChordIntervalsEnum.Sus4));
                #endregion NoteName.E

                #region NoteName.F♭
                _Catalog.Add(FbAugmented = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Augmented));
                _Catalog.Add(FbDominant11 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Dominant11));
                _Catalog.Add(FbDominant11b9 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Dominant11b9));
                _Catalog.Add(FbDominant13 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Dominant13));
                _Catalog.Add(FbDominant13Aug11 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Dominant13Aug11));
                _Catalog.Add(FbDominant13b9 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Dominant13b9));
                _Catalog.Add(FbMajor6 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Major6));
                _Catalog.Add(FbDominant7 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Dominant7));
                _Catalog.Add(FbDominant7Sharp9 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Dominant7Sharp9));
                _Catalog.Add(FbDominant7Sharp5 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Dominant7Sharp5));
                _Catalog.Add(FbDominant7Sharp5b9 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Dominant7Sharp5b9));
                _Catalog.Add(FbDominant7Sharp5Nine = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Dominant7Sharp5Nine));
                _Catalog.Add(FbDominant7b5 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Dominant7b5));
                _Catalog.Add(FbDominant7b5Sharp9 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Dominant7b5Sharp9));
                _Catalog.Add(FbDominant7b5b9 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Dominant7b5b9));
                _Catalog.Add(FbDominant7b9 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Dominant7b9));
                _Catalog.Add(FbDominant7Sus2 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Dominant7Sus2));
                _Catalog.Add(FbDominant7Sus4 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Dominant7Sus4));
                _Catalog.Add(FbDominant9 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Dominant9));
                _Catalog.Add(FbDiminished = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Diminished));
                _Catalog.Add(FbDiminished7 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Diminished7));
                _Catalog.Add(FbMinor = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Minor));
                _Catalog.Add(FbMinorAugmented = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.MinorAugmented));
                _Catalog.Add(FbMinor11 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Minor11));
                _Catalog.Add(FbMinor13 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Minor13));
                _Catalog.Add(FbMinor6 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Minor6));
                _Catalog.Add(FbMinor6Add9 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Minor6Add9));
                _Catalog.Add(FbMinor7 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Minor7));
                _Catalog.Add(FbMinor7Sharp5 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Minor7Sharp5));
                _Catalog.Add(FbMinor9 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Minor9));
                _Catalog.Add(FbMinorAdd9 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.MinorAdd9));
                _Catalog.Add(FbMajor = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Major));
                _Catalog.Add(FbMajor11 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Major11));
                _Catalog.Add(FbMajor13 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Major13));
                _Catalog.Add(FbMajor13Aug11 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Major13Aug11));
                _Catalog.Add(FbMajor7 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Major7));
                _Catalog.Add(FbMajor7Aug = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Major7Aug));
                _Catalog.Add(FbMajor7b5 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Major7b5));
                _Catalog.Add(FbMajor9 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Major9));
                _Catalog.Add(FbMajor9thSharp11 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Major9thSharp11));
                _Catalog.Add(FbMajorMu = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.MajorMu));
                _Catalog.Add(FbMinorMajor7 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.MinorMajor7));
                _Catalog.Add(FbMinorMajor7Aug = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.MinorMajor7Aug));
                _Catalog.Add(FbMinorMajor9 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.MinorMajor9));
                _Catalog.Add(FbSus2Sus4 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Sus2Sus4));
                _Catalog.Add(FbSus2 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Sus2));
                _Catalog.Add(FbSus4 = ChordFormula.Create(NoteName.Fb, ChordIntervalsEnum.Sus4));
                #endregion NoteName.F♭

                #region NoteName.E♯
                _Catalog.Add(ESharpAugmented = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Augmented));
                _Catalog.Add(ESharpDominant11 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Dominant11));
                _Catalog.Add(ESharpDominant11b9 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Dominant11b9));
                _Catalog.Add(ESharpDominant13 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Dominant13));
                _Catalog.Add(ESharpDominant13Aug11 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Dominant13Aug11));
                _Catalog.Add(ESharpDominant13b9 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Dominant13b9));
                _Catalog.Add(ESharpMajor6 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Major6));
                _Catalog.Add(ESharpDominant7 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Dominant7));
                _Catalog.Add(ESharpDominant7Sharp5 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Dominant7Sharp5));
                _Catalog.Add(ESharpDominant7Sharp5b9 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Dominant7Sharp5b9));
                _Catalog.Add(ESharpDominant7Sharp5Nine = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Dominant7Sharp5Nine));
                _Catalog.Add(ESharpDominant7b5 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Dominant7b5));
                _Catalog.Add(ESharpDominant7b5Sharp9 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Dominant7b5Sharp9));
                _Catalog.Add(ESharpDominant7b5b9 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Dominant7b5b9));
                _Catalog.Add(ESharpDominant7b9 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Dominant7b9));
                _Catalog.Add(ESharpDominant7Sus2 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Dominant7Sus2));
                _Catalog.Add(ESharpDominant7Sus4 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Dominant7Sus4));
                _Catalog.Add(ESharpDominant9 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Dominant9));
                _Catalog.Add(ESharpDiminished = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Diminished));
                _Catalog.Add(ESharpDiminished7 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Diminished7));
                _Catalog.Add(ESharpMinor = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Minor));
                _Catalog.Add(ESharpMinorAugmented = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.MinorAugmented));
                _Catalog.Add(ESharpMinor11 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Minor11));
                _Catalog.Add(ESharpMinor13 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Minor13));
                _Catalog.Add(ESharpMinor6 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Minor6));
                _Catalog.Add(ESharpMinor6Add9 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Minor6Add9));
                _Catalog.Add(ESharpMinor7 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Minor7));
                _Catalog.Add(ESharpMinor7Sharp5 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Minor7Sharp5));
                _Catalog.Add(ESharpMinor9 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Minor9));
                _Catalog.Add(ESharpMinorAdd9 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.MinorAdd9));
                _Catalog.Add(ESharpMajor = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Major));
                _Catalog.Add(ESharpMajor11 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Major11));
                _Catalog.Add(ESharpMajor13 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Major13));
                _Catalog.Add(ESharpMajor13Aug11 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Major13Aug11));
                _Catalog.Add(ESharpMajor7 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Major7));
                _Catalog.Add(ESharpMajor7Aug = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Major7Aug));
                _Catalog.Add(ESharpMajor7b5 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Major7b5));
                _Catalog.Add(ESharpMajor9 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Major9));
                _Catalog.Add(ESharpMajor9thSharp11 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Major9thSharp11));
                _Catalog.Add(ESharpMajorMu = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.MajorMu));
                _Catalog.Add(ESharpMinorMajor7 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.MinorMajor7));
                _Catalog.Add(ESharpMinorMajor7Aug = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.MinorMajor7Aug));
                _Catalog.Add(ESharpMinorMajor9 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.MinorMajor9));
                _Catalog.Add(ESharpSus2Sus4 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Sus2Sus4));
                _Catalog.Add(ESharpSus2 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Sus2));
                _Catalog.Add(ESharpSus4 = ChordFormula.Create(NoteName.ESharp, ChordIntervalsEnum.Sus4));
                #endregion NoteName.E♯

                #region NoteName.F
                _Catalog.Add(FAugmented = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Augmented));
                _Catalog.Add(FDominant11 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Dominant11));
                _Catalog.Add(FDominant11b9 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Dominant11b9));
                _Catalog.Add(FDominant13 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Dominant13));
                _Catalog.Add(FDominant13Aug11 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Dominant13Aug11));
                _Catalog.Add(FDominant13b9 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Dominant13b9));
                _Catalog.Add(FMajor6 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Major6));
                _Catalog.Add(FDominant7 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Dominant7));
                _Catalog.Add(FDominant7Sharp9 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Dominant7Sharp9));
                _Catalog.Add(FDominant7Sharp5 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Dominant7Sharp5));
                _Catalog.Add(FDominant7Sharp5b9 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Dominant7Sharp5b9));
                _Catalog.Add(FDominant7Sharp5Nine = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Dominant7Sharp5Nine));
                _Catalog.Add(FDominant7b5 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Dominant7b5));
                _Catalog.Add(FDominant7b5Sharp9 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Dominant7b5Sharp9));
                _Catalog.Add(FDominant7b5b9 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Dominant7b5b9));
                _Catalog.Add(FDominant7b9 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Dominant7b9));
                _Catalog.Add(FDominant7Sus2 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Dominant7Sus2));
                _Catalog.Add(FDominant7Sus4 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Dominant7Sus4));
                _Catalog.Add(FDominant9 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Dominant9));
                _Catalog.Add(FDiminished = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Diminished));
                _Catalog.Add(FDiminished7 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Diminished7));
                _Catalog.Add(FMinor = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Minor));
                _Catalog.Add(FMinorAugmented = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.MinorAugmented));
                _Catalog.Add(FMinor11 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Minor11));
                _Catalog.Add(FMinor13 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Minor13));
                _Catalog.Add(FMinor6 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Minor6));
                _Catalog.Add(FMinor6Add9 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Minor6Add9));
                _Catalog.Add(FMinor7 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Minor7));
                _Catalog.Add(FMinor7Sharp5 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Minor7Sharp5));
                _Catalog.Add(FMinor9 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Minor9));
                _Catalog.Add(FMinorAdd9 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.MinorAdd9));
                _Catalog.Add(FMajor = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Major));
                _Catalog.Add(FMajor11 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Major11));
                _Catalog.Add(FMajor13 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Major13));
                _Catalog.Add(FMajor13Aug11 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Major13Aug11));
                _Catalog.Add(FMajor7 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Major7));
                _Catalog.Add(FMajor7Aug = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Major7Aug));
                _Catalog.Add(FMajor7b5 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Major7b5));
                _Catalog.Add(FMajor9 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Major9));
                _Catalog.Add(FMajor9thSharp11 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Major9thSharp11));
                _Catalog.Add(FMajorMu = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.MajorMu));
                _Catalog.Add(FMinorMajor7 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.MinorMajor7));
                _Catalog.Add(FMinorMajor7Aug = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.MinorMajor7Aug));
                _Catalog.Add(FMinorMajor9 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.MinorMajor9));
                _Catalog.Add(FSus2Sus4 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Sus2Sus4));
                _Catalog.Add(FSus2 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Sus2));
                _Catalog.Add(FSus4 = ChordFormula.Create(NoteName.F, ChordIntervalsEnum.Sus4));
                #endregion NoteName.F

                #region NoteName.F♯
                _Catalog.Add(FSharpAugmented = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Augmented));
                _Catalog.Add(FSharpDominant11 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Dominant11));
                _Catalog.Add(FSharpDominant11b9 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Dominant11b9));
                _Catalog.Add(FSharpDominant13 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Dominant13));
                _Catalog.Add(FSharpDominant13Aug11 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Dominant13Aug11));
                _Catalog.Add(FSharpDominant13b9 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Dominant13b9));
                _Catalog.Add(FSharpMajor6 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Major6));
                _Catalog.Add(FSharpDominant7 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Dominant7));
                _Catalog.Add(FSharpDominant7Sharp9 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Dominant7Sharp9));
                _Catalog.Add(FSharpDominant7Sharp5 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Dominant7Sharp5));
                _Catalog.Add(FSharpDominant7Sharp5b9 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Dominant7Sharp5b9));
                _Catalog.Add(FSharpDominant7Sharp5Nine = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Dominant7Sharp5Nine));
                _Catalog.Add(FSharpDominant7b5 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Dominant7b5));
                _Catalog.Add(FSharpDominant7b5Sharp9 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Dominant7b5Sharp9));
                _Catalog.Add(FSharpDominant7b5b9 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Dominant7b5b9));
                _Catalog.Add(FSharpDominant7b9 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Dominant7b9));
                _Catalog.Add(FSharpDominant7Sus2 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Dominant7Sus2));
                _Catalog.Add(FSharpDominant7Sus4 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Dominant7Sus4));
                _Catalog.Add(FSharpDominant9 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Dominant9));
                _Catalog.Add(FSharpDiminished = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Diminished));
                _Catalog.Add(FSharpDiminished7 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Diminished7));
                _Catalog.Add(FSharpMinor = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Minor));
                _Catalog.Add(FSharpMinorAugmented = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.MinorAugmented));
                _Catalog.Add(FSharpMinor11 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Minor11));
                _Catalog.Add(FSharpMinor13 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Minor13));
                _Catalog.Add(FSharpMinor6 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Minor6));
                _Catalog.Add(FSharpMinor6Add9 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Minor6Add9));
                _Catalog.Add(FSharpMinor7 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Minor7));
                _Catalog.Add(FSharpMinor7Sharp5 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Minor7Sharp5));
                _Catalog.Add(FSharpMinor9 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Minor9));
                _Catalog.Add(FSharpMinorAdd9 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.MinorAdd9));
                _Catalog.Add(FSharpMajor = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Major));
                _Catalog.Add(FSharpMajor11 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Major11));
                _Catalog.Add(FSharpMajor13 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Major13));
                _Catalog.Add(FSharpMajor13Aug11 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Major13Aug11));
                _Catalog.Add(FSharpMajor7 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Major7));
                _Catalog.Add(FSharpMajor7Aug = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Major7Aug));
                _Catalog.Add(FSharpMajor7b5 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Major7b5));
                _Catalog.Add(FSharpMajor9 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Major9));
                _Catalog.Add(FSharpMajor9thSharp11 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Major9thSharp11));
                _Catalog.Add(FSharpMajorMu = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.MajorMu));
                _Catalog.Add(FSharpMinorMajor7 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.MinorMajor7));
                _Catalog.Add(FSharpMinorMajor7Aug = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.MinorMajor7Aug));
                _Catalog.Add(FSharpMinorMajor9 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.MinorMajor9));
                _Catalog.Add(FSharpSus2Sus4 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Sus2Sus4));
                _Catalog.Add(FSharpSus2 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Sus2));
                _Catalog.Add(FSharpSus4 = ChordFormula.Create(NoteName.FSharp, ChordIntervalsEnum.Sus4));
                #endregion NoteName.F♯

                #region NoteName.G♭
                _Catalog.Add(GbAugmented = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Augmented));
                _Catalog.Add(GbDominant11 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Dominant11));
                _Catalog.Add(GbDominant11b9 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Dominant11b9));
                _Catalog.Add(GbDominant13 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Dominant13));
                _Catalog.Add(GbDominant13Aug11 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Dominant13Aug11));
                _Catalog.Add(GbDominant13b9 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Dominant13b9));
                _Catalog.Add(GbMajor6 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Major6));
                _Catalog.Add(GbDominant7 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Dominant7));
                _Catalog.Add(GbDominant7Sharp9 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Dominant7Sharp9));
                _Catalog.Add(GbDominant7Sharp5 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Dominant7Sharp5));
                _Catalog.Add(GbDominant7Sharp5b9 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Dominant7Sharp5b9));
                _Catalog.Add(GbDominant7Sharp5Nine = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Dominant7Sharp5Nine));
                _Catalog.Add(GbDominant7b5 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Dominant7b5));
                _Catalog.Add(GbDominant7b5Sharp9 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Dominant7b5Sharp9));
                _Catalog.Add(GbDominant7b5b9 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Dominant7b5b9));
                _Catalog.Add(GbDominant7b9 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Dominant7b9));
                _Catalog.Add(GbDominant7Sus2 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Dominant7Sus2));
                _Catalog.Add(GbDominant7Sus4 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Dominant7Sus4));
                _Catalog.Add(GbDominant9 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Dominant9));
                _Catalog.Add(GbDiminished = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Diminished));
                _Catalog.Add(GbDiminished7 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Diminished7));
                _Catalog.Add(GbMinor = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Minor));
                _Catalog.Add(GbMinorAugmented = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.MinorAugmented));
                _Catalog.Add(GbMinor11 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Minor11));
                _Catalog.Add(GbMinor13 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Minor13));
                _Catalog.Add(GbMinor6 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Minor6));
                _Catalog.Add(GbMinor6Add9 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Minor6Add9));
                _Catalog.Add(GbMinor7 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Minor7));
                _Catalog.Add(GbMinor7Sharp5 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Minor7Sharp5));
                _Catalog.Add(GbMinor9 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Minor9));
                _Catalog.Add(GbMinorAdd9 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.MinorAdd9));
                _Catalog.Add(GbMajor = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Major));
                _Catalog.Add(GbMajor11 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Major11));
                _Catalog.Add(GbMajor13 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Major13));
                _Catalog.Add(GbMajor13Aug11 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Major13Aug11));
                _Catalog.Add(GbMajor7 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Major7));
                _Catalog.Add(GbMajor7Aug = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Major7Aug));
                _Catalog.Add(GbMajor7b5 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Major7b5));
                _Catalog.Add(GbMajor9 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Major9));
                _Catalog.Add(GbMajor9thSharp11 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Major9thSharp11));
                _Catalog.Add(GbMajorMu = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.MajorMu));
                _Catalog.Add(GbMinorMajor7 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.MinorMajor7));
                _Catalog.Add(GbMinorMajor7Aug = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.MinorMajor7Aug));
                _Catalog.Add(GbMinorMajor9 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.MinorMajor9));
                _Catalog.Add(GbSus2Sus4 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Sus2Sus4));
                _Catalog.Add(GbSus2 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Sus2));
                _Catalog.Add(GbSus4 = ChordFormula.Create(NoteName.Gb, ChordIntervalsEnum.Sus4));
                #endregion NoteName.G♭

                #region NoteName.G
                _Catalog.Add(GAugmented = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Augmented));
                _Catalog.Add(GDominant11 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Dominant11));
                _Catalog.Add(GDominant11b9 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Dominant11b9));
                _Catalog.Add(GDominant13 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Dominant13));
                _Catalog.Add(GDominant13Aug11 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Dominant13Aug11));
                _Catalog.Add(GDominant13b9 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Dominant13b9));
                _Catalog.Add(GMajor6 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Major6));
                _Catalog.Add(GDominant7 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Dominant7));
                _Catalog.Add(GDominant7Sharp9 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Dominant7Sharp9));
                _Catalog.Add(GDominant7Sharp5 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Dominant7Sharp5));
                _Catalog.Add(GDominant7Sharp5b9 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Dominant7Sharp5b9));
                _Catalog.Add(GDominant7Sharp5Nine = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Dominant7Sharp5Nine));
                _Catalog.Add(GDominant7b5 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Dominant7b5));
                _Catalog.Add(GDominant7b5Sharp9 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Dominant7b5Sharp9));
                _Catalog.Add(GDominant7b5b9 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Dominant7b5b9));
                _Catalog.Add(GDominant7b9 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Dominant7b9));
                _Catalog.Add(GDominant7Sus2 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Dominant7Sus2));
                _Catalog.Add(GDominant7Sus4 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Dominant7Sus4));
                _Catalog.Add(GDominant9 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Dominant9));
                _Catalog.Add(GDiminished = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Diminished));
                _Catalog.Add(GDiminished7 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Diminished7));
                _Catalog.Add(GMinor = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Minor));
                _Catalog.Add(GMinorAugmented = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.MinorAugmented));
                _Catalog.Add(GMinor11 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Minor11));
                _Catalog.Add(GMinor13 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Minor13));
                _Catalog.Add(GMinor6 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Minor6));
                _Catalog.Add(GMinor6Add9 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Minor6Add9));
                _Catalog.Add(GMinor7 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Minor7));
                _Catalog.Add(GMinor7Sharp5 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Minor7Sharp5));
                _Catalog.Add(GMinor9 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Minor9));
                _Catalog.Add(GMinorAdd9 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.MinorAdd9));
                _Catalog.Add(GMajor = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Major));
                _Catalog.Add(GMajor11 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Major11));
                _Catalog.Add(GMajor13 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Major13));
                _Catalog.Add(GMajor13Aug11 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Major13Aug11));
                _Catalog.Add(GMajor7 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Major7));
                _Catalog.Add(GMajor7Aug = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Major7Aug));
                _Catalog.Add(GMajor7b5 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Major7b5));
                _Catalog.Add(GMajor9 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Major9));
                _Catalog.Add(GMajor9thSharp11 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Major9thSharp11));
                _Catalog.Add(GMajorMu = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.MajorMu));
                _Catalog.Add(GMinorMajor7 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.MinorMajor7));
                _Catalog.Add(GMinorMajor7Aug = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.MinorMajor7Aug));
                _Catalog.Add(GMinorMajor9 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.MinorMajor9));
                _Catalog.Add(GSus2Sus4 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Sus2Sus4));
                _Catalog.Add(GSus2 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Sus2));
                _Catalog.Add(GSus4 = ChordFormula.Create(NoteName.G, ChordIntervalsEnum.Sus4));
                #endregion NoteName.G

                #region NoteName.G♯
                _Catalog.Add(GSharpAugmented = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Augmented));
                _Catalog.Add(GSharpDominant11 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Dominant11));
                _Catalog.Add(GSharpDominant11b9 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Dominant11b9));
                _Catalog.Add(GSharpDominant13 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Dominant13));
                _Catalog.Add(GSharpDominant13Aug11 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Dominant13Aug11));
                _Catalog.Add(GSharpDominant13b9 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Dominant13b9));
                _Catalog.Add(GSharpMajor6 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Major6));
                _Catalog.Add(GSharpDominant7 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Dominant7));
                _Catalog.Add(GSharpDominant7Sharp9 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Dominant7Sharp9));
                _Catalog.Add(GSharpDominant7Sharp5 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Dominant7Sharp5));
                _Catalog.Add(GSharpDominant7Sharp5b9 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Dominant7Sharp5b9));
                _Catalog.Add(GSharpDominant7Sharp5Nine = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Dominant7Sharp5Nine));
                _Catalog.Add(GSharpDominant7b5 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Dominant7b5));
                _Catalog.Add(GSharpDominant7b5Sharp9 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Dominant7b5Sharp9));
                _Catalog.Add(GSharpDominant7b5b9 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Dominant7b5b9));
                _Catalog.Add(GSharpDominant7b9 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Dominant7b9));
                _Catalog.Add(GSharpDominant7Sus2 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Dominant7Sus2));
                _Catalog.Add(GSharpDominant7Sus4 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Dominant7Sus4));
                _Catalog.Add(GSharpDominant9 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Dominant9));
                _Catalog.Add(GSharpDiminished = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Diminished));
                _Catalog.Add(GSharpDiminished7 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Diminished7));
                _Catalog.Add(GSharpMinor = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Minor));
                _Catalog.Add(GSharpMinorAugmented = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.MinorAugmented));
                _Catalog.Add(GSharpMinor11 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Minor11));
                _Catalog.Add(GSharpMinor13 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Minor13));
                _Catalog.Add(GSharpMinor6 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Minor6));
                _Catalog.Add(GSharpMinor6Add9 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Minor6Add9));
                _Catalog.Add(GSharpMinor7 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Minor7));
                _Catalog.Add(GSharpMinor7Sharp5 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Minor7Sharp5));
                _Catalog.Add(GSharpMinor9 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Minor9));
                _Catalog.Add(GSharpMinorAdd9 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.MinorAdd9));
                _Catalog.Add(GSharpMajor = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Major));
                _Catalog.Add(GSharpMajor11 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Major11));
                _Catalog.Add(GSharpMajor13 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Major13));
                _Catalog.Add(GSharpMajor13Aug11 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Major13Aug11));
                _Catalog.Add(GSharpMajor7 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Major7));
                _Catalog.Add(GSharpMajor7Aug = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Major7Aug));
                _Catalog.Add(GSharpMajor7b5 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Major7b5));
                _Catalog.Add(GSharpMajor9 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Major9));
                _Catalog.Add(GSharpMajor9thSharp11 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Major9thSharp11));
                _Catalog.Add(GSharpMajorMu = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.MajorMu));
                _Catalog.Add(GSharpMinorMajor7 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.MinorMajor7));
                _Catalog.Add(GSharpMinorMajor7Aug = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.MinorMajor7Aug));
                _Catalog.Add(GSharpMinorMajor9 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.MinorMajor9));
                _Catalog.Add(GSharpSus2Sus4 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Sus2Sus4));
                _Catalog.Add(GSharpSus2 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Sus2));
                _Catalog.Add(GSharpSus4 = ChordFormula.Create(NoteName.GSharp, ChordIntervalsEnum.Sus4));
                #endregion NoteName.G♯

                #region NoteName.A♭
                _Catalog.Add(AbAugmented = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Augmented));
                _Catalog.Add(AbDominant11 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Dominant11));
                _Catalog.Add(AbDominant11b9 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Dominant11b9));
                _Catalog.Add(AbDominant13 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Dominant13));
                _Catalog.Add(AbDominant13Aug11 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Dominant13Aug11));
                _Catalog.Add(AbDominant13b9 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Dominant13b9));
                _Catalog.Add(AbMajor6 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Major6));
                _Catalog.Add(AbDominant7 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Dominant7));
                _Catalog.Add(AbDominant7Sharp9 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Dominant7Sharp9));
                _Catalog.Add(AbDominant7Sharp5 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Dominant7Sharp5));
                _Catalog.Add(AbDominant7Sharp5b9 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Dominant7Sharp5b9));
                _Catalog.Add(AbDominant7Sharp5Nine = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Dominant7Sharp5Nine));
                _Catalog.Add(AbDominant7b5 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Dominant7b5));
                _Catalog.Add(AbDominant7b5Sharp9 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Dominant7b5Sharp9));
                _Catalog.Add(AbDominant7b5b9 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Dominant7b5b9));
                _Catalog.Add(AbDominant7b9 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Dominant7b9));
                _Catalog.Add(AbDominant7Sus2 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Dominant7Sus2));
                _Catalog.Add(AbDominant7Sus4 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Dominant7Sus4));
                _Catalog.Add(AbDominant9 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Dominant9));
                _Catalog.Add(AbDiminished = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Diminished));
                _Catalog.Add(AbDiminished7 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Diminished7));
                _Catalog.Add(AbMinor = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Minor));
                _Catalog.Add(AbMinorAugmented = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.MinorAugmented));
                _Catalog.Add(AbMinor11 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Minor11));
                _Catalog.Add(AbMinor13 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Minor13));
                _Catalog.Add(AbMinor6 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Minor6));
                _Catalog.Add(AbMinor6Add9 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Minor6Add9));
                _Catalog.Add(AbMinor7 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Minor7));
                _Catalog.Add(AbMinor7Sharp5 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Minor7Sharp5));
                _Catalog.Add(AbMinor9 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Minor9));
                _Catalog.Add(AbMinorAdd9 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.MinorAdd9));
                _Catalog.Add(AbMajor = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Major));
                _Catalog.Add(AbMajor11 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Major11));
                _Catalog.Add(AbMajor13 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Major13));
                _Catalog.Add(AbMajor13Aug11 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Major13Aug11));
                _Catalog.Add(AbMajor7 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Major7));
                _Catalog.Add(AbMajor7Aug = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Major7Aug));
                _Catalog.Add(AbMajor7b5 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Major7b5));
                _Catalog.Add(AbMajor9 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Major9));
                _Catalog.Add(AbMajor9thSharp11 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Major9thSharp11));
                _Catalog.Add(AbMajorMu = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.MajorMu));
                _Catalog.Add(AbMinorMajor7 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.MinorMajor7));
                _Catalog.Add(AbMinorMajor7Aug = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.MinorMajor7Aug));
                _Catalog.Add(AbMinorMajor9 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.MinorMajor9));
                _Catalog.Add(AbSus2Sus4 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Sus2Sus4));
                _Catalog.Add(AbSus2 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Sus2));
                _Catalog.Add(AbSus4 = ChordFormula.Create(NoteName.Ab, ChordIntervalsEnum.Sus4));
                #endregion NoteName.A♭

                #region NoteName.A
                _Catalog.Add(AAugmented = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Augmented));
                _Catalog.Add(ADominant11 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Dominant11));
                _Catalog.Add(ADominant11b9 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Dominant11b9));
                _Catalog.Add(ADominant13 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Dominant13));
                _Catalog.Add(ADominant13Aug11 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Dominant13Aug11));
                _Catalog.Add(ADominant13b9 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Dominant13b9));
                _Catalog.Add(AMajor6 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Major6));
                _Catalog.Add(ADominant7 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Dominant7));
                _Catalog.Add(ADominant7Sharp9 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Dominant7Sharp9));
                _Catalog.Add(ADominant7Sharp5 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Dominant7Sharp5));
                _Catalog.Add(ADominant7Sharp5b9 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Dominant7Sharp5b9));
                _Catalog.Add(ADominant7Sharp5Nine = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Dominant7Sharp5Nine));
                _Catalog.Add(ADominant7b5 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Dominant7b5));
                _Catalog.Add(ADominant7b5Sharp9 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Dominant7b5Sharp9));
                _Catalog.Add(ADominant7b5b9 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Dominant7b5b9));
                _Catalog.Add(ADominant7b9 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Dominant7b9));
                _Catalog.Add(ADominant7Sus2 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Dominant7Sus2));
                _Catalog.Add(ADominant7Sus4 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Dominant7Sus4));
                _Catalog.Add(ADominant9 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Dominant9));
                _Catalog.Add(ADiminished = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Diminished));
                _Catalog.Add(ADiminished7 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Diminished7));
                _Catalog.Add(AMinor = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Minor));
                _Catalog.Add(AMinorAugmented = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.MinorAugmented));
                _Catalog.Add(AMinor11 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Minor11));
                _Catalog.Add(AMinor13 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Minor13));
                _Catalog.Add(AMinor6 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Minor6));
                _Catalog.Add(AMinor6Add9 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Minor6Add9));
                _Catalog.Add(AMinor7 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Minor7));
                _Catalog.Add(AMinor7Sharp5 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Minor7Sharp5));
                _Catalog.Add(AMinor9 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Minor9));
                _Catalog.Add(AMinorAdd9 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.MinorAdd9));
                _Catalog.Add(AMajor = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Major));
                _Catalog.Add(AMajor11 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Major11));
                _Catalog.Add(AMajor13 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Major13));
                _Catalog.Add(AMajor13Aug11 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Major13Aug11));
                _Catalog.Add(AMajor7 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Major7));
                _Catalog.Add(AMajor7Aug = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Major7Aug));
                _Catalog.Add(AMajor7b5 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Major7b5));
                _Catalog.Add(AMajor9 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Major9));
                _Catalog.Add(AMajor9thSharp11 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Major9thSharp11));
                _Catalog.Add(AMajorMu = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.MajorMu));
                _Catalog.Add(AMinorMajor7 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.MinorMajor7));
                _Catalog.Add(AMinorMajor7Aug = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.MinorMajor7Aug));
                _Catalog.Add(AMinorMajor9 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.MinorMajor9));
                _Catalog.Add(ASus2Sus4 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Sus2Sus4));
                _Catalog.Add(ASus2 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Sus2));
                _Catalog.Add(ASus4 = ChordFormula.Create(NoteName.A, ChordIntervalsEnum.Sus4));
                #endregion NoteName.A

                #region NoteName.A♯
                _Catalog.Add(ASharpAugmented = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Augmented));
                _Catalog.Add(ASharpDominant11 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Dominant11));
                _Catalog.Add(ASharpDominant11b9 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Dominant11b9));
                _Catalog.Add(ASharpDominant13 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Dominant13));
                _Catalog.Add(ASharpDominant13Aug11 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Dominant13Aug11));
                _Catalog.Add(ASharpDominant13b9 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Dominant13b9));
                _Catalog.Add(ASharpMajor6 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Major6));
                _Catalog.Add(ASharpDominant7 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Dominant7));
                _Catalog.Add(ASharpDominant7Sharp9 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Dominant7Sharp9));
                _Catalog.Add(ASharpDominant7Sharp5 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Dominant7Sharp5));
                _Catalog.Add(ASharpDominant7Sharp5b9 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Dominant7Sharp5b9));
                _Catalog.Add(ASharpDominant7Sharp5Nine = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Dominant7Sharp5Nine));
                _Catalog.Add(ASharpDominant7b5 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Dominant7b5));
                _Catalog.Add(ASharpDominant7b5Sharp9 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Dominant7b5Sharp9));
                _Catalog.Add(ASharpDominant7b5b9 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Dominant7b5b9));
                _Catalog.Add(ASharpDominant7b9 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Dominant7b9));
                _Catalog.Add(ASharpDominant7Sus2 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Dominant7Sus2));
                _Catalog.Add(ASharpDominant7Sus4 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Dominant7Sus4));
                _Catalog.Add(ASharpDominant9 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Dominant9));
                _Catalog.Add(ASharpDiminished = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Diminished));
                _Catalog.Add(ASharpDiminished7 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Diminished7));
                _Catalog.Add(ASharpMinor = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Minor));
                _Catalog.Add(ASharpMinorAugmented = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.MinorAugmented));
                _Catalog.Add(ASharpMinor11 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Minor11));
                _Catalog.Add(ASharpMinor13 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Minor13));
                _Catalog.Add(ASharpMinor6 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Minor6));
                _Catalog.Add(ASharpMinor6Add9 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Minor6Add9));
                _Catalog.Add(ASharpMinor7 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Minor7));
                _Catalog.Add(ASharpMinor7Sharp5 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Minor7Sharp5));
                _Catalog.Add(ASharpMinor9 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Minor9));
                _Catalog.Add(ASharpMinorAdd9 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.MinorAdd9));
                _Catalog.Add(ASharpMajor = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Major));
                _Catalog.Add(ASharpMajor11 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Major11));
                _Catalog.Add(ASharpMajor13 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Major13));
                _Catalog.Add(ASharpMajor13Aug11 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Major13Aug11));
                _Catalog.Add(ASharpMajor7 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Major7));
                _Catalog.Add(ASharpMajor7Aug = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Major7Aug));
                _Catalog.Add(ASharpMajor7b5 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Major7b5));
                _Catalog.Add(ASharpMajor9 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Major9));
                _Catalog.Add(ASharpMajor9thSharp11 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Major9thSharp11));
                _Catalog.Add(ASharpMajorMu = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.MajorMu));
                _Catalog.Add(ASharpMinorMajor7 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.MinorMajor7));
                _Catalog.Add(ASharpMinorMajor7Aug = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.MinorMajor7Aug));
                _Catalog.Add(ASharpMinorMajor9 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.MinorMajor9));
                _Catalog.Add(ASharpSus2Sus4 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Sus2Sus4));
                _Catalog.Add(ASharpSus2 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Sus2));
                _Catalog.Add(ASharpSus4 = ChordFormula.Create(NoteName.ASharp, ChordIntervalsEnum.Sus4));
                #endregion NoteName.A♯

                #region NoteName.B♭
                _Catalog.Add(BbAugmented = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Augmented));
                _Catalog.Add(BbDominant11 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Dominant11));
                _Catalog.Add(BbDominant11b9 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Dominant11b9));
                _Catalog.Add(BbDominant13 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Dominant13));
                _Catalog.Add(BbDominant13Aug11 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Dominant13Aug11));
                _Catalog.Add(BbDominant13b9 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Dominant13b9));
                _Catalog.Add(BbMajor6 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Major6));
                _Catalog.Add(BbDominant7 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Dominant7));
                _Catalog.Add(BbDominant7Sharp9 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Dominant7Sharp9));
                _Catalog.Add(BbDominant7Sharp5 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Dominant7Sharp5));
                _Catalog.Add(BbDominant7Sharp5b9 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Dominant7Sharp5b9));
                _Catalog.Add(BbDominant7Sharp5Nine = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Dominant7Sharp5Nine));
                _Catalog.Add(BbDominant7b5 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Dominant7b5));
                _Catalog.Add(BbDominant7b5Sharp9 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Dominant7b5Sharp9));
                _Catalog.Add(BbDominant7b5b9 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Dominant7b5b9));
                _Catalog.Add(BbDominant7b9 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Dominant7b9));
                _Catalog.Add(BbDominant7Sus2 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Dominant7Sus2));
                _Catalog.Add(BbDominant7Sus4 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Dominant7Sus4));
                _Catalog.Add(BbDominant9 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Dominant9));
                _Catalog.Add(BbDiminished = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Diminished));
                _Catalog.Add(BbDiminished7 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Diminished7));
                _Catalog.Add(BbMinor = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Minor));
                _Catalog.Add(BbMinorAugmented = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.MinorAugmented));
                _Catalog.Add(BbMinor11 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Minor11));
                _Catalog.Add(BbMinor13 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Minor13));
                _Catalog.Add(BbMinor6 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Minor6));
                _Catalog.Add(BbMinor6Add9 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Minor6Add9));
                _Catalog.Add(BbMinor7 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Minor7));
                _Catalog.Add(BbMinor7Sharp5 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Minor7Sharp5));
                _Catalog.Add(BbMinor9 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Minor9));
                _Catalog.Add(BbMinorAdd9 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.MinorAdd9));
                _Catalog.Add(BbMajor = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Major));
                _Catalog.Add(BbMajor11 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Major11));
                _Catalog.Add(BbMajor13 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Major13));
                _Catalog.Add(BbMajor13Aug11 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Major13Aug11));
                _Catalog.Add(BbMajor7 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Major7));
                _Catalog.Add(BbMajor7Aug = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Major7Aug));
                _Catalog.Add(BbMajor7b5 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Major7b5));
                _Catalog.Add(BbMajor9 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Major9));
                _Catalog.Add(BbMajor9thSharp11 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Major9thSharp11));
                _Catalog.Add(BbMajorMu = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.MajorMu));
                _Catalog.Add(BbMinorMajor7 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.MinorMajor7));
                _Catalog.Add(BbMinorMajor7Aug = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.MinorMajor7Aug));
                _Catalog.Add(BbMinorMajor9 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.MinorMajor9));
                _Catalog.Add(BbSus2Sus4 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Sus2Sus4));
                _Catalog.Add(BbSus2 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Sus2));
                _Catalog.Add(BbSus4 = ChordFormula.Create(NoteName.Bb, ChordIntervalsEnum.Sus4));
                #endregion NoteName.B♭

                #region NoteName.B
                _Catalog.Add(BAugmented = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Augmented));
                _Catalog.Add(BDominant11 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Dominant11));
                _Catalog.Add(BDominant11b9 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Dominant11b9));
                _Catalog.Add(BDominant13 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Dominant13));
                _Catalog.Add(BDominant13Aug11 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Dominant13Aug11));
                _Catalog.Add(BDominant13b9 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Dominant13b9));
                _Catalog.Add(BMajor6 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Major6));
                _Catalog.Add(BDominant7 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Dominant7));
                _Catalog.Add(BDominant7Sharp9 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Dominant7Sharp9));
                _Catalog.Add(BDominant7Sharp5 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Dominant7Sharp5));
                _Catalog.Add(BDominant7Sharp5b9 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Dominant7Sharp5b9));
                _Catalog.Add(BDominant7Sharp5Nine = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Dominant7Sharp5Nine));
                _Catalog.Add(BDominant7b5 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Dominant7b5));
                _Catalog.Add(BDominant7b5Sharp9 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Dominant7b5Sharp9));
                _Catalog.Add(BDominant7b5b9 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Dominant7b5b9));
                _Catalog.Add(BDominant7b9 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Dominant7b9));
                _Catalog.Add(BDominant7Sus2 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Dominant7Sus2));
                _Catalog.Add(BDominant7Sus4 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Dominant7Sus4));
                _Catalog.Add(BDominant9 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Dominant9));
                _Catalog.Add(BDiminished = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Diminished));
                _Catalog.Add(BDiminished7 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Diminished7));
                _Catalog.Add(BMinor = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Minor));
                _Catalog.Add(BMinorAugmented = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.MinorAugmented));
                _Catalog.Add(BMinor11 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Minor11));
                _Catalog.Add(BMinor13 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Minor13));
                _Catalog.Add(BMinor6 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Minor6));
                _Catalog.Add(BMinor6Add9 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Minor6Add9));
                _Catalog.Add(BMinor7 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Minor7));
                _Catalog.Add(BMinor7Sharp5 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Minor7Sharp5));
                _Catalog.Add(BMinor9 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Minor9));
                _Catalog.Add(BMinorAdd9 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.MinorAdd9));
                _Catalog.Add(BMajor = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Major));
                _Catalog.Add(BMajor11 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Major11));
                _Catalog.Add(BMajor13 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Major13));
                _Catalog.Add(BMajor13Aug11 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Major13Aug11));
                _Catalog.Add(BMajor7 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Major7));
                _Catalog.Add(BMajor7Aug = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Major7Aug));
                _Catalog.Add(BMajor7b5 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Major7b5));
                _Catalog.Add(BMajor9 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Major9));
                _Catalog.Add(BMajor9thSharp11 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Major9thSharp11));
                _Catalog.Add(BMajorMu = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.MajorMu));
                _Catalog.Add(BMinorMajor7 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.MinorMajor7));
                _Catalog.Add(BMinorMajor7Aug = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.MinorMajor7Aug));
                _Catalog.Add(BMinorMajor9 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.MinorMajor9));
                _Catalog.Add(BSus2Sus4 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Sus2Sus4));
                _Catalog.Add(BSus2 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Sus2));
                _Catalog.Add(BSus4 = ChordFormula.Create(NoteName.B, ChordIntervalsEnum.Sus4));
                #endregion NoteName.B

                #region NoteName.C♭
                _Catalog.Add(CbAugmented = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Augmented));
                _Catalog.Add(CbDominant11 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Dominant11));
                _Catalog.Add(CbDominant11b9 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Dominant11b9));
                _Catalog.Add(CbDominant13 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Dominant13));
                _Catalog.Add(CbDominant13Aug11 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Dominant13Aug11));
                _Catalog.Add(CbDominant13b9 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Dominant13b9));
                _Catalog.Add(CbMajor6 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Major6));
                _Catalog.Add(CbDominant7 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Dominant7));
                _Catalog.Add(CbDominant7Sharp9 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Dominant7Sharp9));
                _Catalog.Add(CbDominant7Sharp5 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Dominant7Sharp5));
                _Catalog.Add(CbDominant7Sharp5b9 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Dominant7Sharp5b9));
                _Catalog.Add(CbDominant7Sharp5Nine = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Dominant7Sharp5Nine));
                _Catalog.Add(CbDominant7b5 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Dominant7b5));
                _Catalog.Add(CbDominant7b5Sharp9 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Dominant7b5Sharp9));
                _Catalog.Add(CbDominant7b5b9 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Dominant7b5b9));
                _Catalog.Add(CbDominant7b9 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Dominant7b9));
                _Catalog.Add(CbDominant7Sus2 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Dominant7Sus2));
                _Catalog.Add(CbDominant7Sus4 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Dominant7Sus4));
                _Catalog.Add(CbDominant9 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Dominant9));
                _Catalog.Add(CbDiminished = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Diminished));
                _Catalog.Add(CbDiminished7 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Diminished7));
                _Catalog.Add(CbMinor = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Minor));
                _Catalog.Add(CbMinorAugmented = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.MinorAugmented));
                _Catalog.Add(CbMinor11 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Minor11));
                _Catalog.Add(CbMinor13 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Minor13));
                _Catalog.Add(CbMinor6 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Minor6));
                _Catalog.Add(CbMinor6Add9 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Minor6Add9));
                _Catalog.Add(CbMinor7 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Minor7));
                _Catalog.Add(CbMinor7Sharp5 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Minor7Sharp5));
                _Catalog.Add(CbMinor9 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Minor9));
                _Catalog.Add(CbMinorAdd9 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.MinorAdd9));
                _Catalog.Add(CbMajor = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Major));
                _Catalog.Add(CbMajor11 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Major11));
                _Catalog.Add(CbMajor13 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Major13));
                _Catalog.Add(CbMajor13Aug11 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Major13Aug11));
                _Catalog.Add(CbMajor7 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Major7));
                _Catalog.Add(CbMajor7Aug = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Major7Aug));
                _Catalog.Add(CbMajor7b5 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Major7b5));
                _Catalog.Add(CbMajor9 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Major9));
                _Catalog.Add(CbMajor9thSharp11 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Major9thSharp11));
                _Catalog.Add(CbMajorMu = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.MajorMu));
                _Catalog.Add(CbMinorMajor7 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.MinorMajor7));
                _Catalog.Add(CbMinorMajor7Aug = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.MinorMajor7Aug));
                _Catalog.Add(CbMinorMajor9 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.MinorMajor9));
                _Catalog.Add(CbSus2Sus4 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Sus2Sus4));
                _Catalog.Add(CbSus2 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Sus2));
                _Catalog.Add(CbSus4 = ChordFormula.Create(NoteName.Cb, ChordIntervalsEnum.Sus4));
                #endregion NoteName.C♭

                #endregion Instantiate static chord _Catalog.
            }
            catch (Exception)
            {
                throw;
            }

            try
            {
                AddKeys();
            }
            catch (Exception)
            {
                throw;
            }
        }


        #region Code Generation
        private static void GenerateCodeForStaticChord_Catalog()
        {
            var keySignatures = new List<KeySignature>();
            foreach (var key in KeySignature.InternalCatalog)
            {
                keySignatures.Add(key);
            }

            var chordTypes = Eric.Morrison.Harmony.Chords.ChordType.Catalog;
            var noteNames = new List<NoteName>();
            foreach (var noteName in NoteName.Catalog)
            {
                noteNames.Add(noteName);
            }

            GenerateCode_staticChords_Declarations(keySignatures,
                chordTypes,
                noteNames);
            GenerateCode_CreateChordCatalog_Method(keySignatures,
                chordTypes,
                noteNames);
            GenerateCode_AddKeys_Method();
            new object();
        }

        private static void GenerateCode_staticChords_Declarations(List<KeySignature> keySignatures,
            List<ChordIntervalsEnum> chordTypes,
            List<NoteName> noteNames)
        {//static public readonly ChordFormula C7;

            using (var writer = new IndentedTextWriter(new StringWriter()))
            {
                writer.WriteLine("");
                writer.Indent = 2;
                writer.WriteLine($"#region static Chords{Environment.NewLine}");

                foreach (var nn in noteNames)
                {
                    var nnName = nn.Name.Replace("♭", "b")
                        .Replace("♯", "Sharp");

                    foreach (var ct in chordTypes)
                    {
                        if ((nn == NoteName.BSharp && ct == ChordIntervalsEnum.Dominant7Sharp9)
                            || (nn == NoteName.ESharp && ct == ChordIntervalsEnum.Dominant7Sharp9))
                        {// Don't generate chords with triple #s.^
                        }
                        else
                        {
                            var code = $"static public readonly ChordFormula {nnName}{ct};";
                            writer.WriteLine(code);
                        }
                    }
                }
                writer.WriteLine($"#endregion static Chords{Environment.NewLine}");
                Debug.WriteLine(writer.InnerWriter.ToString());
            }
        }

        private static void GenerateCode_CreateChordCatalog_Method(List<KeySignature> keySignatures,
            List<ChordIntervalsEnum> chordTypes,
            List<NoteName> noteNames)
        {//ChordFormula.AddToCatalog(NoteName.BSharp, ChordIntervalsEnum.Augmented, null);
            using (var writer = new IndentedTextWriter(new StringWriter()))
            {
                writer.WriteLine("");
                writer.Indent = 2;
                writer.WriteLine("static void CreateChordCatalog()");
                writer.WriteLine("{");
                writer.Indent = 3;


                writer.WriteLine("#region Instantiate static chord _Catalog.");
                var nnTuples = GenerateCode_GetNoteNames_ForCode();
                foreach (var tuple in nnTuples)
                {
                    var nn = tuple.Item1;
                    var nnName = tuple.Item2;
                    writer.WriteLine($"#region NoteName.{nn}");

                    foreach (var ct in chordTypes)
                    {
                        if ((nn == NoteName.BSharp && ct == ChordIntervalsEnum.Dominant7Sharp9)
                            || (nn == NoteName.ESharp && ct == ChordIntervalsEnum.Dominant7Sharp9))
                        {// Don't generate chords with triple #s.
                        }
                        else
                        {
                            var code = $"_Catalog.Add({nnName}{ct} = ChordFormula.Create(NoteName.{nnName}, ChordIntervalsEnum.{ct}));";
                            writer.WriteLine(code);
                        }
                        new object();
                    }
                    writer.WriteLine($"#endregion NoteName.{nn}{Environment.NewLine}");

                }
                writer.WriteLine("#endregion Instantiate static chord _Catalog.");

                writer.Indent = 2;
                writer.WriteLine("}");

                Debug.WriteLine(writer.InnerWriter.ToString());

            }
            new object();
        }

        private static void GenerateCode_AddKeys_Method()
        {
            var dict = new Dictionary<ChordFormula, HashSet<KeySignature>>();
            foreach (var formula in ChordFormula.Catalog)
            {
                foreach (var key in KeySignature.InternalCatalog)
                {
                    if (IsDiatonicEnum.Yes == key.IsDiatonic(formula))
                    {
                        if (!dict.ContainsKey(formula))
                        {
                            dict[formula] = new HashSet<KeySignature>();
                        }
                        dict[formula].Add(key);
                    }
                }
            }

            var unpaired = new HashSet<ChordFormula>();
            var formulas = ChordFormula.Catalog.ToList();
            foreach (var formula in formulas)
            {
                if (!dict.Keys.Contains(formula))
                {
                    unpaired.Add(formula);
                }
            }

            var pairedFormuas = new List<ChordFormula>();
            foreach (var formula in dict.Keys)
            {
                var keys = dict[formula];
                foreach (var key in keys)
                {
                    if (null != key)
                    {
                        formula.Add(key);
                    }
                }
                pairedFormuas.Add(formula);
            }

            using (var writer = new IndentedTextWriter(new StringWriter()))
            {
                writer.WriteLine("");
                writer.Indent = 2;
                writer.WriteLine(@"static void AddKeys()");
                writer.WriteLine("{");
                writer.Indent = 3;

                foreach (var formula in pairedFormuas)
                {
                    foreach (var key in formula.Keys)
                    {
                        var code = $"ChordFormula.Catalog[\"{formula.Name}\"].Add(KeySignature.Catalog[\"{key.Name}\"]);";
                        writer.WriteLine(code);
                    }
                    new object();
                }

                writer.Indent = 2;
                writer.WriteLine("}");

                Debug.WriteLine(writer.InnerWriter.ToString());
            }

            new object();
        }

        static List<ValueTuple<NoteName, string>> GenerateCode_GetNoteNames_ForCode()
        {
            var result = new List<ValueTuple<NoteName, string>>();
            foreach (var nn in NoteName.Catalog)
            {
                var nnName = nn.Name.Replace("♭", "b")
                    .Replace("♯", "Sharp");
                result.Add(new ValueTuple<NoteName, string>(nn, nnName));
            }
            return result;
        }

        #endregion

    }//class

    public class CatalogBase<T> : IEnumerable<T>, IList<T> where T : IHasName
    {
        List<T> _Catalog = new List<T>();

        public T this[string name]
        {
            get { return this._Catalog.FirstOrDefault(x => x.Name == name); }
            set { }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)this._Catalog).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this._Catalog).GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return ((IList<T>)this._Catalog).IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            ((IList<T>)this._Catalog).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<T>)this._Catalog).RemoveAt(index);
        }

        public T this[int index] { get => ((IList<T>)this._Catalog)[index]; set => ((IList<T>)this._Catalog)[index] = value; }

        public void Add(T item)
        {
            ((ICollection<T>)this._Catalog).Add(item);
        }

        public void Clear()
        {
            ((ICollection<T>)this._Catalog).Clear();
        }

        public bool Contains(T item)
        {
            return ((ICollection<T>)this._Catalog).Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ((ICollection<T>)this._Catalog).CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return ((ICollection<T>)this._Catalog).Remove(item);
        }

        public int Count => ((ICollection<T>)this._Catalog).Count;

        public bool IsReadOnly => ((ICollection<T>)this._Catalog).IsReadOnly;
    }

}//ns
