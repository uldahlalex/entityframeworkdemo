using Microsoft.EntityFrameworkCore;
using serversidevalidation;

public class MyDbContext : DbContext
{
    public DbSet<Pet> Pets { get; set; }

    public string DbPath { get; }

    public MyDbContext()
    {
     
        DbPath = System.IO.Path.Join("pets.db");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}