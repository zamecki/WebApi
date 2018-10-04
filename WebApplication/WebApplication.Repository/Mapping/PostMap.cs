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
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(t => t.PostID);

            builder.ToTable("TB_Post", "dbo");

            builder.Property(t => t.PostID).HasColumnName("Id");

            builder.Property(t => t.CreateTime).HasColumnName("createtime").IsRequired();

            builder.Property(t => t.Title).HasColumnName("title").HasMaxLength(50).IsRequired();

            builder.Property(t => t.Message).HasColumnName("message").HasMaxLength(256).IsRequired();

            builder.HasOne(t => t.User).WithMany(t => t.Posts).HasForeignKey(t => t.UserID);
        }
    }
}
