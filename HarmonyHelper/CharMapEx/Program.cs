namespace CharMapEx
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new CharMapExForm());
        }
    }
}
public class Rootobject
{
    public string fontName { get; set; }
    public float fontVersion { get; set; }
    public Engravingdefaults engravingDefaults { get; set; }
    public Glyphadvancewidths glyphAdvanceWidths { get; set; }
    public Glyphbboxes glyphBBoxes { get; set; }
    public Glyphswithalternates glyphsWithAlternates { get; set; }
    public Glyphswithanchors glyphsWithAnchors { get; set; }
    public Ligatures ligatures { get; set; }
    public Optionalglyphs optionalGlyphs { get; set; }
    public Sets sets { get; set; }
}

