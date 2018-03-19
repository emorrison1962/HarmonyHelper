using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eric.Morrison.Harmony.Debugging
{
	static partial class Extensions
	{
		static string ToBitsString(this uint src)
		{
			var sb = new StringBuilder();
			var bytes = BitConverter.GetBytes(src);
			for (int i = 1; i >= 0; --i)
			{
				sb.AppendFormat("{0} ", Convert.ToString(bytes[i], 2).PadLeft(8, '0'));
			}
			return sb.ToString().Trim();
		}


	}
}
