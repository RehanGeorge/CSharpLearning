// Data/ZooContext.cs
using System.Data.Entity;

public class ZooContext : DbContext
{
    public ZooContext() : base("name=ZooDbConnection") { }

    public DbSet<Animal> Animals { get; set; }
}