using Eric.Morrison.Harmony;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace HarmonyHelper.Dal.CodeFirst
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options) 
        { }

        public DbSet<NoteName> NoteNames { get; set; }
    }//class


    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlite("Data Source=HarmonyHelper.db");

            return new DataContext(optionsBuilder.Options);
        }
    }//class
}//ns