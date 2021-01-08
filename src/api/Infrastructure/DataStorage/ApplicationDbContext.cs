using System.Reflection;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataStorage
{
  public class ApplicationDbContext : DbContext, IApplicationDbContext
  {
    public DbSet<Article> Articles { get; set; }
    public DbSet<Tag> Tags { get; set; }
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
      base.OnModelCreating(modelBuilder);
    }
  }
}