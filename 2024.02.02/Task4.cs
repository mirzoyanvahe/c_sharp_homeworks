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
        DisplayOriginalChessboard(chessboard);

        int[,] modifiedChessboard = CopyChessboard(chessboard);
        RandomlyReplaceOne(modifiedChessboard);
        DisplayModifiedChessboard(modifiedChessboard);
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

    static int[,] CopyChessboard(int[,] chessboard)
    {
        int[,] copy = new int[8, 8];
        Array.Copy(chessboard, copy, chessboard.Length);
        return copy;
    }

    static void RandomlyReplaceOne(int[,] chessboard)
    {
        Random random = new Random();
        int row, col;

        do
        {
            row = random.Next(8);
            col = random.Next(8);
        } while (chessboard[row, col] != 1);

        chessboard[row, col] = 3;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (chessboard[i, j] == 1 && (i != row || j != col))
                {
                    chessboard[i, j] = 0;
                }
            }
        }
    }

    static bool IsValidPosition(int row, int col)
    {
        return row >= 0 && row < 8 && col >= 0 && col < 8;
    }

    static void DisplayOriginalChessboard(int[,] chessboard)
    {
        Console.WriteLine("Original Chessboard from Task1 with Knight's Position (*) and Possible Moves (1):");
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
    
    static void DisplayModifiedChessboard(int[,] chessboard)
    // Since we already have the possible fields for Knighte's next move from Task1,
    // we'll just replace one of the randomly selected
    // 1s from that problem with an blue asterisk (*), and just make the others 0.
    {
        Console.WriteLine("\nChessboard(solution for Task4) with randomly selected next step field:");
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (chessboard[i, j] == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("0 ");
                }
                else if (chessboard[i, j] == 3)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("* ");
                }
                else
                {
                    Console.Write("0 ");
                }
            }
            Console.WriteLine();
        }
        Console.ResetColor();
    }
}
