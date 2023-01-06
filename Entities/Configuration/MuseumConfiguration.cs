using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Configuration
{
    public class MuseumConfiguration : IEntityTypeConfiguration<Museum>
    {
        public void Configure(EntityTypeBuilder<Museum> builder)
{
builder.HasData
 (
 new Museum
 {
     Id = new Guid("c9d4c053-49b6-410c-bc78-2d54a9991870"),
     Name = "Bellas Artes",
     Theme = "History"
 }
);
}
}
}
