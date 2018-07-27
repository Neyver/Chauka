namespace Model.Object
{
    using System.Collections.Generic;

    public class EventGuests
    {
        public int UserId { get; set; }

        public IEnumerable<Guest> Guest { get; set; }
    }
}