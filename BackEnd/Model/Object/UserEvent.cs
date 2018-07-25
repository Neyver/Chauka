using Model.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Object
{
    public class UserEvent : IEntity
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public IEnumerable<Event> Events { get; set; }
    }
}
