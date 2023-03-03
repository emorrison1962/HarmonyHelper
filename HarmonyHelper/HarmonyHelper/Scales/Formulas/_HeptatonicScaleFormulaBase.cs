using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eric.Morrison.Harmony.Intervals;

namespace Eric.Morrison.Harmony.Scales
{
	abstract public class HeptatonicScaleFormulaBase : ScaleFormulaBase
	{
		public ScaleToneInterval Second { get; protected set; }
		public ScaleToneInterval Third { get; protected set; }
		public ScaleToneInterval Fourth { get; protected set; }
		public ScaleToneInterval Fifth { get; protected set; }
		public ScaleToneInterval Sixth { get; protected set; }
		public ScaleToneInterval Seventh { get; protected set; }

		public HeptatonicScaleFormulaBase(KeySignature key) : base(key)
		{
		}
	}

}
