using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony
{
    public interface IMusicXmlParser
    {
        NoteName ParseNoteName(XElement pitch);
        Task TiedNoteResolvedAsync(UnresolvedTiedNote utn);
    }
}