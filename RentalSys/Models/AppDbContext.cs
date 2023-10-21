using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RentalSys.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {

        }

        public DbSet<AdminModel> AdminModels { get; set; }
        public DbSet<UserModel> UserModels { get; set; }
        public DbSet<HouseBookingModel> HouseBookingModels { get; set; }
        public DbSet<HouseDetailModel> HouseDetailsModels { get; set; }

    }
}
