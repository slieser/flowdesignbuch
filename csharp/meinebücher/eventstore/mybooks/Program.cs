using Avalonia;
using Avalonia.Controls;
using mybooks.ui;

namespace mybooks
{
    public static class Program
    {
        public static void Main(string[] args) => BuildAvaloniaApp().Start(AppMain, args);

        private static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace();

        private static void AppMain(Application app, string[] args)
        {
            var mainWindow = new MainWindow();
            var interactors = new Interactors();

            void Start() {
                var books = interactors.Start();
                mainWindow.Update_books(books);
            }

            mainWindow.New_book += title => {
                var books = interactors.New_book(title);
                mainWindow.Update_books(books);
            };
            mainWindow.Lend_book += (id, name) => {
                var books = interactors.Lend_book(id, name);
                mainWindow.Update_books(books);
            };
            mainWindow.Book_got_back += (id) => {
                var books = interactors.Book_got_back(id);
                mainWindow.Update_books(books);
            };
            mainWindow.Remove_book += (id) => {
                var books = interactors.Remove_book(id);
                mainWindow.Update_books(books);
            };

            Start();
            app.Run(mainWindow);
        }
    }
}
