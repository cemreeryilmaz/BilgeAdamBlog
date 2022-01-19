using BlogProject.CORE.Map;
using BlogProject.MODEL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.MODEL.Maps
{
    public class CommentMap : CoreMap<Comment>
    {
        public override void Configure(EntityTypeBuilder<Comment> builder)
        {

            builder.ToTable("Comments");
            builder.Property(x => x.CommentText).HasMaxLength(255).IsRequired(true);
            //builder.HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.UserID).OnDelete(deleteBehavior: DeleteBehavior.Restrict);

            // Silmiyoruz. Bunun sebebi de yukarıdaki ayarlarla beraber Base'deki (CoreMap.cs) ilgili metoda dönmesini sağlıyor. İlgili tablo oluşturulurken, Base'de ayarları da kullanarak oluştursun diyoruz.
            base.Configure(builder);
        }
    }
}
