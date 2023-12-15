namespace GameTheoryLibrary;

public class RowStrategy : Matrix
{
    public RowStrategy(double[,] data) : base(data)
    {
        if (data.GetLength(1) != 1)
            throw new ArgumentException("Row strategy must have only 1 row.");
    }

    public static implicit operator RowStrategy(double[] data)
    {
        double[,] strat = new double[data.Length, 1];
        for (int i = 0; i < data.Length; i++)
            strat[i, 0] = data[i];
        
        return new(strat);
    }

    public static RowStrategy CreatePureStrategy(int len, int index)
    {
        double[] strat = new double[len];
        strat[index] = 1;
        return strat;
    }

}
