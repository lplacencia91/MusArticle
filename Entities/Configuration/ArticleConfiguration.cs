using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData
            (
            new Article
            {
                Id = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                Name = "David Statue",
                State = "OK",
                AssociatedMuseumId = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870")
            }
            );
        }
    }
}
