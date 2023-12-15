namespace GameTheoryLibrary;

public class Matrix
{
    public Shape Shape { get; set; }
    public double[,] Data { get; private set; }

    public Matrix(double[,] data)
    {
        Data = data;
        Shape = new Shape(data.GetLength(0), data.GetLength(1));
    }
    public Matrix(Shape shape)
    {
        Data = new double[shape.Rows, shape.Columns];
        Shape = shape;
    }
    public double this[int row, int col]
    {
        get { return Data[row, col]; }
        set { Data[row, col] = value; }
    }

    public void Transpose()
    {
        double[,] newData = new double[Shape.Columns, Shape.Rows];
        for (int i = 0; i < Shape.Rows; i++)
        {
            for (int j = 0; j < Shape.Columns; j++)
            {
                newData[j, i] = Data[i, j];
            }
        }
        Data = newData;
        Shape = new Shape(Shape.Columns, Shape.Rows);
    }

    public Matrix Transposed()
    {
        double[,] newData = new double[Shape.Columns, Shape.Rows];
        for (int i = 0; i < Shape.Rows; i++)
        {
            for (int j = 0; j < Shape.Columns; j++)
            {
                newData[j, i] = Data[i, j];
            }
        }
        return newData;
    }

    public void Print()
    {
        for (int i = 0; i < Shape.Rows; i++)
        {
            for (int j = 0; j < Shape.Columns; j++)
            {
                Console.Write($"{Data[i, j]}  ");
            }
            Console.WriteLine();
        }
    }

    public static implicit operator Matrix(double[,] data)
    {
        return new(data);
    }

    // Scalar multiplication operator
    public static Matrix operator *(Matrix matrix, double scalar)
    {
        Matrix result = new Matrix(matrix.Shape);
        for (int i = 0; i < matrix.Shape.Rows; i++)
        {
            for (int j = 0; j < matrix.Shape.Columns; j++)
            {
                result[i, j] = matrix[i, j] * scalar;
            }
        }
        return result;
    }

    public static Matrix operator-(Matrix matrix)
    {
        return matrix * -1;
    }
}
