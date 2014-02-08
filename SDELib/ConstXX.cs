using System;
using System.Collections.Generic;
using System.Text;

namespace SDELib
{
	public class ConstXX : ISDE
	{
		private double m_Drift;

		private double m_Diffusion;

		public ConstXX(double Drift, double Diffusion)
		{
			m_Drift = Drift;
			m_Diffusion = Diffusion;
		}

		public void GetValue(double t, double x, ref double Drift, ref double Diffusion)
		{
			Drift = x * x * m_Drift;
			Diffusion = x * x * m_Diffusion;
		}

		public double GetAnalytic(double t, double X0, double Wt)
		{
			return 0;
		}
	}
}
