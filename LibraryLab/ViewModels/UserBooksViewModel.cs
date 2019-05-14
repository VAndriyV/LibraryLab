using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryLab.ViewModels
{
    public class UserBooksViewModel
    {
        public User User { get; set; }
        public Dictionary<Book, int> Books = new Dictionary<Book, int>();
    }
}
