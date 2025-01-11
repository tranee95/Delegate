using System.Text;

namespace Delegate.Extensions;

public static class ClassExtensions
{
    public static int GetMax<T>(this T[] collection, Func<T, int> convertToNumber) where T : class
    {
        ValidatorCollection(collection);
        ValidatorFunc(convertToNumber);

        return collection.Select(convertToNumber).Max();
    }

    public static string[] CreateRandomStringArray<T>(this T[] collection)
    {
        var random = new Random();
        var array = new string[collection.Length];

        for (var i = 0; i < collection.Length; i++)
        {
            array[i] = random.Next().ToString();
        }

        return array;
    }

    private static void ValidatorCollection<T>(T collection) where T : class
    {
        ArgumentNullException.ThrowIfNull(collection);
    }
    
    private static void ValidatorFunc<T>(Func<T, int> func) where T : class
    {
        ArgumentNullException.ThrowIfNull(func);
    }
}