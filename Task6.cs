using System;

class Program
{
    static void Main()
    {
        // Ask the user to enter the dimensions of the matrix
        Console.Write("Enter the number of rows: ");
        int rows = int.Parse(Console.ReadLine());

        Console.Write("Enter the number of columns: ");
        int columns = int.Parse(Console.ReadLine());

        // Check if the matrix size is valid
        if (rows <= 0 || columns <= 0)
        {
            Console.WriteLine("Invalid matrix size.");
            return;
        }

        // Create the matrix
        int[,] matrix = new int[rows, columns];

        // Fill the matrix with non-repeating random numbers
        FillMatrixWithRandomNumbers(matrix);

        // Display the matrix
        DisplayMatrix(matrix);

        Console.ReadLine(); // Keep the console window open
    }

    static void FillMatrixWithRandomNumbers(int[,] matrix)
    {
        int totalElements = matrix.GetLength(0) * matrix.GetLength(1);
        int[] allNumbers = new int[totalElements];

        // Fill the array with all possible numbers
        for (int i = 0; i < totalElements; i++)
        {
            allNumbers[i] = i + 1;
        }

        Random random = new Random();

        // Shuffle the array
        for (int i = totalElements - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            int temp = allNumbers[i];
            allNumbers[i] = allNumbers[j];
            allNumbers[j] = temp;
        }

        // Fill the matrix with shuffled numbers
        int index = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = allNumbers[index++];
            }
        }
    }

    static void DisplayMatrix(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col] + "\t");
            }
            Console.WriteLine();
        }
    }
}
