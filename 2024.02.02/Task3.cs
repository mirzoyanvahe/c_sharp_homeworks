using System;

class Program
{
    static void Main()
    {
        RandomlyPlaceQueens();
    }

    static void RandomlyPlaceQueens()
    {
        int boardSize = 8;
        int[] queens = new int[boardSize];

        Random random = new Random();

        // Initialize the queens array with random column positions
        for (int i = 0; i < boardSize; i++)
        {
            queens[i] = random.Next(boardSize);
        }

        Console.WriteLine("Randomly Placed Queens:");

        // Print the chessboard with queens
        PrintChessboard(queens);

        // Check if queens are attacking each other
        while (!QueensAreSafe(queens))
        {
            // If queens are attacking, reposition them randomly
            for (int i = 0; i < boardSize; i++)
            {
                queens[i] = random.Next(boardSize);
            }
        }

        Console.WriteLine("\nQueens are placed safely now:");

        // Print the chessboard with safely placed queens
        PrintChessboard(queens);
    }

    static void PrintChessboard(int[] queens)
    {
        int boardSize = queens.Length;

        for (int row = 0; row < boardSize; row++)
        {
            for (int col = 0; col < boardSize; col++)
            {
                if (queens[row] == col)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("* ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("0 ");
                }
            }
            Console.WriteLine();
        }

        Console.ResetColor();
        Console.WriteLine();
    }

    static bool QueensAreSafe(int[] queens)
    {
        int boardSize = queens.Length;

        for (int i = 0; i < boardSize; i++)
        {
            for (int j = i + 1; j < boardSize; j++)
            {
                if (queens[i] == queens[j] || Math.Abs(queens[i] - queens[j]) == Math.Abs(i - j))
                {
                    // Queens are in the same column or on the same diagonal
                    return false;
                }
            }
        }

        // Queens are placed safely
        return true;
    }
}
