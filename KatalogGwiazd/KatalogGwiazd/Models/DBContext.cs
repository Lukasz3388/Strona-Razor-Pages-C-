using Microsoft.EntityFrameworkCore;
namespace KatalogGwiazd
{
    public class DBContext :DbContext
    {
        public DbSet<UserModel> Star { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=database.db");
    }
}
//Add-Migration Nazwa
//update-database