namespace Model.Object
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Model.Core;

    public class Event : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NameEvent { get; set; }

        [Required]
        public DateTime StartDatetime { get; set; }

        public DateTime? EndDatetime { get; set; }

        [Required]
        public int UserId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
