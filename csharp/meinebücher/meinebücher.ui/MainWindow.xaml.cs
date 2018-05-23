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
            btnNeu.Click += (o, e) => {
                var titel = InputBox.Show("Titel:");
                if (!string.IsNullOrEmpty(titel)) {
                    Neues_Buch(titel);
                }
            };
            btnVerleihen.Click += (o, e) => {
                var id = Id_des_selektierten_Buchs();
                if (!id.HasValue) {
                    return;
                }
                var name = InputBox.Show("Name:");
                if (!string.IsNullOrEmpty(name)) {
                    Buch_verleihen(id.Value, name);
                }
            };
            btnZurück.Click += (o, e) => {
                var id = Id_des_selektierten_Buchs();
                if (!id.HasValue) {
                    return;
                }
                Buch_zurückgeben(id.Value);
            };
            btnLöschen.Click += (o, e) => {
                var id = Id_des_selektierten_Buchs();
                if (!id.HasValue) {
                    return;
                }
                Buch_löschen(id.Value);
            };
        }

        public void Aktualisiere_Bücher(IEnumerable<Buch> bücher) {
            var items = new List<Bucheintrag>();
            foreach (var buch in bücher) {
                var item = new Bucheintrag {
                    Id = buch.CorrelationId,
                    Titel = buch.Titel,
                    Ausleiher = buch.Ausleiher,
                    Leihdatum = buch.Leihdatum
                };
                items.Add(item);
            }
            dataGrid.DataContext = items;
        }

        private Guid? Id_des_selektierten_Buchs() {
            var item = dataGrid.SelectedItem as Bucheintrag;
            return item?.Id;
        }

        public event Action<string> Neues_Buch;

        public event Action<Guid, string> Buch_verleihen;

        public event Action<Guid> Buch_zurückgeben;

        public event Action<Guid> Buch_löschen;
    }
}