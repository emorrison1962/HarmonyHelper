using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony
{
    public interface IMusicXmlParser
    {
        Note Parse_HarmonyHelper_Note(XElement pitch);
        Task TiedNoteResolvedAsync(UnresolvedTiedNote utn);
    }
}