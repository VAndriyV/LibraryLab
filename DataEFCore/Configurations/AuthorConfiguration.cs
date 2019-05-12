using DataEFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataEFCore.Configurations
{
    public class AuthorConfiguration
    {
        public AuthorConfiguration(EntityTypeBuilder<Author> entity)
        {
            entity.ToTable("author");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasColumnName("first_name")
                .HasMaxLength(30);

            entity.Property(e => e.LastName)
                .HasColumnName("last_name")
                .HasMaxLength(30);
        }
    }
}
