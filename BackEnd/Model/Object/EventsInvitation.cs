namespace Model.Object
{
    using System.Collections.Generic;

    public class EventsInvitation
    {
        public int UserId { get; set; }

        public IEnumerable<InvitationData> Events { get; set; }
    }
}