namespace ObjectOrientedFundamentals.ContentContext
{
    // Abstract class - cannot be instantiated directly, serves as a base for other classes
    public abstract class Content : Base
    {
        public Content(string title, string url)
        {
            Title = title;
            Url = url;
        }

        public string Title { get; set; }
        public string Url { get; set; }
    }
}
