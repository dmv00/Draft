using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;
using MediatR;

namespace Application.Articles.Commands.Delete
{
  public class DeleteArticleCommand : IRequestWrapper<int>
  {
    public int ArticleId { get; set; }
  }
  public class DeleteArticleCommandHandler : IHandlerWrapper<DeleteArticleCommand,int>
  {
    private readonly IApplicationDbContext _context;

    public DeleteArticleCommandHandler(IApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<Response<int>> Handle(DeleteArticleCommand request, CancellationToken cancellationToken)
    {
      var article = await _context.Articles.FindAsync(request.ArticleId);
      if (article is null)
      {
        throw new NotFoundException(nameof(Article), request.ArticleId);
      }

      _context.Articles.Remove(article);
      await _context.SaveChangesAsync(cancellationToken);
      
      return Response.Ok<int>(article.Id, "Article deleted");
    }
  }
}