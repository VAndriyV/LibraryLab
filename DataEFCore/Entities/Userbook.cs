using System;
using System.Collections.Generic;

namespace DataEFCore.Entities
{
    public partial class Userbook
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public long BookId { get; set; }
        public int Count { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
