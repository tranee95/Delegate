using Delegate.Model;

namespace Delegate;

public class DirectoryWalker
{
    public event EventHandler<FileArgs>? FileFound;

    public void Walk(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentException("Путь к искомому файлу не должен быть пустым", nameof(path));
        }

        foreach (var file in Directory.GetFiles(path))
        {
            var args = new FileArgs(file);
            FileFound?.Invoke(this, args);

            if (args.Cancel)
            {
                break;
            }
        }
    }
}