using Microsoft.EntityFrameworkCore;

namespace LinqPractises.DbOperations{
  public class LinqDbContext : DbContext
  {
    public DbSet<Student> Students { get; set; } // burasi aslında bir property

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseInMemoryDatabase(databaseName: "LinqDatabase");
    }

  }
}