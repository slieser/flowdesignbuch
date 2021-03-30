using System.IO;

namespace fehlerbehandlung
{
    public class ErrorDetection
    {
        public bool TryReadFile(string filename, out string[] fileContent) {
            try {
                fileContent = File.ReadAllLines(filename);
                return true;
            }
            catch {
                fileContent = new string[0];
                return false;
            }
        }
    }
}