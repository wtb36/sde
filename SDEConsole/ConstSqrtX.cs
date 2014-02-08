using System;
using System.Collections.Generic;
using System.Text;
using SDELib;

namespace SDEConsole
{
	internal class ConstSqrtX : ISDE
	{
		private double m_Drift;

		private double m_Diffusion;

		public ConstSqrtX(double Drift, double Diffusion)
		{
			m_Drift = Drift;
			m_Diffusion = Diffusion;
		}

		public void GetValue(double t, double x, ref double Drift, ref double Diffusion)
		{
			Drift = Math.Sqrt(x) * m_Drift;
			Diffusion = Math.Sqrt(x) * m_Diffusion;
		}

		public double GetAnalytic(double t, double X0, double Wt)
		{
			return 0;
		}
	}
}
