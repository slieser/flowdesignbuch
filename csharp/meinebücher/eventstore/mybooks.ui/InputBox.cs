using System.Threading.Tasks;
using Avalonia.Controls;

namespace mybooks.ui
{
    public static class InputBox
    {
        public async static Task<string> Show(Window owner, string prompt) {
            var inputBoxDialog = new InputBoxDialog();
            var label = inputBoxDialog.FindControl<TextBlock>("label");
            var textbox = inputBoxDialog.FindControl<TextBox>("textbox");

            if (label != null) {
                label.Text = prompt;
            }

            var result = await inputBoxDialog.ShowDialog<bool>(owner);

            if (!result) {
                return "";
            }
            return textbox?.Text ?? "";
        }
    }
}
