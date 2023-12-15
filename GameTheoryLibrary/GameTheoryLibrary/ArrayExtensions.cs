namespace GameTheoryLibrary;

public static class ArrayExtensions
{
    public static T[] Flatten<T>(this T[,] array)
    {
        return array.Cast<T>().ToArray();
    }
}
