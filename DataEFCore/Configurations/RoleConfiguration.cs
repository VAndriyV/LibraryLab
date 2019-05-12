using DataEFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataEFCore.Configurations
{
    public class RoleConfiguration
    {
        public RoleConfiguration(EntityTypeBuilder<Role> entity)
        {
            entity.ToTable("role");

            entity.Property(e => e.Id).HasColumnName("id");

            entity.Property(e => e.Name)
                .IsRequired()
                .HasColumnName("name")
                .HasMaxLength(30);
        }
    }
}
