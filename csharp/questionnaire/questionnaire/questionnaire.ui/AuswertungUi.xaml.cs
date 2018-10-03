using System.Windows;
using System.Windows.Controls;
using questionnaire.contracts;

namespace questionnaire.ui
{
    public partial class AuswertungUi : Window
    {
        public AuswertungUi()
        {
            InitializeComponent();
        }

        public void Update(Auswertung auswertung) {
            var prozent = auswertung.RichtigeAufgaben * 100.0 / auswertung.AnzahlAufgaben;
            _label.Content = $"Sie haben {auswertung.RichtigeAufgaben} von {auswertung.AnzahlAufgaben} richtig beantwortet ({prozent:F1}%)";
            foreach (var ergebniss in auswertung.Ergebnisse) {
                var label = new Label();
                label.Content = ergebniss.Frage + "\n  ";
                if (ergebniss.IstKorrekt) {
                    label.Content += $"Ihre Antwort '{ergebniss.GegebeneAntwort}' ist richtig.";
                }
                else {
                    label.Content += $"Ihre Antwort '{ergebniss.GegebeneAntwort}' ist falsch. Richtig ist '{ergebniss.RichtigeAntwort}'.";
                }
                _panel.Children.Add(label);
            }
        }
    }
}
