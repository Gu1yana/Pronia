using Microsoft.EntityFrameworkCore;
using MVClassromTask.Models;

namespace MVClassromTask.Contexts;

public class ProniaDbContext:DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=WIN-G1CGFOVK2JI\\SQLEXPRESS; Database=PRONIA; Trusted_Connection=true; TrustServerCertificate=true;");
        base.OnConfiguring(optionsBuilder); 
    }
    public DbSet<Service>Services {  get; set; }     
}

