using System;
using System.Threading.Tasks;
using DataEFCore.Configurations;
using DataEFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataEFCore.Context
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<UserBook> UserBook { get; set; }
        public virtual DbSet<User> User { get; set; }      

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            new AuthorConfiguration(modelBuilder.Entity<Author>());
            new BookConfiguration(modelBuilder.Entity<Book>());
            new GenreConfiguration(modelBuilder.Entity<Genre>());
            new RoleConfiguration(modelBuilder.Entity<Role>());
            new UserBookConfiguration(modelBuilder.Entity<UserBook>());
            new UserConfiguration(modelBuilder.Entity<User>());

            modelBuilder.HasSequence("author_id_seq");

            modelBuilder.HasSequence("book_id_seq");

            modelBuilder.HasSequence("genre_id_seq");

            modelBuilder.HasSequence("role_id_seq");

            modelBuilder.HasSequence("user_id_seq");

            modelBuilder.HasSequence("userbook_id_seq");
        }
    }
}
