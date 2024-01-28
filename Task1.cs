using System;

class ChessKnightMoves
{
    static void Main()
    {
        int[,] chessboard = new int[8, 8];
        Console.Write("Enter the row (0-7) of the knight: ");
        int knightRow = int.Parse(Console.ReadLine());
        Console.Write("Enter the column (0-7) of the knight: ");
        int knightColumn = int.Parse(Console.ReadLine());
        MarkValidMoves(chessboard, knightRow, knightColumn);
        DisplayChessboard(chessboard);
    }

    static void MarkValidMoves(int[,] chessboard, int knightRow, int knightColumn)
    {
        int[] dx = { 1, 2, 2, 1, -1, -2, -2, -1 };
        int[] dy = { 2, 1, -1, -2, -2, -1, 1, 2 };
        chessboard[knightRow, knightColumn] = 2;

        for (int i = 0; i < 8; i++)
        {
            int newRow = knightRow + dx[i];
            int newCol = knightColumn + dy[i];

            if (IsValidPosition(newRow, newCol))
            {
                chessboard[newRow, newCol] = 1;
            }
        }
    }

    static bool IsValidPosition(int row, int col)
    {
        return row >= 0 && row < 8 && col >= 0 && col < 8;
    }

    static void DisplayChessboard(int[,] chessboard)
    {
        Console.WriteLine("Chessboard with Knight's Position (*) and Possible Moves (1):");
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (chessboard[i, j] == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("0 ");
                }
                else if (chessboard[i, j] == 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("* ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write("1 ");
                }
            }
            Console.WriteLine();
        }
        Console.ResetColor();
    }
}