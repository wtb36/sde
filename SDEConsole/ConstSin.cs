using System;
using System.Collections.Generic;
using System.Text;
using SDELib;

namespace SDEConsole
{
	internal class ConstSin : ISDE
	{
		private double m_Drift;
		private double m_Drift2;

		public ConstSin(double Drift)
		{
			m_Drift = Drift;
			m_Drift2 = m_Drift * m_Drift;
		}

		public void GetValue(double t, double x, ref double Drift, ref double Diffusion)
		{
			Drift = -0.5 * m_Drift2 * x;
			Diffusion = m_Drift * Math.Sqrt(1 - x * x);
		}

		public double GetAnalytic(double t, double X0, double Wt)
		{
			return Math.Sin(m_Drift * Wt + Math.Asin(X0));
		}
	}
}
