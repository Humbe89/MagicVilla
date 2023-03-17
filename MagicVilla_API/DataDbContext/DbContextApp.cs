using MagicVilla_API.Models;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.DataDbContext
{
    public class DbContextApp: DbContext
    {

        public DbContextApp(DbContextOptions<DbContextApp> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Villa>().HasData(
                 new Villa()
                 {
                     Id = 1,
                     Name = "Villa real",
                     Amenidad = "",
                     Details = "details",
                     Email = "real@gmail.com",
                     imageUrl = "",
                     MetrosCuadrados = 3,
                     Ocupantes = 4,


                 },
                 new Villa()
                 {
                     Id = 2,
                     Name = "Villa pla",
                     Amenidad = "",
                     Details = "details",
                     Email = "playa@gmail.com",
                     imageUrl = "",
                     MetrosCuadrados = 3,
                     Ocupantes = 4,

                 }
                );
        }

        public DbSet<Villa> Villas { get; set; }
    }
}
