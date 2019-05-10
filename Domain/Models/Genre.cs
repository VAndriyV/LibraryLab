using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Genre
    {
        public Genre()
        {
            Book = new HashSet<Book>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Book> Book { get; set; }
    }
}
