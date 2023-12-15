namespace GameTheory;

using GameTheoryLibrary;

internal class Program
{
    static void Main(string[] args)
    {
        //ColumnStrategy col = new double[] { 0.1, 0.3, 0.5 };
        //RowStrategy row = new double[] { 0.1, 0.3, 0.5 };

        //Matrix utilityMatrix = new double[,] {
        //    { 0, 1, -1 },
        //    { -1, 0, 1 },
        //    { 1, -1, 0 }
        //};

        ////ColumnStrategy col = new double[] { 0.2, 0.3, 0.5 };
        ////RowStrategy row = new double[] { 0.2, 0.8 };

        ////Matrix utilityMatrix = new double[,]
        ////{
        ////    { 0, 1, -1 },
        ////    { -1, 0, 1 }
        ////};

        //Console.WriteLine("Utility matrix:");
        //utilityMatrix.Print();
        //var brToCol = MatrixGameEvaluator.GetBestResponse(utilityMatrix, col);
        //Console.WriteLine("Col and br");
        //col.Print();
        //brToCol.Print();
        //Console.WriteLine("Row and br");
        //var brToRow = MatrixGameEvaluator.GetBestResponse(-utilityMatrix, row);
        //row.Print();
        //brToRow.Print();

        ////RowStrategy row = new double[] { 0, 0, 1 };
        ////ColumnStrategy col = new double[] { 0, 1, 0 };

        ////row.Print();
        ////col.Print();

        //(double rowVal, double colVal) = MatrixGameEvaluator.EvaluateStrategies(utilityMatrix, row, col);
        //Console.WriteLine($"row {rowVal}, col {colVal}");


        //Matrix utilityMatrix = new double[,]
        //{
        //    { 0, 1, -1 },
        //    { -1, 0, 1 },
        //    { 1, -1, 0 }
        //};

        //RowStrategy row = new double[] { 0.1, 0.2, 0.7 };
        //ColumnStrategy brToRow = MatrixGameEvaluator.GetBestResponse(utilityMatrix, row);

        //brToRow.Print();

        //matrix = np.array([[2, 0, 0.8],
        //[-1, 1, -0.5]])
        Matrix utilityMatrix = new double[,]
        {
            { -1, 0, -0.8 },
            { 1, -1, -0.5 }
        };

        MatrixGameEvaluator.BestResponseValueFunction(utilityMatrix);
    }
}
