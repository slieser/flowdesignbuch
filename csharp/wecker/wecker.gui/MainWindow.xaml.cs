using System;
using System.Windows;

namespace wecker.gui
{
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
            Weckzeit_Eingabe();

            radioWeckzeit.Click += (o, e) => {
                Weckzeit_Eingabe();
            };

            radioRestzeit.Click += (o, e) => {
                Restzeit_Eingabe();
            };

            btnStart.Click += (o, e) => {
                if (radioWeckzeit.IsChecked.Value) {
                    if (DateTime.TryParse(txtWeckzeit.Text, out var weckzeit)) {
                        Start_mit_Weckzeit(weckzeit);
                    }
                }
                else {
                    if (TimeSpan.TryParse(txtRestzeit.Text, out var restzeit)) {
                        Start_mit_Restzeit(restzeit);
                    }
                }
            };

            btnStopp.Click += (o, e) => Stopp();
        }

        private void Weckzeit_Eingabe() {
            txtWeckzeit.IsEnabled = true;
            txtRestzeit.IsEnabled = false;
            radioWeckzeit.IsChecked = true;
            radioRestzeit.IsChecked = false;
        }

        private void Restzeit_Eingabe() {
            txtWeckzeit.IsEnabled = false;
            txtRestzeit.IsEnabled = true;
            radioWeckzeit.IsChecked = false;
            radioRestzeit.IsChecked = true;
        }

        public event Action<DateTime> Start_mit_Weckzeit;

        public event Action<TimeSpan> Start_mit_Restzeit;

        public event Action Stopp;

        public void Neue_Restzeit(TimeSpan restzeit) {
            lblRestzeit.Content = restzeit.ToString(@"hh\:mm\:ss");
        }

        public void Neuer_Zustand(bool istGestartet) {
            btnStart.IsEnabled = !istGestartet;
            btnStopp.IsEnabled = istGestartet;

            lblRestzeit.Visibility = istGestartet ? Visibility.Visible : Visibility.Hidden;
        }

        public void Neue_Uhrzeit(DateTime uhrzeit) {
            lblUhrzeit.Content = uhrzeit.ToLongTimeString();
        }
    }
}