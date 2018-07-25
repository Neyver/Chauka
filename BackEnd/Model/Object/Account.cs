namespace Model.Object
{
    using Model.Core;

    public class Account : IEntity
    {
        public int Id { get; set; }

        public string AccountName { get; set; }
    }
}
