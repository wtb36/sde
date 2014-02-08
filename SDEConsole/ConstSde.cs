using System;
using System.Collections.Generic;
using System.Text;

namespace SDELib
{
	public class ConstSde : ISDE
	{
		private double m_Drift;

		private double m_Diffusion;

		public ConstSde(double Drift, double Diffusion)
		{
			m_Drift = Drift;
			m_Diffusion = Diffusion;
		}

		public void GetValue(double t, double x, ref double Drift, ref double Diffusion)
		{
			Drift = m_Drift;
			Diffusion = m_Diffusion;
		}

		public double GetAnalytic(double t, double X0, double Wt)
		{
			return X0 + m_Drift * t + m_Diffusion * Wt;
		}
	}
}
