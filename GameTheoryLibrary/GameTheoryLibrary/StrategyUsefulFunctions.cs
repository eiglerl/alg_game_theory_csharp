namespace GameTheoryLibrary;

public static class StrategyUsefulFunctions
{
    // Maybe generics? Couldnt figure out how.
    public static RowStrategy AverageRowStrategy(List<RowStrategy> rowStrategies, int numberOfActions)
    {
        List<double[]> strats = rowStrategies.Select(x => x.Data.Flatten()).ToList();
        return AverageStrat(strats, numberOfActions);
    }

    public static ColumnStrategy AverageColumnStrategy(List<ColumnStrategy> colStrategies, int numberOfActions)
    {
        List<double[]> strats = colStrategies.Select(x => x.Data.Flatten()).ToList();
        return AverageStrat(strats, numberOfActions);
    }

    public static double[] AverageStrat(List<double[]> strategies, int numberOfActions)
    {
        // No strategies to go off of
        if (strategies.Count == 0)
            return CreateUniformStrat(numberOfActions);
        

        double[] counts = new double[numberOfActions];

        foreach (var strat in strategies)
        {
            for (int i = 0; i < numberOfActions; i++)
                counts[i] += strat[i];
        }

        double[] avgStrat = counts.Select(x => x / strategies.Count).ToArray();
        return avgStrat;
    }

    public static double[] CreateUniformStrat(int len)
    {
        var strat = new double[len];

        for (int i = 0; i < len; i++)
            strat[i] = (double)1 / len;
        return strat;
    }

}
