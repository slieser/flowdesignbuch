using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using questionnaire.contracts;

namespace questionnaire.ui
{
    public partial class FragebogenUi : Window
    {
        public event Action<int> Antwort_gegeben; 

        public FragebogenUi() {
            InitializeComponent();
        }

        public void Update(IEnumerable<Aufgabe> aufgaben, bool auswertbar) {
            _panel.Children.Clear();
            foreach (var aufgabe in aufgaben) {
                var panel = new StackPanel {Orientation = Orientation.Vertical, Margin = new Thickness(10) };
                var label = new Label {Content = aufgabe.Frage};
                panel.Children.Add(label);
                foreach (var antwortmöglichkeit in aufgabe.Antwortmöglichkeiten) {
                    var radio = new RadioButton {
                        Content = antwortmöglichkeit.Antwort,
                        Tag = antwortmöglichkeit.Id,
                        IsChecked = antwortmöglichkeit.IstGegeben
                    };
                    radio.Checked += (o, e) => Antwort_gegeben((int)radio.Tag);
                    panel.Children.Add(radio);
                }
                _panel.Children.Add(panel);
            }
            _btnAuswerten.IsEnabled = auswertbar;
        }
    }
}