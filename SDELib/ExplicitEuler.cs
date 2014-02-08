using System;
using System.Collections.Generic;
using System.Text;

namespace SDELib
{
	public class ExplicitEuler : ISdeScheme
	{
		private ISDE m_Sde;

		private double m_Drift;

		private double m_Diffusion;

		public ExplicitEuler(ISDE Sde)
		{
			m_Sde = Sde;
		}

		#region ISdeScheme Members

		public void Step(ref double t, ref double x, double dt, double[] Z)
		{
			m_Sde.GetValue(t, x, ref m_Drift, ref m_Diffusion);
			t += dt;
			x += m_Drift * dt + m_Diffusion * Z[0] * Math.Sqrt(dt);
		}

		#endregion
	}
}
