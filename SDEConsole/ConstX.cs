using System;
using System.Collections.Generic;
using System.Text;
using SDELib;

namespace SDEConsole
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
	}
}
