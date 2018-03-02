using System.Collections.Generic;
using System.Linq;
using Eto.Drawing;
using Eto.Forms;

namespace tictactoe.ui
{
    public class Ui : Form
    {
        private readonly Button[] _buttons;
        private readonly Label _message;

        public Ui() {
            Title = "TicTacToe";
            ClientSize = new Size(260, 160);

            Menu = new MenuBar {
                QuitItem = new Command((sender, e) => Application.Instance.Quit()) {
                    MenuText = "Quit",
                    Shortcut = Application.Instance.CommonModifier | Keys.Q
                }
            };

            _buttons = CreateButtons().ToArray();

            _message = new Label();
            Content = new TableLayout {
                Spacing = new Size(5, 5),
                Padding = new Padding(10, 10, 10, 10),
                Rows = {
                    new TableRow(CreateStackLayout(_buttons[0], _buttons[1], _buttons[2])),
                    new TableRow(CreateStackLayout(_buttons[3], _buttons[4], _buttons[5])),
                    new TableRow(CreateStackLayout(_buttons[6], _buttons[7], _buttons[8])),
                    new TableRow(_message) {ScaleHeight = true}
                }
            };
        }

        private StackLayout CreateStackLayout(params Button[] buttons) {
            var stackLayout = new StackLayout{ Orientation = Orientation.Horizontal};
            foreach (var button in buttons) {
                stackLayout.Items.Add(button);
            }

            return stackLayout;
        }

        private IEnumerable<Button> CreateButtons() {
            for (var i = 0; i < 9; i++) {
                yield return new Button { Tag = i };
            }
        }

        public void Spielstand_anzeigen(char[] spielbrett, string meldung) {
            for (var i = 0; i < 9; i++) {
                _buttons[i].Text = spielbrett[i].ToString();
            }
            _message.Text = meldung;
        }
    }
}
