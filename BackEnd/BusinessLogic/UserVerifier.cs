namespace BusinessLogic
{
    using Model.Core;
    using Model.Object;
    using Model.Result;

    public class UserVerifier : IUserVerifier
    {
        public IUserRepository<User> Repository { get; set; }

        public IResult<User> Authentication(string accountName)
        {
            IResult<User> result = new ResultUser();
            result.Success = false;
            if (this.Repository != null)
            {
                if (!string.IsNullOrEmpty(accountName))
                {
                    var user = this.Repository.GetUserByAccountName(accountName);

                    if (user != null)
                    {
                        result.Success = true;
                        result.Data = user;
                        result.Message = "Successful sign in";
                    }
                    else
                    {
                        result.Message = "User not found";
                    }
                }
                else
                {
                    result.Message = "The account name must not be empty";
                }
            }
            else
            {
                result.Message = "It is not possible to access the data service";
            }

            return result;
        }
    }
}
