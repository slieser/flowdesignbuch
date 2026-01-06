using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using mystocks.data;

namespace mystocks
{
    public partial class MainWindow : Window
    {
        public event Action<string> SearchStock;
        
        public event Action<string> TitelAusgewählt;

        public event Action<string> TitelEntfernen;
        
        public MainWindow()
        {
            InitializeComponent();

            var throttle = new Throttle();
            txtSuchbegriff.TextChanged += (_, _) => {
                if (string.IsNullOrWhiteSpace(txtSuchbegriff.Text)) {
                    return;
                }
                throttle.ExecuteThrottled(500, () => SearchStock?.Invoke(txtSuchbegriff.Text));
            };
  
            cmbTitelauswahl.SelectionChanged += (o, e) => {
                if (cmbTitelauswahl.SelectedItem == null) {
                    return;
                }
                var symbol = ((Titel) cmbTitelauswahl.SelectedItem).Symbol;
                TitelAusgewählt?.Invoke(symbol);
            };

            btnRemove.Click += (o, e) => {
                if (lstWertpapiere.SelectedItem == null) {
                    return;
                }
                var symbol = ((Wertpapier) lstWertpapiere.SelectedItem).Symbol;
                TitelEntfernen(symbol);
            };
        }

        public async Task WertpapiereAktualisieren(IAsyncEnumerable<Wertpapier> wertpapiere) {
            var items = new List<Wertpapier>();
            items.AddRange(await wertpapiere.ToListAsync());
            lstWertpapiere.ItemsSource = items;
        }

        public async Task TitelAktualisieren(IAsyncEnumerable<Titel> titel) {
            var items = new List<Titel>();
            items.AddRange(await titel.ToListAsync());
            cmbTitelauswahl.ItemsSource = items;
            cmbTitelauswahl.IsDropDownOpen = true;
        }
    }
}