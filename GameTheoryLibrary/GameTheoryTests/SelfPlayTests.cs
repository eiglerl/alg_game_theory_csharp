namespace GameTheoryTests;
using GameTheoryLibrary;

public class SelfPlayTests
{
    public static IEnumerable<object[]> TestData()
    {
        // Uniform strat
        yield return new object[]
        {
            new List<double[]>{
                new double[] { 1, 0, 0 },
                new double[] { 0, 1, 0 },
                new double[] { 0, 0, 1 },
            },
            3,
            new double[] { 
                (double)1 / 3,
                (double)1 / 3,
                (double)1 / 3 
            }
        };

        // 
        yield return new object[]
        {
            new List<double[]>{
                new double[] { 1, 0, 0 },
                new double[] { 1, 0, 0 },
                new double[] { 1, 0, 0 },

                new double[] { 0, 1, 0 },
                new double[] { 0, 1, 0 },

                new double[] { 0, 0, 1 },
            },
            3,
            new double[] {
                (double)3 / 6,
                (double)2 / 6,
                (double)1 / 6
            }
        };

        yield return new object[]
        {
            new List<double[]>{
                new double[] { 0.6, 0.2, 0.2 },
                new double[] { 0.7, 0, 0.3 },
                new double[] { 0.1, 0.2, 0.7 },
            },
            3,
            new double[] {
                 (0.6+0.7+0.1) / 3,
                 (0.2+0.2) / 3,
                 (0.2+0.3+0.7) / 3 
            }
        };

    }

    [Theory]
    [MemberData(nameof(TestData))]
    public void AverageRowStrategyTest(List<double[]> strats, int numberOfActions, double[] result)
    {
        List<RowStrategy> rowStrategies = [];
        RowStrategy resRow = result;
        List<ColumnStrategy> colStrategies = [];
        ColumnStrategy resCol = result;

        foreach (var strat in strats)
        {
            rowStrategies.Add(strat);
            colStrategies.Add(strat);
        }

        var avgRowStrat = StrategyUsefulFunctions.AverageRowStrategy(rowStrategies, numberOfActions);
        var avgColStrat = StrategyUsefulFunctions.AverageColumnStrategy(colStrategies, numberOfActions);

        Assert.Equal(resRow.Data, avgRowStrat.Data);
        Assert.Equal(resCol.Data, avgColStrat.Data);
    }
}
