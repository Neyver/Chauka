namespace Model.Object
{
    using System.ComponentModel.DataAnnotations;
    using Model.Core;

    public class Guest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int EventId { get; set; }
    }
}
