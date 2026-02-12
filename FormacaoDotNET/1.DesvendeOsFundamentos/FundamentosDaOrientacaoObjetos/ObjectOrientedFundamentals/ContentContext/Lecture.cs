using ObjectOrientedFundamentals.ContentContext.Enums;

namespace ObjectOrientedFundamentals.ContentContext
{
    public class Lecture : Base
    {
        public Lecture()
        {

        }
        public int Order { get; set; }
        public string Title { get; set; }
        public int DurationInMinutes { get; set; }
        public EContentLevel Level { get; set; }

    }
}
