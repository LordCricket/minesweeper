using System;

public static class Renderer
{
    public static void DrawBoard(Cursor cursor, Board board)
    {   
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (cursor.Row == i && cursor.Col == j)
                {
                    Console.Write("\U0001F7E8");
                }
                else if (board.cells[i,j].IsFlagged)
                {
                    Console.Write("\U0001F6A9");
                }
                else if (board.cells[i,j].IsCleared)
                {
                    int adjacentMines = board.CountAdjacentMines(i,j);

                    if (adjacentMines > 0)
                    {
                        Console.ResetColor();
                        switch (adjacentMines)
                        {
                           case 1:
                           Console.ForegroundColor = ConsoleColor.Blue; 
                           Console.Write($"{adjacentMines} ");
                           break;

                           case 2:
                           Console.ForegroundColor = ConsoleColor.Green;
                           Console.Write($"{adjacentMines} ");
                           break;

                           case 3:
                           Console.ForegroundColor = ConsoleColor.Red;
                           Console.Write($"{adjacentMines} ");
                           break;

                           case 4:
                           Console.ForegroundColor = ConsoleColor.Magenta;
                           Console.Write($"{adjacentMines} ");
                           break;

                           case 5:
                           Console.ForegroundColor = ConsoleColor.Yellow;
                           Console.Write($"{adjacentMines} ");
                           break;

                           case 6:
                           Console.ForegroundColor = ConsoleColor.Cyan;
                           Console.Write($"{adjacentMines} ");
                           break;

                           case 7:
                           Console.ForegroundColor = ConsoleColor.White;
                           Console.Write($"{adjacentMines} ");
                           break;

                           case 8:
                           Console.ForegroundColor = ConsoleColor.DarkYellow;
                           Console.Write($"{adjacentMines} ");
                           break;
                        }
                        
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
                else
                {
                    Console.Write("\U0001F7E6");
                }
            }
            Console.WriteLine();
        }
    }

    public static void GameOver(Board board, Cursor cursor)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                switch (board.cells[i,j].IsFlagged, board.cells[i,j].IsMine, board.cells[i,j].IsCleared)
                {
                    case (true, true, _):
                    Console.Write("\U0001F6A9");
                    break;

                    case (true, false, _):
                    Console.Write("\U0000274C");
                    break;

                    case (false, true, _):
                    if (i == cursor.Row && j == cursor.Col)
                    {
                        Console.Write("\U0001F4A5");
                    }
                    else
                    {
                        Console.Write("\U0001F4A3");
                    }
                    break;

                    case (_, _, true):
                    Console.Write("  ");
                    break;

                    default:
                    Console.Write("\U0001F7E6");
                    break;
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("BOOOOOOOOOOOOOOOM YOU DIED");
    }

    public static void Victory(Board board)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                switch (board.cells[i,j].IsMine)
                {
                    case true:
                    Console.Write("\U00002705");
                    break;

                    case false:
                    Console.Write("  ");
                    break;
                }
            }
            Console.WriteLine();
        }
        Console.WriteLine("You survive (for now)");
    }
}