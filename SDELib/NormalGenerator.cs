using System;
using System.Collections.Generic;
using System.Text;

namespace SDELib
{
	public class NormalGenerator
	{
		private static double m_Next = double.NaN;
		private static double m_This = double.NaN;
		private static double m_R01;
		private const double pi2 = 2 * Math.PI;
		private static Random m_Rng = new Random();
		public static double Value
		{
			get
			{
				if (!Double.IsNaN(m_Next))
				{
					m_This = m_Next;
					m_Next = double.NaN;
					return m_This;
				}
				m_This = -Math.Log(m_Rng.NextDouble());
				m_R01 = m_Rng.NextDouble();
				m_Next = m_This * Math.Cos(pi2 * m_R01);
				return m_This * Math.Sin(pi2 * m_R01);
			}
		}
	}
}
