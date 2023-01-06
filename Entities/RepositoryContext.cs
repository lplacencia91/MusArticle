using Entities.Configuration;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options)
: base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MuseumConfiguration());
            modelBuilder.ApplyConfiguration(new ArticleConfiguration());
        }
        public DbSet<Museum> Museums { get; set; }
        public DbSet<Article> Articles { get; set; }
    }
}
