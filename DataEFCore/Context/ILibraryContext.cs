using DataEFCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataEFCore.Context
{
    public interface ILibraryContext
    {
         DbSet<Author> Author { get; set; }
         DbSet<Book> Book { get; set; }
         DbSet<Genre> Genre { get; set; }
         DbSet<Role> Role { get; set; }
         DbSet<Userbook> Userbook { get; set; }
         DbSet<User> User { get; set; }
         Task SaveChangesAsync();
    }
}
