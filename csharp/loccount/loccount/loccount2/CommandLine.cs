using Optional;

namespace loccount
{
    public class CommandLine
    {
        public static Option<string> GetPath(string[] args) {
            if(args.Length >= 1) {
                return Option.Some(args[0]);
            }
            return Option.None<string>();
        }
    }
}