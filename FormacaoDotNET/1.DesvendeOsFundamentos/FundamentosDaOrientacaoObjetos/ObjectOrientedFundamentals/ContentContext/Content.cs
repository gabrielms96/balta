namespace ObjectOrientedFundamentals.ContentContext
{
    // Abstract class - cannot be instantiated directly, serves as a base for other classes
    public abstract class Content
    {
        // Global unique identifier - GUID
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        public Content()
        {
            Id = Guid.NewGuid(); //SPOF - Single Point of Failure
            //Id = new Guid(); //Wrong way to generate a new GUID, it will always generate the same GUID (00000000-0000-0000-0000-000000000000)
        }
    }
}
