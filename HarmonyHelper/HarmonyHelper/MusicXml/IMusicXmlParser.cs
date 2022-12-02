using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony.MusicXml
{
    public interface IMusicXmlParser
    {
        Note Parse_HarmonyHelper_Note(XElement pitch);
        Task ResolveTiedNote(TiedNoteContext utn);
        int ParseDuration(XElement note);
    }
}