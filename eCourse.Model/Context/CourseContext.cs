using eCourse.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace eCourse.Database.Context
{
    public class CourseContext:DbContext
    {
        public CourseContext(DbContextOptions<CourseContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUserRole>()
                .HasKey(e => new { e.ApplicationUserId, e.RoleId });
            modelBuilder.Entity<KursTag>()
                .HasKey(e => new { e.KursId, e.TagId});
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ApplicationUserRole> ApplicationUserRole { get; set; }
        public DbSet<Cas> Cas { get; set; }
        public DbSet<Clanarina> Clanarina { get; set; }
        public DbSet<Ispit> Ispit { get; set; }
        public DbSet<IspitKlijentKursInstanca> IspitKlijentKursInstanca { get; set; }
        public DbSet<Klijent> Klijent { get; set; }
        public DbSet<KlijentKursInstanca> KlijentKursInstanca { get; set; }
        public DbSet<Kurs> Kurs { get; set; }
        public DbSet<KursInstanca> KursInstanca { get; set; }
        public DbSet<KursTag> KursTag { get; set; }
        public DbSet<Opcina> Opcina { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<TipUplate> TipUplate { get; set; }
        public DbSet<Uplata> Uplata { get; set; }
        public DbSet<Uposlenik> Uposlenik { get; set; }
    }
}
