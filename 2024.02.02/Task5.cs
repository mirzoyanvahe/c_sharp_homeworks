using System;

class SaddlePointFinder
{
    static void Main()
    {
        Console.WriteLine("Enter the number of rows (M): ");
        int m = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the number of columns (N): ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[m, n];

        Console.WriteLine("Enter the matrix elements:");

        // Input matrix elements
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write($"Enter element at position ({i + 1},{j + 1}): ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        // Find and display saddle point
        int saddlePoint = FindSaddlePoint(matrix, m, n);

        if (saddlePoint != -1)
        {
            Console.WriteLine($"Saddle point found at position ({saddlePoint / n + 1},{saddlePoint % n + 1}) with value {matrix[saddlePoint / n, saddlePoint % n]}");
        }
        else
        {
            Console.WriteLine("No");
        }
    }

    static int FindSaddlePoint(int[,] matrix, int m, int n)
    {
        for (int i = 0; i < m; i++)
        {
            int maxInRow = int.MinValue;
            int colIndexOfMax = -1;

            // Find the maximum element in the current row
            for (int j = 0; j < n; j++)
            {
                if (matrix[i, j] > maxInRow)
                {
                    maxInRow = matrix[i, j];
                    colIndexOfMax = j;
                }
            }

            // Check if the maximum element in the row is also the minimum in its column
            bool isSaddlePoint = true;
            for (int k = 0; k < m; k++)
            {
                if (matrix[k, colIndexOfMax] < maxInRow)
                {
                    isSaddlePoint = false;
                    break;
                }
            }

            if (isSaddlePoint)
            {
                return i * n + colIndexOfMax;
            }
        }

        return -1; // No saddle point found
    }
}
