using ObjectOrientedFundamentals.ContentContext.Enums;

namespace ObjectOrientedFundamentals.ContentContext
{
    public class Course : Content
    {
        // Constructor to initialize the Modules list
        public Course()
        {
            Modules = new List<Module>();
        }

        public string Tag { get; set; }
        public IList<Module> Modules { get; set; }
        public int DurationInMinutes { get; set; }
        public EContentLevel Level { get; set; }


    }
}
