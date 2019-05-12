using DataEFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataEFCore.Configurations
{
    public class BookConfiguration
    {
        public BookConfiguration(EntityTypeBuilder<Book> entity)
        {
            entity.ToTable("book");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.AuthorId).HasColumnName("author_id");

            entity.Property(e => e.AvailableCount).HasColumnName("available_count");

            entity.Property(e => e.GenreId).HasColumnName("genre_id");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasColumnName("title")
                .HasMaxLength(40);

            entity.Property(e => e.TotalCount).HasColumnName("total_count");

            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Author)
                .WithMany(p => p.Book)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("author_FK");

            entity.HasOne(d => d.Genre)
                .WithMany(p => p.Book)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("genre_FK");
        }
    }
}
