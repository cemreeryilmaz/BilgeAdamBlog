using BlogProject.CORE.Map;
using BlogProject.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.MODEL.Maps
{
    public class PostMap : CoreMap<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.Property(x => x.Title).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.PostDetail).IsRequired(true);
            builder.Property(x => x.Tags).IsRequired(false); // TRUE olabilir
            builder.Property(x => x.ImagePath).IsRequired(false);

            // Silmiyoruz.
            base.Configure(builder);
        }
    }
}
