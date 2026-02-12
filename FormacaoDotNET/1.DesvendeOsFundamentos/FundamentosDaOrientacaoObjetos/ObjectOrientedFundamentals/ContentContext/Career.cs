namespace ObjectOrientedFundamentals.ContentContext
{
    public class Career : Content
    {
        public Career()
        {
            Items = new List<CareerItem>();
        }

        public IList<CareerItem> Items { get; set; }

        //Expression-bodied property to calculate the total number of courses in the career
        public int TotalCourses => Items.Count;

    }
}
