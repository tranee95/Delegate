namespace Delegate.Model;

public class FileArgs(string fileName) : EventArgs
{
    public string FileName { get; set; } = fileName;
    public bool Cancel { get; set; }
}