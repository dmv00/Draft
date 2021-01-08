using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
  public interface IApplicationDbContext
  {
    public DbSet<Article> Articles { get; set; }
    public DbSet<Tag> Tags { get; set; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
  }
}