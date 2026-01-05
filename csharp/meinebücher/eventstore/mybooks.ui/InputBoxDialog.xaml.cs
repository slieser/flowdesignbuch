using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace mybooks.ui
{
    public class InputBoxDialog : Window
    {
        private readonly Button? _btnOk;
        private readonly Button? _btnCancel;

        public InputBoxDialog() {
            InitializeComponent();

            var textbox = this.FindControl<TextBox>("textbox");
            _btnOk = this.FindControl<Button>("btnOk");
            _btnCancel = this.FindControl<Button>("btnCancel");

            Opened += (o, e) => {
                textbox?.Focus();
            };

            if (_btnOk != null) {
                _btnOk.Click += (o, e) => {
                    Close(true);
                };
            }

            if (_btnCancel != null) {
                _btnCancel.Click += (o, e) => {
                    Close(false);
                };
            }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
