using System;

class QuadraticEquationSolver
{
	public class QuadraticResult
	{
		public double X1 { get; }
		public double X2 { get; }

		public QuadraticResult(double x1, double x2)
		{
			X1 = x1;
			X2 = x2;
		}

		public void Deconstruct(out double x1, out double x2)
		{
			x1 = X1;
			x2 = X2;
		}
	}

	public static QuadraticResult SolveQuadraticEquationWithDeconstruct(double a, double b, double c)
	{
		double discriminant = b * b - 4 * a * c;

		if (discriminant < 0)
		{
			// No real roots
			return new QuadraticResult(double.NaN, double.NaN);
		}
		else if (discriminant == 0)
		{
			// One real root
			double x = -b / (2 * a);
			return new QuadraticResult(x, x);
		}
		else
		{
			// Two real roots
			double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
			double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
			return new QuadraticResult(x1, x2);
		}
	}

	static void Main()
	{
		double a = 1, b = -3, c = 2;

		var result = SolveQuadraticEquationWithDeconstruct(a, b, c);

		Console.WriteLine($"x1 = {result.X1}, x2 = {result.X2}");
	}
}
