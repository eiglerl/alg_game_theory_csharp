namespace GameTheoryLibrary;

public static class DoubleArrayExtensions
{
    public static int Argmax(this double[] array)
    {
        int maxIndex = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > maxIndex)
            {
                maxIndex = i;
            }
        }
        return maxIndex;
    }
}
