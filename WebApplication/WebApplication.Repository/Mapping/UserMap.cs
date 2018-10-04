using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApplication.Models.Models;

namespace WebApplication.Repository.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(t => t.UserID);

            builder.ToTable("TB_User", "dbo");

            builder.Property(t => t.UserID).HasColumnName("Id");

            builder.Property(t => t.Email).HasColumnName("email").HasMaxLength(150).IsRequired();

            builder.Property(t => t.Password).HasColumnName("password").HasMaxLength(150).IsRequired();

            builder.Property(t => t.Active).HasColumnName("active").HasDefaultValue(true);

        }
    }
}
