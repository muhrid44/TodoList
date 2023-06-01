using Microsoft.EntityFrameworkCore;
using UpscaleTest.Helper;

namespace UpscaleTest.Models
{
    public class MyDbContextModel : DbContext
    {
        public DbSet<TodoModel> TodoTable { get; set; }
        public DbSet<PriorityModel> PriorityTable { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(StaticHelper.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoModel>()
                .HasOne(b => b.PriorityModel)
                .WithMany(a => a.TodoModel)
                .HasForeignKey(b => b.PriorityId);
        }

    }
}
