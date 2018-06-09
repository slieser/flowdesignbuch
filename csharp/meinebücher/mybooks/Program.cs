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

            void start() {
                var books = interactors.Start();
                mainWindow.Update_books(books);
            }

            mainWindow.New_book += titel => {
                var books = interactors.New_book(titel);
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

            start();
            app.Run(mainWindow);
        }
    }
}