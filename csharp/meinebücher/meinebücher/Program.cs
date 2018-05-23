using System;
using System.Windows;
using meinebücher.ui;

namespace meinebücher
{
    public static class Program
    {
        [STAThread]
        public static void Main() {
            var mainWindow = new MainWindow();
            var interactors = new Interactors();
            var app = new Application { MainWindow = mainWindow };

            void start() {
                var bücher = interactors.Start();
                mainWindow.Update_books(bücher);
            }

            mainWindow.New_book += titel => {
                var bücher = interactors.Neues_Buch(titel);
                mainWindow.Update_books(bücher);
            };
            mainWindow.Lend_book += (id, name) => {
                var bücher = interactors.Buch_verleihen(id, name);
                mainWindow.Update_books(bücher);
            };
            mainWindow.Book_got_back += (id) => {
                var bücher = interactors.Buch_zurückgegeben(id);
                mainWindow.Update_books(bücher);
            };
            mainWindow.Remove_book += (id) => {
                var bücher = interactors.Buch_löschen(id);
                mainWindow.Update_books(bücher);
            };

            start();
            app.Run(mainWindow);
        }
    }
}