namespace Model.Object
{
    using Model.Core;
    using System.Collections.Generic;

    public class UserEvent 
    {
        public int UserId { get; set; }

        public IEnumerable<Event> Events { get; set; }
    }
}
