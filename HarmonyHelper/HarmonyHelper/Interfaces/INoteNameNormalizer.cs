using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony
{
	public interface INoteNameNormalizer
	{
		NoteName GetNormalized(NoteName nn, Interval interval);
	}
}
