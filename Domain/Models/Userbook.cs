using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Userbook
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long BookId { get; set; }
        public int Count { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
