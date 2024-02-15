using System;

class Queens
{
    private int[,] ChessBoard;
    private int[,] BG;

    public Queens()
    {
        InitializeBoards();
        PlaceQueens();
    }

    private void InitializeBoards()
    {
        ChessBoard = new int[8, 8];
        BG = new int[,]
        {
            { 22, 22, 22, 22, 22, 22, 22, 22 },
            { 22, 24, 24, 24, 24, 24, 24, 22 },
            { 22, 24, 26, 26, 26, 26, 24, 22 },
            { 22, 24, 26, 28, 28, 26, 24, 22 },
            { 22, 24, 26, 28, 28, 26, 24, 22 },
            { 22, 24, 26, 26, 26, 26, 24, 22 },
            { 22, 24, 24, 24, 24, 24, 24, 22 },
            { 22, 22, 22, 22, 22, 22, 22, 22 }
        };
    }

    private void PrintBoard(int[,] board)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write($"{board[i, j]} ");
            }
            Console.WriteLine();
        }
    }

    private int[,] ResizeArray(int[,] oldArray, int size)
    {
        int[,] newArray = new int[size, 2];
        Array.Copy(oldArray, newArray, oldArray.Length);
        return newArray;
    }

    private int[,] AppendCoordinate(int[,] array, int i, int j)
    {
        int[,] newArray = ResizeArray(array, array.GetLength(0) + 1);
        newArray[newArray.GetLength(0) - 1, 0] = i;
        newArray[newArray.GetLength(0) - 1, 1] = j;
        return newArray;
    }

    private int[,] GetCoordinates(int value)
    {
        int[,] coordinates = new int[0, 2];

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (BG[i, j] == value)
                {
                    coordinates = AppendCoordinate(coordinates, i, j);
                }
            }
        }

        return coordinates;
    }

    private int[] GetRandomHeuristic()
    {
        Random rnd = new Random();

        int[,] coordinates = GetCoordinates(22);

        if (coordinates.GetLength(0) == 0)
        {
            coordinates = GetCoordinates(24);

            if (coordinates.GetLength(0) == 0)
            {
                coordinates = GetCoordinates(26);

                if (coordinates.GetLength(0) == 0)
                {
                    coordinates = GetCoordinates(28);
                }
            }
        }

        if (coordinates.GetLength(0) == 0)
        {
            return new int[] { -1, -1 };
        }

        int index = rnd.Next(0, coordinates.GetLength(0));
        return new int[] { coordinates[index, 0], coordinates[index, 1] };
    }

    private void DrawPossibleMoves(int[] coordinate)
    {
        int y = coordinate[0];
        int x = coordinate[1];
        ChessBoard[y, x] = 8;
        BG[y, x] = -1;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (ChessBoard[i, j] == 0)
                {
                    if (i == y || j == x || (x - j) == (y - i) || (i + j) == (x + y))
                    {
                        ChessBoard[i, j] = 1;
                        BG[i, j] = -1;
                    }
                }
            }
        }

        PrintBoard(ChessBoard);
        Console.WriteLine();
        PrintBoard(BG);
        Console.WriteLine();
    }

    private void PlaceQueens()
    {
        int[] queen = GetRandomHeuristic();

        while (queen[0] != -1)
        {
            DrawPossibleMoves(queen);
            queen = GetRandomHeuristic();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Queens ob = new Queens();
    }
}
