using System;
using System.Collections.Generic;
using System.Text;
using SDELib;

namespace SDEConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			ISDE sde = new ConstXs(0.1, -0.1);
			ISdeScheme scheme = new ExplicitEuler(sde);
			ISdeScheme scheme1 = new KP11_1_3(sde);
			ISdeScheme scheme2 = new O1_5expl(sde);
			double t = 0;
			double t1 = 0;
			double t2 = 0;
			double x = 1;
			double x1 = 1;
			double x2 = 1;
			double[] Z = new double[2];
			Console.WriteLine("{0} {1} {2} {3}", t, x, x1, x2);
			while (t < 10)
			{
				Z[0] = NormalGenerator.Value;
				Z[1] = NormalGenerator.Value;
				scheme.Step(ref t, ref x, 0.01, Z);
				scheme1.Step(ref t1, ref x1, 0.01, Z);
				scheme2.Step(ref t2, ref x2, 0.01, Z);
				Console.WriteLine("{0} {1} {2} {3}", t, x, x1, x2);
			}
		}
	}
}
