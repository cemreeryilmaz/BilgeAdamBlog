using BlogProject.CORE.Map;
using BlogProject.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.MODEL.Maps
{
    public class CategoryMap : CoreMap<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
            builder.Property(x => x.CategoryName).HasMaxLength(100).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(500).IsRequired(true);

            // Silmiyoruz.
            base.Configure(builder);
        }
    }
}
