namespace GameTheoryLibrary;

public partial class SelfPlayAgent
{
    private Matrix utilityMatrix;
    private List<RowStrategy> rowStrategies;
    private List<ColumnStrategy> columnStrategies;

    public SelfPlayAgent(Matrix matrix)
    {
        utilityMatrix = matrix;
    }


    // Maybe generics? Couldnt figure out how.
    public static RowStrategy AverageRowStrategy(List<RowStrategy> rowStrategies, int numberOfActions)
    {
        // No strategies to go of
        if (rowStrategies.Count == 0)
        {
            var strat = new double[numberOfActions];

            for (int i = 0; i < numberOfActions; i++)
                strat[i] = (double)1 / numberOfActions;
            return strat;
        }

        double[] counts = new double[numberOfActions];

        foreach (var strat in rowStrategies)
        {
            for (int i = 0; i < numberOfActions; i++)
                counts[i] += strat[i];
        }

        double[] avgStrat = counts.Select(x => x / rowStrategies.Count).ToArray();
        return avgStrat;
    }

    public static ColumnStrategy AverageColumnStrategy(List<ColumnStrategy> rowStrategies, int numberOfActions)
    {
        // No strategies to go of
        if (rowStrategies.Count == 0)
        {
            var strat = new double[numberOfActions];

            for (int i = 0; i < numberOfActions; i++)
                strat[i] = (double)1 / numberOfActions;
            return strat;
        }

        double[] counts = new double[rowStrategies.Count];

        foreach (var strat in rowStrategies)
        {
            for (int i = 0; i < numberOfActions; i++)
                counts[i] += strat[i];
        }

        double[] avgStrat = counts.Select(x => x / rowStrategies.Count).ToArray();
        return avgStrat;
    }



}