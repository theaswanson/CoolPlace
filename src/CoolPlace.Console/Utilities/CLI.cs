namespace CoolPlace.Console.Utilities
{
    public class CLI : ICLI
    {
        public string? ReadString() => System.Console.ReadLine();

        public int? ReadInt()
        {
            var line = ReadString();
            var successfulParse = int.TryParse(line, out int result);
            return successfulParse ? result : null;
        }

        public void WriteLine() => WriteLine(string.Empty);

        public void WriteLine(object value) => WriteLine(value.ToString());

        public void WriteLine(string? value)
        {
            System.Console.WriteLine(value);
        }
    }
}