namespace CoolPlace.Console.Utilities
{
    public interface ICLI
    {
        int? ReadInt();
        string? ReadString();
        void WriteLine();
        void WriteLine(string? value);
        void WriteLine(object value);
    }
}