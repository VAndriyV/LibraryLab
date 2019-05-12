using DataEFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataEFCore.Configurations
{
    public class UserConfiguration
    {
        public UserConfiguration(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("users");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("nextval('user_id_seq'::regclass)");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasColumnName("email")
                .HasMaxLength(255);

            entity.Property(e => e.Password)
                .IsRequired()
                .HasColumnName("password")
                .HasMaxLength(60);

            entity.Property(e => e.PhoneNumber)
                .IsRequired()
                .HasColumnName("phone_number")
                .HasMaxLength(20);

            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role)
                .WithMany(p => p.User)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("role_FK");
        }
    }
}
