using System;

namespace SDELib
{
	public class O1_5expl : ISdeScheme
	{
		private ISDE m_Sde;
		private double m_Drift;
		private double m_DriftP;
		private double m_DriftM;
		private double m_Diff;
		private double m_Diff1P;
		private double m_Diff2P;
		private double m_Diff1M;
		private double m_Diff2M;
		private double m_Sdt;
		private double m_YP;
		private double m_YM;
		private double m_PhiP;
		private double m_PhiM;
		private double m_DW;
		private double m_DZ;

		public O1_5expl(ISDE Sde)
		{
			m_Sde = Sde;
		}

		public void Step(ref double t, ref double x, double dt, double[] Z)
		{
			m_Sdt = Math.Sqrt(dt);

			m_DW = Z[0] * m_Sdt;
			m_DZ = 0.5 * m_Sdt * dt * (Z[0] + Z[1] / Math.Sqrt(3));

			m_Sde.GetValue(t, x, ref m_Drift, ref m_Diff);
			m_YP = x + m_Drift * dt + m_Diff * m_Sdt;
			m_YM = x + m_Drift * dt - m_Diff * m_Sdt;
			m_Sde.GetValue(t, m_YP, ref m_DriftP, ref m_Diff1P);
			m_Sde.GetValue(t, m_YM, ref m_DriftM, ref m_Diff1M);
			m_PhiP = m_YP + m_Diff1P * m_Sdt;
			m_PhiM = m_YP - m_Diff1P * m_Sdt;
			m_Sde.GetValue(t, m_PhiP, ref m_YP, ref m_Diff2P);
			m_Sde.GetValue(t, m_PhiM, ref m_YP, ref m_Diff2M);

			x += m_Diff * m_DW + (m_DriftP - m_DriftM) * m_DZ * 0.5 / m_Sdt
				+ (m_DriftP + 2 * m_Drift + m_DriftM) * dt / 4
				+ (m_Diff1P - m_Diff1M) * (m_DW * m_DW - dt) / (4 * m_Sdt)
				+ (m_Diff1P - 2 * m_Diff + m_Diff1M) * (dt * m_DW - m_DZ) * 0.5 * dt
				+ (m_Diff2P - m_Diff2M - m_Diff1P + m_Diff1M)
				* (m_DW * m_DW / 3 - dt) * m_DW;
		}

		public void Step(ref double t, double tEval,
				ref double x, double xEval, double dt, double[] Z)
		{
			return;
		}
	}
}
