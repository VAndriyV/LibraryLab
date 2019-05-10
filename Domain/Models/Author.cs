using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Author
    {
        public Author()
        {
            Book = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
