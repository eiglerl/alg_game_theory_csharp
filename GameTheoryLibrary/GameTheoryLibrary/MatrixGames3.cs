namespace GameTheoryLibrary;

public static partial class MatrixGameEvaluator
{
    public static (double, double) CalculateDelta(Matrix utility1, RowStrategy row, ColumnStrategy col)
        => CalculateDelta(utility1, -utility1, row, col);

    public static (double, double) CalculateDelta(Matrix utility1, Matrix utility2, RowStrategy row, ColumnStrategy col)
    {
        var brToRow = GetBestResponse(utility2, row);
        var brToCol = GetBestResponse(utility1, col);

        (double rowValue, double colValue) = EvaluateStrategies(utility1, utility2, row, col);

        (double _, double bestResponseToRowValue) = EvaluateStrategies(utility1, utility2, row, brToRow);
        (double bestResponseToColValue, double _) = EvaluateStrategies(utility1, utility2, brToCol, col);

        double deltaRow = bestResponseToColValue - rowValue;
        double deltaCol = bestResponseToRowValue - colValue;

        return (deltaRow, deltaCol);
    }

    public static double CalculateNashConv(Matrix utility1, Matrix utility2, RowStrategy row, ColumnStrategy col)
    {
        (double deltaRow, double deltaCol) = CalculateDelta(utility1, utility2, row, col);
        return deltaRow + deltaCol;
    }

    public static double CalculateNashConv(Matrix utility, RowStrategy row, ColumnStrategy col)
        => CalculateNashConv(utility, -utility, row, col);

    public static double CalculateExploitability(Matrix utility1, Matrix utility2, RowStrategy row, ColumnStrategy col)
        => CalculateNashConv(utility1, utility2, row, col) / 2;

    public static double CalculateExploitability(Matrix utility, RowStrategy row, ColumnStrategy col)
        => CalculateExploitability(utility, -utility, row, col);

    
}
