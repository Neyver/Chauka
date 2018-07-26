namespace Model.Result
{
    using Model.Object;

    public class ResultEvents : IResult<UserEvent>
    {
        public string Message { get; set; }

        public bool Success { get; set; }

        public UserEvent Data { get; set; }
    }
}
