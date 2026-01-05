using System;
using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using mybooks.contracts;

namespace mybooks.ui
{
    public partial class MainWindow : Window
    {
        private readonly DataGrid? _dataGrid;
        private readonly Button? _btnNew;
        private readonly Button? _btnLend;
        private readonly Button? _btnReturn;
        private readonly Button? _btnRemove;

        public MainWindow() {
            InitializeComponent();

            // FindControl pattern - done once in constructor
            _dataGrid = this.FindControl<DataGrid>("dataGrid");
            _btnNew = this.FindControl<Button>("btnNew");
            _btnLend = this.FindControl<Button>("btnLend");
            _btnReturn = this.FindControl<Button>("btnReturn");
            _btnRemove = this.FindControl<Button>("btnRemove");

            // Async event handlers for dialog calls
            if (_btnNew != null) {
                _btnNew.Click += async (_, _) => {
                    var title = await InputBox.Show(this, "Title:");
                    if (!string.IsNullOrEmpty(title)) {
                        New_book(title);
                    }
                };
            }

            if (_btnLend != null) {
                _btnLend.Click += async (_, _) => {
                    var id = Id_of_selected_book();
                    if (!id.HasValue) {
                        return;
                    }
                    var name = await InputBox.Show(this, "Name:");
                    if (!string.IsNullOrEmpty(name)) {
                        Lend_book(id.Value, name);
                    }
                };
            }

            if (_btnReturn != null) {
                _btnReturn.Click += (_, _) => {
                    var id = Id_of_selected_book();
                    if (!id.HasValue) {
                        return;
                    }
                    Return_book(id.Value);
                };
            }

            if (_btnRemove != null) {
                _btnRemove.Click += (_, _) => {
                    var id = Id_of_selected_book();
                    if (!id.HasValue) {
                        return;
                    }
                    Remove_book(id.Value);
                };
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public void Update_books(IEnumerable<Book> books) {
            var items = new BookEntries();
            items.Update(books);
            if (_dataGrid != null) {
                _dataGrid.ItemsSource = items;
            }
        }

        private Guid? Id_of_selected_book() {
            if (_dataGrid == null) return null;
            var item = _dataGrid.SelectedItem as BookEntry;
            return item?.Id;
        }

        public event Action<string>? New_book;

        public event Action<Guid, string>? Lend_book;

        public event Action<Guid>? Return_book;

        public event Action<Guid>? Remove_book;
    }
}
