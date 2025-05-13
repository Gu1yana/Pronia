using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MVClassromTask.Models;
using MVClassromTask.Models.LoginAndRegister;

namespace MVClassromTask.Contexts;

public class ProniaDbContext:IdentityDbContext<AppUser, IdentityRole<Guid>,Guid>
{
    public ProniaDbContext(DbContextOptions options) : base(options)
    {
    }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer("Server=DESKTOP-0892D4J\\SQLEXPRESS; Database=PRONIA; Trusted_Connection=true; TrustServerCertificate=true;");
    //    base.OnConfiguring(optionsBuilder);
    //}
    public DbSet<Service> Services { get; set; }
    public DbSet<Slider> Sliders { get; set; }
}

