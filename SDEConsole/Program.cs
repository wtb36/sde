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
			double dt = 0.001;
			double T = 1;
			if (args.Length > 0)
				dt = Double.Parse(args[0]);
			if (args.Length > 1)
				T = Double.Parse(args[1]);

			ISDE sde = new ConstX(.5, 0.2);
			ISdeScheme scheme = new ExplicitEuler(sde);
			ISdeScheme scheme1 = new KP11_1_3(sde);
			ISdeScheme scheme2 = new O1_5expl(sde);
			ISdeScheme exScheme = new Extrapolation(scheme);
			ISdeScheme pc = new PredictorCorrector(scheme, scheme1);
			double t = 0;
			double t1 = 0;
			double t2 = 0;
			double te = 0;
			double tpc = 0;
			double x0 = 0.5;
			double x = x0;
			double x1 = x0;
			double x2 = x0;
			double xe = x0;
			double xpc = x0;
			double[] Z = new double[2];
			double[] Ze = new double[2];
			double W = 0;
			Console.WriteLine("{0} {1} {2} {3}", t, x, x1, x2);
			while (t < T)
			{
				Ze[0] = NormalGenerator.Value;
				Ze[1] = NormalGenerator.Value;
				Z[0] = Math.Sqrt(0.5) * (Ze[0] + Ze[1]);
				Z[1] = NormalGenerator.Value;
				W += Math.Sqrt(dt) * Z[0];
				scheme.Step(ref t, ref x, dt, Z);
				scheme1.Step(ref t1, ref x1, dt, Z);
				scheme2.Step(ref t2, ref x2, dt, Z);
				exScheme.Step(ref te, ref xe, dt, Ze);
				pc.Step(ref tpc, ref xpc, dt, Z);
				Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}",
						t, x, x1, x2, xe, W, sde.GetAnalytic(t, x0, W), xpc);
			}
		}
	}
}
