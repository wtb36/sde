using System;
using System.Collections.Generic;
using System.Text;

namespace SDELib
{
	public interface ISdeScheme
	{
		void Step(ref double t, ref double x, double dt, double[] Z);
		void Step(ref double t, double tEval,
				ref double x, double xEval, double dt, double[] Z);
	}
}
