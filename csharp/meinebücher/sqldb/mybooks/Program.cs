using System;
using System.Windows;
using mybooks.ui;

namespace mybooks
{
    public static class Program
    {
        [STAThread]
        public static void Main() {
            var mainWindow = new MainWindow();
            var interactors = new Interactors();
            var app = new Application { MainWindow = mainWindow };

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
            mainWindow.Return_book += (id) => {
                var books = interactors.Return_book(id);
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