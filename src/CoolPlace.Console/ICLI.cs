namespace CoolPlace.Console
{
    public interface ICLI
    {
        int? ReadInt();
        string? ReadString();
        void WriteLine(string? value);
        void WriteLine(object value);
    }
}