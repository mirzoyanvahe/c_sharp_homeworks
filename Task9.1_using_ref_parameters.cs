using System;

class QuadraticEquationSolver
{
	public static void SolveQuadraticEquationWithRef(double a, double b, double c, ref double x1, ref double x2)
	{
		double discriminant = b * b - 4 * a * c;

		if (discriminant < 0)
		{
			// No real roots
			x1 = x2 = double.NaN;
		}
		else if (discriminant == 0)
		{
			// One real root
			x1 = x2 = -b / (2 * a);
		}
		else
		{
			// Two real roots
			x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
			x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
		}
	}

	static void Main()
	{
		double a = 1, b = -3, c = 2;
		double x1 = 0, x2 = 0;

		SolveQuadraticEquationWithRef(a, b, c, ref x1, ref x2);

		Console.WriteLine($"x1 = {x1}, x2 = {x2}");
	}
}
