namespace GameTheoryTests;
using GameTheoryLibrary;
using Xunit;

public class Week3
{
    [Fact]
    public void ComputeDeltaTest()
    {
        //matrix = np.array([[0, 1, -1], [-1, 0, 1], [1, -1, 0]])
        //row_strategy = np.array([[0.1, 0.2, 0.7]])
        //column_strategy = np.array([[0.3, 0.2, 0.5]]).transpose()

        Matrix utilityMatrix = new double[,]
        {
            { 0, 1, -1 },
            { -1, 0, 1 },
            { 1, -1, 0 }
        };

        RowStrategy row = new double[] { 0.1, 0.2, 0.7 };
        ColumnStrategy col = new double[] { 0.3, 0.2, 0.5 };

        //delta_row, delta_column = week3.compute_deltas(matrix = matrix, row_strategy = row_strategy,
        //                                           column_strategy = column_strategy)
        //assert delta_row == pytest.approx(0.12)
        //assert delta_column == pytest.approx(0.68)

        (double deltaRow, double deltaCol) = MatrixGameEvaluator.CalculateDelta(utilityMatrix, row, col);

        Assert.Equal(0.12, deltaRow, precision: 8);
        Assert.Equal(0.68, deltaCol, precision: 8);
    }

    [Fact]
    public void NashConvTest()
    {
        Matrix utilityMatrix = new double[,]
{
            { 0, 1, -1 },
            { -1, 0, 1 },
            { 1, -1, 0 }
};

        RowStrategy row = new double[] { 0.1, 0.2, 0.7 };
        ColumnStrategy col = new double[] { 0.3, 0.2, 0.5 };

        (double deltaRow, double deltaCol) = MatrixGameEvaluator.CalculateDelta(utilityMatrix, row, col);

        Assert.Equal(0.12 + 0.68, deltaRow + deltaCol, precision: 8);
    }
}
