using GameTheoryLibrary;
using Xunit.Abstractions;
using Xunit;

namespace GameTheoryTests;


public class Week1
{
    [Fact]
    public void EvaluateRow()
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

        //row_value = week1.evaluate(matrix = matrix, row_strategy = row_strategy, column_strategy = column_strategy)
        //assert row_value == pytest.approx(0.08)

        (double rowVal, double _) = MatrixGameEvaluator.EvaluateStrategies(utilityMatrix, row, col);
        Assert.Equal(0.08, rowVal, precision: 8);
    }

    [Fact]
    public void RowValueVersusBestResponse()
    {
        Matrix utilityMatrix = new double[,]
        {
            { 0, 1, -1 },
            { -1, 0, 1 },
            { 1, -1, 0 }
        };

        RowStrategy row = new double[] { 0.1, 0.2, 0.7 };
        ColumnStrategy brToRow = MatrixGameEvaluator.GetBestResponse(-utilityMatrix, row);

        //br_value_row = week1.best_response_value_row(matrix = matrix, row_strategy = row_strategy)
        //assert br_value_row == pytest.approx(-0.6)

        (double rowVal, double _) = MatrixGameEvaluator.EvaluateStrategies(utilityMatrix, row, brToRow);
        Assert.Equal(-0.6, rowVal, precision: 8);
    }

    [Fact]
    public void ColumnValueVersusBestResponse()
    {
        Matrix utilityMatrix = new double[,]
        {
            { 0, 1, -1 },
            { -1, 0, 1 },
            { 1, -1, 0 }
        };

        ColumnStrategy col = new double[] { 0.3, 0.2, 0.5 };
        RowStrategy brToCol = MatrixGameEvaluator.GetBestResponse(utilityMatrix, col);

        //br_value_column = week1.best_response_value_column(matrix = matrix, column_strategy = column_strategy)
        //assert br_value_column == pytest.approx(-0.2)

        (double rowVal, double colVal) = MatrixGameEvaluator.EvaluateStrategies(utilityMatrix, brToCol, col);
        Assert.Equal(-0.2, colVal, precision: 8);
    }

    [Fact]
    public void BestResponseInRPS()
    {
        //matrix = np.array([[0, 1, -1], [-1, 0, 1], [1, -1, 0]])
        //row_strat = np.array([[0.1, 0.2, 0.7]])
        //br = week1.best_response_to_row_player_in_zerosum(matrix, row_strat = row_strat)
        //assert np.array_equal(br, np.array([[1, 0, 0]]).T)

        Matrix utility = new double[,]
        {
            { 0, -1, 1 },
            { 1, 0, -1 },
            { -1, 1, 0 }
        };
        // RPS
        RowStrategy row = new double[] { 0.1, 0.2, 0.7 };
        var br = MatrixGameEvaluator.GetBestResponse(-utility, row);

        // BR is only playing R
        Assert.Equal(new double[,] { { 1, 0, 0 } }, br.Data);
    }

    [Fact]
    public void PureRowStrategyCreation()
    {
        RowStrategy row = RowStrategy.CreatePureStrategy(3, 0);

        Assert.Equal(new double[,] { { 1 }, { 0 }, { 0 } }, row.Data);
    }
}