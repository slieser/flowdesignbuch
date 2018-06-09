namespace mybooks.ui
{
    public static class InputBox
    {
        public static string Show(string prompt) {
            var inputBoxDialog = new InputBoxDialog();
            inputBoxDialog.label.Content = prompt;
            var result = inputBoxDialog.ShowDialog();

            if (!result.HasValue || !result.Value) {
                return "";
            }
            return inputBoxDialog.textbox.Text;
        }
    }
}