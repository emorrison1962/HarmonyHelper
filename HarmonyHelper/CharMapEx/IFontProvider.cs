namespace NeckDiagrams.Controls
{
    public interface IFontProvider
    {
        string SelectedFont { get; }

        event EventHandler<string> FontChanged;
    }
}