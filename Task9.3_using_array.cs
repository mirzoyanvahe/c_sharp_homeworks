using System;

class QuadraticEquationSolver
{
    public static double[] SolveQuadraticEquationWithArray(double a, double b, double c)
    {
        double discriminant = b * b - 4 * a * c;

        if (discriminant < 0)
        {
            // No real roots
            return new double[] { double.NaN, double.NaN };
        }
        else if (discriminant == 0)
        {
            // One real root
            double x = -b / (2 * a);
            return new double[] { x, x };
        }
        else
        {
            // Two real roots
            double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            return new double[] { x1, x2 };
        }
    }

    static void Main()
    {
        double a = 1, b = -3, c = 2;

        var result = SolveQuadraticEquationWithArray(a, b, c);

        Console.WriteLine($"x1 = {result[0]}, x2 = {result[1]}");
    }
}
