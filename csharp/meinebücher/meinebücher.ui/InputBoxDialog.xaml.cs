using System.Windows;

namespace meinebücher.ui
{
    public partial class InputBoxDialog : Window
    {
        public InputBoxDialog() {
            InitializeComponent();
            Loaded += (o, e) => {
                textbox.Focus();
            };
            btnOk.Click += (o, e) => {
                DialogResult = true;
                Close();
            };
            btnCancel.Click += (o, e) => {
                DialogResult = false;
                Close();
            };
        }
    }
}