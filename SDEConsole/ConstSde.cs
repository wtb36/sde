using System;
using System.Collections.Generic;
using System.Text;
using SDELib;

namespace SDEConsole
{
	class ConstSde : ISDE
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
	}
}
