using System;

class ChessQueenMoves
{
    static void Main()
    {
        int[,] chessboard = new int[8, 8];
        Console.Write("Enter the row (0-7) of the queen: ");
        int queenRow = int.Parse(Console.ReadLine());
        Console.Write("Enter the column (0-7) of the queen: ");
        int queenColumn = int.Parse(Console.ReadLine());
        MarkValidMoves(chessboard, queenRow, queenColumn);
        DisplayChessboard(chessboard);
    }

    static void MarkValidMoves(int[,] chessboard, int queenRow, int queenColumn)
    {
        int[] dx = { 1, 1, 0, -1, -1, -1, 0, 1 };
        int[] dy = { 0, 1, 1, 1, 0, -1, -1, -1 };

        chessboard[queenRow, queenColumn] = 2;

        for (int i = 0; i < 8; i++)
        {
            MarkMovesInDirection(chessboard, queenRow, queenColumn, dx[i], dy[i]);
        }
    }

    static void MarkMovesInDirection(int[,] chessboard, int row, int col, int dx, int dy)
    {
        int newRow = row + dx;
        int newCol = col + dy;

        while (IsValidPosition(newRow, newCol))
        {
            chessboard[newRow, newCol] = 1;
            newRow += dx;
            newCol += dy;
        }
    }

    static bool IsValidPosition(int row, int col)
    {
        return row >= 0 && row < 8 && col >= 0 && col < 8;
    }

    static void DisplayChessboard(int[,] chessboard)
    {
        Console.WriteLine("Chessboard with Queen's Position (*) and Possible Moves (1):");
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