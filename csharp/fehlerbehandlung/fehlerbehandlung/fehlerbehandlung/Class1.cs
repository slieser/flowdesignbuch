using System;
using Optional;
using Optional.Unsafe;

namespace fehlerbehandlung
{
    public class Class1
    {
        public string GetFilename(string[] args) {
            if (args.Length > 0) {
                return args[0];
            }
            return "";
        }
    }

    public class Class2
    {
        public void GetFilename(string[] args, Action<string> onFilename, Action onNoFilename) {
            if (args.Length > 0) {
                onFilename(args[0]);
            }
            else {
                onNoFilename();
            }
        }

        public void Usage() {
            var args = new[] {""};
            GetFilename(args,
                onFilename: filename => {
                    Console.WriteLine(filename);
                },
                onNoFilename: () => {
                    // ...
                });
        }
    }

    public class Class3
    {
        public Option<string> GetFilename(string[] args) {
            if (args.Length > 0) {
                return Option.Some(args[0]);
            }
            return Option.None<string>();
        }
        
        public void Usage() {
            var args = new[] {""};
            var filename = GetFilename(args);
            if (filename.HasValue) {
                Console.WriteLine(filename.ValueOrFailure());
            }
            else {
                // ...
            }
        }
    }

    public class Class4
    {
        public bool TryGetFilename(string[] args, out string filename) {
            if (args.Length > 0) {
                filename = args[0];
                return true;
            }
            filename = "";
            return false;
        }

        public void Usage() {
            var args = new[]{""};
            if (TryGetFilename(args, out var filename)) {
                Console.WriteLine(filename);
            }
            else {
                // ...
            }
        }
    }


    public class Class5
    {
        public (bool hasResult, string filename) GetFilename(string[] args) {
            if (args.Length > 0) {
                var filename = args[0];
                return (true, filename);
            }
            return (false, "");
        }

        public void Usage() {
            var args = new[]{""};
            var (hasResult, filename) = GetFilename(args);
            if (hasResult) {
                Console.WriteLine(filename);
            }
            else {
                // ...
            }
        }
    }
}