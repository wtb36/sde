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
			ISDE sde = new ConstXs(1, -0.1);
			ISdeScheme scheme = new ExplicitEuler(sde);
			ISdeScheme scheme1 = new KP11_1_3(sde);
			double t = 0;
			double t1 = 0;
			double x = 1;
			double x1 = 1;
			double Z;
			Console.WriteLine("{0} {1}", t, x);
			while (t < 10)
			{
				Z = NormalGenerator.Value;
				scheme.Step(ref t, ref x, 0.01, Z);
				scheme1.Step(ref t1, ref x1, 0.01, Z);
				Console.WriteLine("{0} {1} {2}", t, x, x1);
			}
		}
	}
}
