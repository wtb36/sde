using System;
using System.Collections.Generic;
using System.Text;

namespace SDELib
{
	public class KP11_1_3 : ISdeScheme
	{
		private ISDE m_Sde;

		private double m_Drift;

		private double m_Diffusion;

		private double m_Diff2;

		private double m_Y;

		private double m_Sdt;

		private double m_Dummy;

		public KP11_1_3(ISDE Sde)
		{
			m_Sde = Sde;
		}

		#region ISdeScheme Members

		public void Step(ref double t, ref double x, double dt, double[] Z)
		{
			m_Sdt = Math.Sqrt(dt);

			m_Sde.GetValue(t, x, ref m_Drift, ref m_Diffusion);
			m_Y = x + m_Drift * dt + m_Diffusion * m_Sdt;
			m_Sde.GetValue(t, m_Y, ref m_Dummy, ref m_Diff2);

			t += dt;
			x += m_Drift * dt + m_Diffusion * m_Sdt * Z[0]
				+ 0.5 * (m_Diff2 - m_Diffusion) * (Z[0] * Z[0] - 1) * m_Sdt;
		}

		public void Step(ref double t, double tEval,
				ref double x, double xEval, double dt, double[] Z)
		{
			m_Sdt = Math.Sqrt(dt);

			m_Sde.GetValue(tEval, xEval, ref m_Drift, ref m_Diffusion);
			m_Y = x + m_Drift * dt + m_Diffusion * m_Sdt;
			m_Sde.GetValue(tEval, m_Y, ref m_Dummy, ref m_Diff2);

			t += dt;
			x += m_Drift * dt + m_Diffusion * m_Sdt * Z[0]
				+ 0.5 * (m_Diff2 - m_Diffusion) * (Z[0] * Z[0] - 1) * m_Sdt;
		}

		#endregion

	}
}
