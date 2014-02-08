using System;
using System.Collections.Generic;
using System.Text;

namespace SDELib
{
	internal class ConstX : ISDE
	{
		private double m_Drift;

		private double m_Diffusion;

		public ConstX(double Drift, double Diffusion)
		{
			m_Drift = Drift;
			m_Diffusion = Diffusion;
		}

		public void GetValue(double t, double x, ref double Drift, ref double Diffusion)
		{
			Drift = x * m_Drift;
			Diffusion = x * m_Diffusion;
		}

		public double GetAnalytic(double t, double X0, double Wt)
		{
			return X0 * Math.Exp((m_Drift - 0.5 * m_Diffusion * m_Diffusion) * t
				+ m_Diffusion * Wt);
		}
	}
}
