using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using mystocks.data;

namespace mystocks
{
    public class MainWindow : Window
    {
        public event Action<string> SuchbegriffGeändert;
        
        public event Action<string> TitelAusgewählt;

        public event Action<string> TitelEntfernen;
        
        public MainWindow()
        {
            InitializeComponent();

            var throttle = new Throttle();
            var txtSuchbegriff = this.FindControl<TextBox>("txtSuchbegriff");
            txtSuchbegriff.TextChanged += (_, _) => {
                if (string.IsNullOrWhiteSpace(txtSuchbegriff.Text)) {
                    return;
                }
                throttle.ExecuteThrottled(500, () => SuchbegriffGeändert?.Invoke(txtSuchbegriff.Text));
            };
  
            var cmbTitel = this.FindControl<ComboBox>("cmbTitelauswahl");
            cmbTitel.SelectionChanged += (o, e) => {
                if (cmbTitel.SelectedItem == null) {
                    return;
                }
                var symbol = ((Titel) cmbTitel.SelectedItem).Symbol;
                TitelAusgewählt?.Invoke(symbol);
            };

            var lstWertpapiere = this.FindControl<ListBox>("lstWertpapiere");
            var btnRemove = this.FindControl<Button>("btnRemove");
            btnRemove.Click += (o, e) => {
                if (lstWertpapiere.SelectedItem == null) {
                    return;
                }
                var symbol = ((Wertpapier) lstWertpapiere.SelectedItem).Symbol;
                TitelEntfernen(symbol);
            };
        }

        public async Task WertpapiereAktualisieren(IAsyncEnumerable<Wertpapier> wertpapiere) {
            var lstWertpapiere = this.FindControl<ListBox>("lstWertpapiere");
            var items = new List<Wertpapier>();
            items.AddRange(await wertpapiere.ToListAsync());
            lstWertpapiere.ItemsSource = items;
        }

        public async Task TitelAktualisieren(IAsyncEnumerable<Titel> titel) {
            var cmbTitel = this.FindControl<ComboBox>("cmbTitelauswahl");
            var items = new List<Titel>();
            items.AddRange(await titel.ToListAsync());
            cmbTitel.ItemsSource = items;
            cmbTitel.IsDropDownOpen = true;
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}