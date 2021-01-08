using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Articles.Commands.Update
{
  public class UpdateArticleCommand : IRequestWrapper<int>
  {
    public int ArticleId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public IEnumerable<string> Tags { get; set; }
  }

  public class UpdateArticleCommandHandler : IHandlerWrapper<UpdateArticleCommand, int>
  {
    private readonly IApplicationDbContext _context;

    public UpdateArticleCommandHandler(IApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<Response<int>> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
    {
      var article = await _context.Articles.FindAsync(request.ArticleId);
      if (article is null)
      {
        throw new NotFoundException(nameof(Article), request.ArticleId);
      }

      var tags = await _context.Tags.Where(t => request.Tags.Contains(t.Content)).ToArrayAsync();

      article.Content = request.Content ?? article.Content;
      article.Title = request.Title ?? article.Title;
      article.Tags = tags;

      await _context.SaveChangesAsync(cancellationToken);

      return Response.Ok(article.Id, "Article updated successfully");
    }
  }
}