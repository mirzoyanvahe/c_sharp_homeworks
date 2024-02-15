using System;

class ChessTour
{
    static int[,] gameBoard = new int[8, 8];
    static int[] moveRow = { 2, 1, -1, -2, -2, -1, 1, 2 };
    static int[] moveCol = { 1, 2, 2, 1, -1, -2, -2, -1 };

    static void Main()
    {
        InitializeGameBoard();
        gameBoard[0, 0] = 1; 
        TourKnight(0, 0, 2);

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    static void InitializeGameBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                gameBoard[i, j] = 0;
            }
        }
    }

    static void DisplayBoard()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write(gameBoard[i, j].ToString().PadLeft(3) + " ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }

    static int CountValidMoves(int row, int col)
    {
        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            int nextRow = row + moveRow[i];
            int nextCol = col + moveCol[i];

            if (IsValidPosition(nextRow, nextCol) && gameBoard[nextRow, nextCol] == 0)
            {
                count++;
            }
        }

        return count;
    }

    static bool IsValidPosition(int row, int col)
    {
        return row >= 0 && row < 8 && col >= 0 && col < 8;
    }

    static int CalculateMoveHeuristic(int row, int col)
    {
        int heuristic = 0;

        for (int i = 0; i < 8; i++)
        {
            int nextRow = row + moveRow[i];
            int nextCol = col + moveCol[i];

            if (IsValidPosition(nextRow, nextCol) && gameBoard[nextRow, nextCol] == 0)
            {
                heuristic++;
            }
        }

        return heuristic;
    }

    static bool TourKnight(int row, int col, int moveNumber)
    {
        if (moveNumber == 65)  
        {
            DisplayBoard();
            return true;
        }

        int minMoveIndex = -1;
        int minHeuristic = int.MaxValue;

        for (int i = 0; i < 8; i++)
        {
            int nextRow = row + moveRow[i];
            int nextCol = col + moveCol[i];

            if (IsValidPosition(nextRow, nextCol) && gameBoard[nextRow, nextCol] == 0)
            {
                int heuristic = CalculateMoveHeuristic(nextRow, nextCol);

                if (heuristic < minHeuristic)
                {
                    minHeuristic = heuristic;
                    minMoveIndex = i;
                }
            }
        }

        if (minMoveIndex != -1)
        {
            int nextRow = row + moveRow[minMoveIndex];
            int nextCol = col + moveCol[minMoveIndex];

            gameBoard[nextRow, nextCol] = moveNumber;
            DisplayBoard(); 
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            if (TourKnight(nextRow, nextCol, moveNumber + 1))
                return true;
            else
                gameBoard[nextRow, nextCol] = 0; 
        }

        return false;
    }
}
