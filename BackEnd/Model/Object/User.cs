namespace Model.Object
{
    using System.ComponentModel.DataAnnotations;
    using Model.Core;

    public class User : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string AccountName { get; set; }

        public string Email { get; set; }
    }
}