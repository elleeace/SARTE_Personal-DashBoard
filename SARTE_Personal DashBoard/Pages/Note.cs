namespace SARTE_Personal_DashBoard.Pages
{
    internal class Note
    {

        public string Title { get; set; }
        public string Date { get; set; }
        public string Content { get; set; }

        public Note(string title, string date, string content)
        {
            Title = title;
            Date = date;
            Content = content;
        }

    }
}
