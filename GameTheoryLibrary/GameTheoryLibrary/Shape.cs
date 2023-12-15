namespace GameTheoryLibrary;

public struct Shape(int rows, int columns)
{
    public int Rows { get; set; } = rows;
    public int Columns { get; set; } = columns;

    public override string ToString()
    {
        return $"({Rows},{Columns})";
    }
}
