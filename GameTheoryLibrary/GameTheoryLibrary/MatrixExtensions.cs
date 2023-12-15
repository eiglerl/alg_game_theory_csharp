using System.Numerics;
using System.Runtime.CompilerServices;

namespace GameTheoryLibrary;

public static class MatrixExtensions
{
    // Matrix multiplication
    public static Matrix Multiply(this Matrix a, Matrix b)
    {
        if (a.Shape.Columns != b.Shape.Rows)
        {
            throw new ArgumentException($"Matrix multiplication wrong shapes: {a.Shape} x {b.Shape}");
        }

        double[,] result = new double[a.Shape.Rows, b.Shape.Columns];
        for (int i = 0; i < a.Shape.Rows; i++)
        {
            for (int j = 0; j < b.Shape.Columns; j++)
            {
                for (int k = 0; k < a.Shape.Columns; k++)
                {
                    result[i, j] += a[i, k] * b[k, j];
                }
            }
        }
        return result;
    }

    // Scalar multiplication
    public static Matrix MultiplyScalar(this Matrix matrix, double scalar)
    {
        double[,] result = new double[matrix.Shape.Rows, matrix.Shape.Columns];
        for (int i = 0; i < matrix.Shape.Rows; i++)
        {
            for (int j = 0; j < matrix.Shape.Columns; j++)
            {
                result[i, j] = matrix[i, j] * scalar;
            }
        }
        return result;
    }

    // Element-wise multiplication
    public static Matrix ElementWiseMultiply(this Matrix a, Matrix b)
    {
        if (a.Shape.Rows != b.Shape.Rows || a.Shape.Columns != b.Shape.Columns)
        {
            throw new ArgumentException("Matrices must have the same dimensions for element-wise multiplication.");
        }

        double[,] result = new double[a.Shape.Rows, a.Shape.Columns];
        for (int i = 0; i < a.Shape.Rows; i++)
        {
            for (int j = 0; j < a.Shape.Columns; j++)
            {
                result[i, j] = a[i, j] * b[i, j];
            }
        }
        return result;
    }

    // Sum up elements of the matrix
    public static double Sum(this Matrix a)
    {
        double result = 0;
        for (int i = 0; i < a.Shape.Rows; i++)
        {
            for (int j = 0; j < a.Shape.Columns; j++)
            {
                result += a[i, j];
            }
        }
        return result;
    }

}
