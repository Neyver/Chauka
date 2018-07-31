namespace Model.Object
{
    using System;

    public class InvitationData
    {
        public int EventId { get; set; }

        public string NameEvent { get; set; }

        public DateTime StartDatetime { get; set; }

        public int GuestId { get; set; }
    }
}
