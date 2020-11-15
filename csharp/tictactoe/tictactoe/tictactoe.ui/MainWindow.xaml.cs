using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace tictactoe.ui
{
    public class MainWindow : Window
    {
        private readonly Button[] _buttons = new Button[9];
        public event Action<int> Token_set;

        public MainWindow() {
            InitializeComponent();
            _buttons[0] = this.FindControl<Button>("btn0");
            _buttons[1] = this.FindControl<Button>("btn1");
            _buttons[2] = this.FindControl<Button>("btn2");
            _buttons[3] = this.FindControl<Button>("btn3");
            _buttons[4] = this.FindControl<Button>("btn4");
            _buttons[5] = this.FindControl<Button>("btn5");
            _buttons[6] = this.FindControl<Button>("btn6");
            _buttons[7] = this.FindControl<Button>("btn7");
            _buttons[8] = this.FindControl<Button>("btn8");
            for (int i = 0; i < _buttons.Length; i++) {
                var token = i;
                _buttons[i].Click += (s, a) => { Token_set(token); };
            }
        }

        private void InitializeComponent() {
            AvaloniaXamlLoader.Load(this);
        }

        public void Show_score(char[] spielbrett, string meldung) {
            var txtMessage = this.FindControl<TextBlock>("txtMeldung");
            txtMessage.Text = meldung;

            for (int i = 0; i < spielbrett.Length; i++) {
                _buttons[i].Content = spielbrett[i];
            }
        }
    }
}