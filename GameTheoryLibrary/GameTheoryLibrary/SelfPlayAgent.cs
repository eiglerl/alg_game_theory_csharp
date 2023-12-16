namespace GameTheoryLibrary;

// Define a delegate type for choosing the next strategy
public delegate RowStrategy ChooseNextRowStrategyDelegate(Matrix utility, List<ColumnStrategy> colStrategies);
public delegate ColumnStrategy ChooseNextColumnStrategyDelegate(Matrix utility, List<RowStrategy> rowStrategies);

public partial class SelfPlayAgent
{

    // Property to set the delegate for choosing the next strategy
    //public ChooseNextRowStrategyDelegate ChooseNextRowStrategy { get; set; }
    //public ChooseNextColumnStrategyDelegate ChooseNextColumnStrategy { get; set; }


    //public SelfPlayAgent(Matrix matrix, ChooseNextRowStrategyDelegate? rowStrat = null, ChooseNextColumnStrategyDelegate? colStrat = null)
    //    : this(matrix, -matrix, rowStrat, colStrat) { }

    //public SelfPlayAgent(Matrix matrix1, Matrix matrix2, ChooseNextRowStrategyDelegate? rowStrat = null, ChooseNextColumnStrategyDelegate? colStrat = null)
    //{
    //    utilityMatrix1 = matrix1;
    //    utilityMatrix2 = matrix2;
    //    rowStrategies = [];
    //    columnStrategies = [];

    //    ChooseNextRowStrategy = rowStrat is not null ? rowStrat : BestRespondLastColumnStrat;
    //    ChooseNextColumnStrategy = colStrat is not null ? colStrat : BestRespondLastRowStrat;
    //}


    public static ColumnStrategy BestRespondAverageRowStrat(Matrix utility, List<RowStrategy> rowStrategies)
    {
        if (rowStrategies.Count == 0)
            return StrategyUsefulFunctions.CreateUniformStrat(utility.Shape.Columns);

        var avgRow = StrategyUsefulFunctions.AverageRowStrategy(rowStrategies, numberOfActions: utility.Shape.Rows);
        return MatrixGameEvaluator.GetBestResponse(utility, avgRow);
    }

    public static RowStrategy BestRespondAverageColumnStrat(Matrix utility, List<ColumnStrategy> colStrategies)
    {
        if (colStrategies.Count == 0)
            return StrategyUsefulFunctions.CreateUniformStrat(utility.Shape.Rows);

        var avgCol = StrategyUsefulFunctions.AverageColumnStrategy(colStrategies, numberOfActions: utility.Shape.Columns);
        return MatrixGameEvaluator.GetBestResponse(utility, avgCol);
    }
    
    public static RowStrategy BestRespondLastColumnStrat(Matrix utility, List<ColumnStrategy> colStrategies)
    {
        if (colStrategies.Count == 0)
            return StrategyUsefulFunctions.CreateUniformStrat(utility.Shape.Rows);

        var lastColStrat = colStrategies[^1];
        return MatrixGameEvaluator.GetBestResponse(utility, lastColStrat);
    }

    public static ColumnStrategy BestRespondLastRowStrat(Matrix utility, List<RowStrategy> rowStrategies)
    {
        if (rowStrategies.Count == 0)
            return StrategyUsefulFunctions.CreateUniformStrat(utility.Shape.Columns);

        var lastRowStrat = rowStrategies[^1];
        return MatrixGameEvaluator.GetBestResponse(utility, lastRowStrat);
    }

    public static List<double> Play(Matrix utility1, Matrix utility2, int numberOfTurns = 20, ChooseNextRowStrategyDelegate? rowStratGenerator = null, ChooseNextColumnStrategyDelegate? colStratGenerator = null)
    {
        // if null use BR to last opponent strat
        rowStratGenerator ??= BestRespondLastColumnStrat;
        colStratGenerator ??= BestRespondLastRowStrat;

        List<RowStrategy> rowStrategies = [];
        List<ColumnStrategy> colStrategies = [];

        List<double> exploitabilities = [];

        for (int i = 0; i < numberOfTurns; i++)
        {
            Console.WriteLine($"Turn {i+1}");
            RowStrategy row = rowStratGenerator(utility1, colStrategies);
            ColumnStrategy col = colStratGenerator(utility2, rowStrategies);
            Console.WriteLine($"col strat: {col}");
            Console.WriteLine($"row strat: {row}");
            Console.WriteLine("---------");

            RowStrategy avgRow = StrategyUsefulFunctions.AverageRowStrategy(rowStrategies, utility1.Shape.Rows);
            ColumnStrategy avgCol = StrategyUsefulFunctions.AverageColumnStrategy(colStrategies, utility1.Shape.Columns);

            var exploitability = MatrixGameEvaluator.CalculateExploitability(utility1, utility2, avgRow, avgCol);
            exploitabilities.Add(exploitability);

            rowStrategies.Add(row);
            colStrategies.Add(col);
        }
        Console.WriteLine("Average strategies:");
        RowStrategy avgLastRow = StrategyUsefulFunctions.AverageRowStrategy(rowStrategies, utility1.Shape.Rows);
        ColumnStrategy avgLastCol = StrategyUsefulFunctions.AverageColumnStrategy(colStrategies, utility1.Shape.Columns);
        Console.WriteLine($"row: {avgLastRow}");
        Console.WriteLine($"column: {avgLastCol}");

        return exploitabilities;
    }

    public static List<double> Play(Matrix utility, int numberOfTurns = 20, ChooseNextRowStrategyDelegate? rowStratGenerator = null, ChooseNextColumnStrategyDelegate? colStratGenerator = null)
        => Play(utility, -utility, numberOfTurns, rowStratGenerator, colStratGenerator);

}