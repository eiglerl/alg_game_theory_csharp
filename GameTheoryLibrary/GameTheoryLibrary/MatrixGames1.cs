using System.ComponentModel.Design;
using System.Data;
using System.Runtime.InteropServices;

namespace GameTheoryLibrary;

public static partial class MatrixGameEvaluator
{
    //public static Matrix CalculateBestResponse(Matrix utilityMatrix, Matrix strat)
    //{

    //}
    public static ColumnStrategy GetBestResponse(Matrix utilityMatrix, RowStrategy opponent)
    {
        var actionValues = utilityMatrix.Transposed().Multiply(opponent);
        int maxIndex = 0;
        for (int i = 0; i < actionValues.Shape.Rows; i++)
        {
            if (actionValues[i, 0] > actionValues[maxIndex, 0])
                maxIndex = i;
        }
        var pureStrat = ColumnStrategy.CreatePureStrategy(utilityMatrix.Shape.Columns, maxIndex);
        return pureStrat;
    }

    public static RowStrategy GetBestResponse(Matrix utilityMatrix, ColumnStrategy opponent)
    {
        var actionValues = opponent.Multiply(utilityMatrix.Transposed());
        int maxIndex = 0;
        for (int i = 0; i < actionValues.Shape.Columns; i++)
        {
            if (actionValues[0, i] > actionValues[0, maxIndex])
                maxIndex = i;
        }
        var pureStrat = RowStrategy.CreatePureStrategy(utilityMatrix.Shape.Rows, maxIndex);
        return pureStrat;
    }

    // General matrix games
    public static (double, double) EvaluateStrategies(Matrix utility1, Matrix utility2, RowStrategy row, ColumnStrategy column)
    {
        var probalityTable = row.Multiply(column);
        double rowValue = utility1.ElementWiseMultiply(probalityTable).Sum();
        double colValue = utility2.ElementWiseMultiply(probalityTable).Sum();
        return (rowValue, colValue);
    } 

    // Zero-sum games
    public static (double, double) EvaluateStrategies(Matrix utility1, RowStrategy row, ColumnStrategy column)
    {
        return EvaluateStrategies(utility1, -utility1, row, column);
    }

    public static List<int> FindDominatedRows(Matrix matrix)
    {
        List<int> dominatedActions = [];
        for (int i = 0; i < matrix.Shape.Rows; i++)
        {
            for (int j = 0; j < matrix.Shape.Rows; j++)
            {
                if (IsRowDominated(matrix, i, j))
                    dominatedActions.Add(i);
            }
        }
        return dominatedActions;
    }

    public static List<int> FindDominatedColumns(Matrix matrix)
    {
        List<int> dominatedActions = [];
        for (int i = 0; i < matrix.Shape.Columns; i++)
        {
            for (int j = 0; j < matrix.Shape.Columns; j++)
            {
                if (IsColumnDominated(matrix, i, j))
                    dominatedActions.Add(i);
            }
        }
        return dominatedActions;
    }

    /// <summary>
    /// Checks if row r1 is dominated by r2.
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="r1"></param>
    /// <param name="r2"></param>
    /// <returns></returns>
    public static bool IsRowDominated(Matrix matrix, int r1, int r2)
    {
        for (int k = 0; k < matrix.Shape.Columns; k++)
        {
            if (matrix[r1, k] >= matrix[r2, k])
                return false;
        }
        return true;
    }
    /// <summary>
    /// Checks if column c1 is dominated by c2.
    /// </summary>
    /// <param name="matrix"></param>
    /// <param name="c1"></param>
    /// <param name="c2"></param>
    /// <returns></returns>
    public static bool IsColumnDominated(Matrix matrix, int c1, int c2)
    {
        for (int k = 0; k < matrix.Shape.Rows; k++)
        {
            if (matrix[k, c1] >= matrix[k, c2])
                return false;
        }
        return true;
    }

    //public static Matrix RemoveDominatedStrategy(Matrix matrix)
    //{
    //    List<int> dominatedRows;
    //    List<int> dominatedColumns;
    //    Matrix newMatrix = matrix.Data;
    //    do
    //    {
    //        dominatedRows = FindDominatedRows(newMatrix);
    //        dominatedColumns = FindDominatedColumns(newMatrix);

            

    //    } while (dominatedRows.Count > 0 || dominatedColumns.Count > 0);

    //}
}
