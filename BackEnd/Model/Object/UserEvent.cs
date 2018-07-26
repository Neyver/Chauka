namespace Model.Object
{
    using System.Collections.Generic;

    public class UserEvent 
    {
        public int UserId { get; set; }

        public IEnumerable<Event> Events { get; set; }
    }
}
