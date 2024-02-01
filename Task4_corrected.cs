using System;

class Program
{
    static void Main(string[] args)
    {
        Random rand = new Random();
        int[,] board = new int[8, 8];
        Console.Write("Enter the row (0-7) of the knight: ");
        int knightRow = int.Parse(Console.ReadLine());
        Console.Write("Enter the column (0-7) of the knight: ");
        int knightColumn = int.Parse(Console.ReadLine());
        board[knightRow, knightColumn] = 5;
        bool st;
        do
        {
            st = false;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == 5)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(board[i, j] + " ");
                        board[i, j] = 3;
                    }
                    else if (board[i, j] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(board[i, j] + " ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.Write(board[i, j] + " ");
                    }
                }
                Console.WriteLine();
                Console.ResetColor();
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (((knightRow - i == 2 || i - knightRow == 2) && (knightColumn - j == 1 || j - knightColumn == 1) || (knightRow - i == 1 || i - knightRow == 1) && (knightColumn - j == 2 || j - knightColumn == 2)) && board[i, j] != 3)
                    {
                        st = true;
                        board[i, j] = 5;
                        knightRow = i; knightColumn = j;
                        break;
                    }
                }
                if (st == true) break;
            }
            Console.WriteLine("================");
        } while (st);

    }
}