using System;
using System.Threading;

public class Game
{
    public void Run()
    {
        Cursor cursor = new Cursor(0,0);
        Board board = new Board();

        while (true)
        {
            Console.Clear();
            Renderer.DrawBoard(cursor, board);
            ConsoleKeyInfo key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                if (cursor.Row > 0)
                {
                    cursor.Row--;
                }
                break;

                case ConsoleKey.DownArrow:
                if (cursor.Row < 7)
                {
                    cursor.Row++;
                }
                break;

                case ConsoleKey.LeftArrow:
                if (cursor.Col > 0)
                {
                    cursor.Col--;
                }
                break;

                case ConsoleKey.RightArrow:
                if (cursor.Col < 7)
                {
                    cursor.Col++;
                }
                break;

                case ConsoleKey.Enter:
                if (!board.cells[cursor.Row,cursor.Col].IsFlagged && !board.cells[cursor.Row,cursor.Col].IsMine)
                {
                    board.cells[cursor.Row,cursor.Col].IsCleared = true;

                    if (board.CheckVictory())
                    {
                        Console.Clear();
                        Renderer.Victory(board);
                        return;
                    }
                }
                else if (!board.cells[cursor.Row,cursor.Col].IsFlagged && board.cells[cursor.Row,cursor.Col].IsMine)
                {
                    Console.Clear();
                    Renderer.GameOver(board, cursor);
                    return;
                }
                break;

                case ConsoleKey.F:
                if (!board.cells[cursor.Row,cursor.Col].IsCleared)
                {
                    board.cells[cursor.Row,cursor.Col].IsFlagged = !board.cells[cursor.Row,cursor.Col].IsFlagged;
                }
                break;
            }
        }
    }
}