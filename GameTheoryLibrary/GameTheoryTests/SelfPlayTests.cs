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
            new double[,] { 
                { (double)1 / 3 },
                { (double)1 / 3 },
                { (double)1 / 3 } 
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
            new double[,] {
                { (double)3 / 6 },
                { (double)2 / 6 },
                { (double)1 / 6 }
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
            new double[,] {
                { (0.6+0.7+0.1) / 3 },
                { (0.2+0.2) / 3 },
                { (0.2+0.3+0.7) / 3 }
            }
        };

    }

    [Theory]
    [MemberData(nameof(TestData))]
    //public void AverageRowStrategyTest(RowStrategy r1, RowStrategy r2, RowStrategy r3, int numberOfActions, double[] result)
    public void AverageRowStrategyTest(List<double[]> strats, int numberOfActions, double[,] result)
    {
        List<RowStrategy> rowStrategies = [];
        foreach (var strat in strats)
            rowStrategies.Add(strat);        
        
        var avgStrat = SelfPlayAgent.AverageRowStrategy(rowStrategies, numberOfActions);

        Assert.Equal(result, avgStrat.Data);
    }
}
