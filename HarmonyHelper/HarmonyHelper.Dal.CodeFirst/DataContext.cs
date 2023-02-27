using Eric.Morrison.Harmony;
using Eric.Morrison.Harmony.Chords;
using Eric.Morrison.Harmony.Intervals;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region NoteName
            {
                var count = NoteName.Catalog.Count();
                var nns = NoteName.Catalog.ToList();
                for (int i = 1; i < count; ++i)
                {
                    var nn = nns[i];
                    nn.Id = i;
                    modelBuilder.Entity<NoteName>()
                        .HasData(nn);
                }
            }
            #endregion

            //#region KeySignatures
            //{
            //    //modelBuilder.Entity<KeySignature>()
            //    //    .Ignore(c => c.Keys);

            //    var count = KeySignature.Catalog.Count();
            //    var list = KeySignature.Catalog.ToList();
            //    for (int i = 1; i < count; ++i)
            //    {
            //        var item = list[i];
            //        item.Id = i;
            //        modelBuilder
            //            .Entity<KeySignature>()
            //            .HasData(item);
            //    }
            //}
            //#endregion

            #region Interval
            {
                modelBuilder.Entity<Interval>();

                var count = Interval.Catalog.Count();
                var list = Interval.Catalog.ToList();
                for (int i = 1; i < count; ++i)
                {
                    var item = list[i];
                    item.Id = i;
                    modelBuilder
                        .Entity<Interval>()
                        .HasData(item);
                }
            }
            #endregion

            #region ChordType
            {
                //modelBuilder.Entity<ChordType>()
                //    .Ignore(c => c.Key);

                var count = ChordType.Catalog.Count();
                var list = ChordType.Catalog.ToList();
                for (int i = 1; i < count; ++i)
                {
                    var item = list[i];
                    item.Id = i;
                    modelBuilder
                        .Entity<ChordType>()
                        .HasData(item);
                }
            }
            #endregion

            #region ChordFormula
            {
                modelBuilder.Entity<ChordFormula>()
                    .Ignore(c => c.Keys);

                var count = ChordFormula.Catalog.Count();
                var list = ChordFormula.Catalog.ToList();
                for (int i = 1; i < count; ++i)
                {
                    var item = list[i];
                    item.Id = i;
                    modelBuilder
                        .Entity<ChordFormula>()
                        .HasData(item);
                }
            }
            #endregion

        }

        public DbSet<NoteName> NoteNames { get; set; }
        public DbSet<Interval> Intervals { get; set; }
        public DbSet<ChordType> ChordTypes { get; set; }
        public DbSet<ChordFormula> ChordFormulas { get; set; }
        //public DbSet<KeySignature> KeySignatures { get; set; }
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