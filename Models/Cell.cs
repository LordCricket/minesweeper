public class Cell
{
    public bool IsFlagged {get; set;}
    public bool IsMine {get; set;}
    public bool IsCleared {get; set;}

    public Cell(bool isFlagged, bool isMine, bool isCleared)
    {
        IsFlagged = isFlagged;
        IsMine = isMine;
        IsCleared = isCleared;
    }
}