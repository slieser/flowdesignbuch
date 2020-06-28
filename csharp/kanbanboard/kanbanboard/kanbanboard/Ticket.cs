namespace kanbanboard
{
    public class Ticket
    {
        public string Text { get; set; }

        public string Id { get; set; }

        public int ColumnIndex { get; set; }

        public int Position { get; set; }
    }
}