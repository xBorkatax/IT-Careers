class Program
{
    static int count = 0;

    public static void PutQueen(int row, int[,] chessboard)
    {
        if (row >= 8)
        {
            
            PrintChessboard(chessboard);
            count++;
            return;
        }
        else
        {
            for (int column = 0; column < 8; column++)
            {
                if (CanPlace(chessboard, row, column))
                {
                    MarkPosition(chessboard, row, column);
                    PutQueen(row + 1, chessboard);
                    UnmarkPosition(chessboard, row, column);
                }
            }
        }
    }

    public static bool CanPlace(int[,] chessboard, int row, int column)
    {
        return chessboard[row, column] == 0;
    }

    public static void MarkPosition(int[,] chessboard, int row, int column)
    {
        for (int i = 0; i < chessboard.GetLength(0); i++)
        {
            chessboard[i, column] = chessboard[i, column] + 1;
        }

        for (int i = 0; i < chessboard.GetLength(0); i++)
        {
            chessboard[row, i] = chessboard[row, i] + 1;
        }

        for (int i = row, j = column; i < chessboard.GetLength(0) && j >= 0; i++, j--)
        {
            chessboard[i, j] = chessboard[i, j] + 1;
        }


        for (int i = row, j = column; i >= 0 && j < chessboard.GetLength(0); i--, j++)
        {
            chessboard[i, j] = chessboard[i, j] + 1;
        }

        for (int i = row, j = column; i >= 0 && j >= 0; i--, j--)
        {
            chessboard[i, j] = chessboard[i, j] + 1;
        }

        for (int i = row, j = column; i < chessboard.GetLength(0) && j < chessboard.GetLength(0); i++, j++)
        {
            chessboard[i, j] = chessboard[i, j] + 1;
        }

        chessboard[row, column] = -1;
    }

    public static void UnmarkPosition(int[,] chessboard, int row, int column)
    {
        for (int i = 0; i < chessboard.GetLength(0); i++)
        {
            chessboard[i, column] = chessboard[i, column] - 1;
        }

        for (int i = 0; i < chessboard.GetLength(0); i++)
        {
            chessboard[row, i] = chessboard[row, i] - 1;
        }

        for (int i = row, j = column; i < chessboard.GetLength(0) && j >= 0; i++, j--)
        {
            chessboard[i, j] = chessboard[i, j] - 1;
        }

        for (int i = row, j = column; i >= 0 && j < chessboard.GetLength(0); i--, j++)
        {
            chessboard[i, j] = chessboard[i, j] - 1;
        }

        for (int i = row, j = column; i >= 0 && j >= 0; i--, j--)
        {
            chessboard[i, j] = chessboard[i, j] - 1;
        }

        for (int i = row, j = column; i < chessboard.GetLength(0) && j < chessboard.GetLength(0); i++, j++)
        {
            chessboard[i, j] = chessboard[i, j] - 1;
        }

        chessboard[row, column] = 0;
    }

    public static void PrintChessboard(int[,] chessboard)
    {
        for (int row = 0; row < chessboard.GetLength(0); row++)
        {
            for (int column = 0; column < chessboard.GetLength(1); column++)
            {
                if (chessboard[row, column] == 0)
                {
                    Console.Write("-");
                }

                if (chessboard[row, column] > 0)
                {
                    Console.Write("*");
                }

                if (chessboard[row, column] < 0)
                {
                    Console.Write("Q");
                }

                if (column < chessboard.GetLength(1))
                {
                    Console.Write(" ");
                }
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    public static void Main(string[] args)
    {
        int[,] chessboard =
            {
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0}
            };

        PutQueen(0, chessboard);

        Console.WriteLine(count);
    }
}