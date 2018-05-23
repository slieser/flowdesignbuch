using System;
using System.Collections.Generic;
using System.Windows;
using meinebücher.contracts;

namespace meinebücher.ui
{
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
            btnNew.Click += (o, e) => {
                var title = InputBox.Show("Title:");
                if (!string.IsNullOrEmpty(title)) {
                    New_book(title);
                }
            };
            btnLend.Click += (o, e) => {
                var id = Id_of_selected_book();
                if (!id.HasValue) {
                    return;
                }
                var name = InputBox.Show("Name:");
                if (!string.IsNullOrEmpty(name)) {
                    Lend_book(id.Value, name);
                }
            };
            btnGetBack.Click += (o, e) => {
                var id = Id_of_selected_book();
                if (!id.HasValue) {
                    return;
                }
                Book_got_back(id.Value);
            };
            btnRemove.Click += (o, e) => {
                var id = Id_of_selected_book();
                if (!id.HasValue) {
                    return;
                }
                Remove_book(id.Value);
            };
        }

        public void Update_books(IEnumerable<Book> books) {
            var items = new BookEntries();
            items.Update(books);
            dataGrid.DataContext = items;
        }

        private Guid? Id_of_selected_book() {
            var item = dataGrid.SelectedItem as BookEntry;
            return item?.Id;
        }

        public event Action<string> New_book;

        public event Action<Guid, string> Lend_book;

        public event Action<Guid> Book_got_back;

        public event Action<Guid> Remove_book;
    }
}