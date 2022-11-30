using System.Threading.Tasks;
using System.Xml.Linq;

namespace Eric.Morrison.Harmony
{
    public interface IMusicXmlParser
    {
        NoteName ParsePitch(XElement pitch);
        Task TiedNoteResolvedAsync(UnresolvedTiedNote utn);
    }
}