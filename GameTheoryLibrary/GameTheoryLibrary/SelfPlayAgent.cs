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


    //public

}