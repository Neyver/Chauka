namespace BusinessLogic
{
    using System;
    using DataAccess;
    using Model.Core;
    using Model.Object;
    using Model.Result;

    public class UserAuthenticator : IUserAuthenticator
    {
        public IUserRepository<User> Repository { get; set; } = new UserRepository();

        public IResult<Account> Authentication(string accountName)
        {
            IResult<Account> result = new ResultEntity<Account>();
            result.Success = false;
            if (this.Repository != null)
            {
                if (!string.IsNullOrEmpty(accountName))
                {
                    var user = this.Repository.GetUserByAccountName(accountName);

                    if (user != null)
                    {
                        result.Success = true;
                        result.Data = new Account() { Id = user.Id, Name = user.Name };
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
