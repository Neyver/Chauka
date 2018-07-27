namespace Model.Object
{
    using System.Collections.Generic;

    public class EventGuests
    {
        public int EventId { get; set; }

        public IEnumerable<EventGuest> Guests { get; set; }
    }
}
