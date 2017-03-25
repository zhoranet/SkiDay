using System.Data.Entity;
using SkiDay.WebApp.Models;

namespace SkiDay.WebApp
{
    public class SkiDayContext : DbContext
    {
        public SkiDayContext() : base("SkiDayContext")
        {
        }

        public virtual DbSet<SkiResort> SkiResorts { get; set; }
        public virtual DbSet<MySkiDay> SkiDays { get; set; }
    }
}