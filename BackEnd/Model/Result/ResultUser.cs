namespace Model.Result
{
    using Model.Object;

    public class ResultUser : IResult<User>
    {
        public string Message { get; set; }

        public bool Success { get; set; }

        public User Data { get; set; }
    }
}
