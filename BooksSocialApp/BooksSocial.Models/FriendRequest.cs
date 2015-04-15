using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSocial.Models
{
    public class FriendRequest
    {
        public FriendRequest()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public virtual User Sender { get; set; }

        public virtual User Receiver { get; set; }
    }
}
