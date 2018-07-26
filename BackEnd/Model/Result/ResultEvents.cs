using Model.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Result
{
    public class ResultEvents : IResult<UserEvent>
    {
        public string Message { get; set; }

        public bool Success { get; set; }

        public UserEvent Data { get; set; }
    }
}
