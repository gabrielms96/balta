using ObjectOrientedFundamentals.NotificationContext;

namespace ObjectOrientedFundamentals.ContentContext
{
    public abstract class Base : Notifiable
    {
        public Base()
        {
            Id = Guid.NewGuid(); //SPOF - Single Point of Failure
            //Id = new Guid(); //Wrong way to generate a new GUID, it will always generate the same GUID (00000000-0000-0000-0000-000000000000)
        }

        // Global unique identifier - GUID
        public Guid Id { get; set; }
    }
}
