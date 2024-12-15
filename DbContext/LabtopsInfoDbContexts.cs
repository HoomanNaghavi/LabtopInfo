using LabtopInfo.Entitis;
using Microsoft.EntityFrameworkCore;


namespace LabtopInfo.DbContexts

{
    public class LabtopsInfoDbContexts : DbContext
    {
        public LabtopsInfoDbContexts(DbContextOptions<LabtopsInfoDbContexts> options) :
            base(options)
        {

        }
        public DbSet<Labtops> labtops { get; set; } = null!;

        public DbSet<LabtopCategoris> labtopCategoris { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Labtops>().HasData
                (new Labtops("Asus")
                {
                    Id = 1,
                    Description = "لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ"

                }
                );
            modelBuilder.Entity<LabtopCategoris>().HasData
            (new LabtopCategoris( name:"Rog")
                {
                Id = 1,
                laptopId = 1,
                Description = "This is a test... "

                }
            );


            base.OnModelCreating(modelBuilder);
        }
    }
}
