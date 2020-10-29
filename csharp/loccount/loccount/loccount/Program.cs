namespace loccount
{
    internal class Program
    {
        public static void Main(string[] args) {
            var locStats = Interactors.Start(args);
            Ui.Show(locStats);
        }
    }
}