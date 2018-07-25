namespace Model.Result
{
    using Model.Core;

    public class ResultEntity<T> : IResult<T>
        where T : class, IEntity
    {
        public string Message { get; set; }

        public bool Success { get; set; }

        public T Data { get; set; }
    }
}
