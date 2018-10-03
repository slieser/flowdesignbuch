namespace csvviewer
{
    public class CommandLine
    {
        private int _pageLength;

        public string GetFilename(string[] args) {
            return args[0];
        }

        public int GetPageLength(string[] args) {
            _pageLength = args.Length > 1 ? int.Parse(args[1]) : 10;
            return _pageLength;
        }

        public int GetPageLength() {
            return _pageLength;
        }
    }
}