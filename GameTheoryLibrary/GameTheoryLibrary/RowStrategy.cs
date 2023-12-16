namespace GameTheoryLibrary;

public class RowStrategy : Matrix, IPlayerStrat
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

    public static RowStrategy CreateUniformStrategy(int len)
    {
        var strat = new double[len];

        for (int i = 0; i < len; i++)
            strat[i] = (double)1 / len;
        return strat;
    }

    public double this[int row]
    {
        get { return Data[row, 0]; }
        set { Data[row, 0] = value; }
    }

    public override string ToString()
    {
        string text = "[";
        for (int i = 0; i < Data.GetLength(0); i++)
        {
            text += this[i].ToString() + " ";
        }
        return text.Substring(0, text.Length - 1) + "]";
    }
}
