namespace csvviewer
{
    public class CommandLine
    {
        public static string GetFilename(string[] args) {
            return args[0];
        }

        public static int GetPageLength(string[] args) {
            if (args.Length > 1) {
                return int.Parse(args[1]);
            }
            return 5;
        }
    }
}