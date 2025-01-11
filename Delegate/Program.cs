using Delegate.Extensions;
using Delegate.Model;

namespace Delegate;

public class Program
{
    public static void Main(string[] args)
    {
        var array = new string[10].CreateRandomStringArray();
        Console.WriteLine(string.Join(',', array));

        var max = array.GetMax(x => int.Parse(x));
        Console.WriteLine($"Максимальный элемент: {max}");
        
        var walker = new DirectoryWalker();
        walker.FileFound += (o, fileArgs) => OnFileFound(o, fileArgs, "stop.txt");
        walker.Walk("C:\\");
    }

    static void OnFileFound(object? sender, FileArgs e, string stopFileName)
    {
        if (e.FileName.EndsWith(stopFileName))
        {
            e.Cancel = true;
            Console.WriteLine($"Файл {stopFileName} был найден: Поиск отменен.");
        }
        else
        {
            Console.WriteLine($"Проверен файл: {e.FileName}");
        }
    }
}