using System;

public class Board
{
    public Cell[,] cells = new Cell[8,8];

    public Board()
    {
        Random rand = new Random();
        int mineCounter = 0;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                cells[i,j] = new Cell(false,false,false);
            }
        }

        while (mineCounter < 10)
        {
            int row = rand.Next(0,8);
            int col = rand.Next(0,8);

            if (!cells[row,col].IsMine)
            {
                cells[row,col].IsMine = true;
                mineCounter++;
            }
        }
    }

    public int CountAdjacentMines(int row, int col)
    {
        int count = 0;

        for (int i = row - 1; i <= row + 1; i++)
        {
            for (int j = col - 1; j <= col + 1; j++)
            {
                if (i >= 0 && i < 8 && j >= 0 && j < 8 && !(i == row && j == col) && cells[i,j].IsMine)
                {
                    count++;
                }
            }
        }

        return count;
    }

    public bool CheckVictory()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (!cells[i,j].IsCleared && !cells[i,j].IsMine)
                {
                    return false;
                }
            }
        }

        return true;
    }
}