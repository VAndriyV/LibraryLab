﻿using System;
using System.Collections.Generic;

namespace DataEFCore.Entities
{
    public partial class User
    {
        public User()
        {
            Userbook = new HashSet<Userbook>();
        }

        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public long RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Userbook> Userbook { get; set; }
    }
}
