namespace GameTheoryLibrary;

public class ColumnStrategy : Matrix, IPlayerStrat
{
    public ColumnStrategy(double[,] data) : base(data)
    {
        if (data.GetLength(0) != 1)
            throw new ArgumentException("Column strategy must have only 1 row.");
    }

    public static implicit operator ColumnStrategy(double[] data)
    {
        double[,] strat = new double[1, data.Length];
        for (int i = 0; i < data.Length; i++)
            strat[0, i] = data[i];

        return new(strat);
    }

    public static ColumnStrategy CreatePureStrategy(int len, int index)
    {
        double[] strat = new double[len];
        strat[index] = 1;
        return strat;
    }

    public double this[int col]
    {
        get { return Data[0, col]; }
        set { Data[0, col] = value; }
    }


}
