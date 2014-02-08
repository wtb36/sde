using System;
using System.Collections.Generic;
using System.Text;

namespace SDELib
{
	public interface ISDE
	{
		void GetValue(double t, double x, ref double Drift, ref double Diffusion);
		double GetAnalytic(double t, double X0, double Wt);
	}
}
