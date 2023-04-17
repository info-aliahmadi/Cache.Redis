using Cache.Redis.Data.Config;
using Cache.Redis.Data.Domain;
using Microsoft.EntityFrameworkCore;


namespace Cache.Redis.Data
{
    /// <summary>
    /// 
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Cms Builder

            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ContentConfiguration());

            #endregion


        }


        #region Cms DbSet

        public DbSet<Author> Author { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Content> Content { get; set; }

        #endregion

    }
}
