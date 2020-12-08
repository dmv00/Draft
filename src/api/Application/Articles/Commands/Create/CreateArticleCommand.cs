using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Entities;

namespace Application.Articles.Commands.Create
{
  public class CreateArticleCommand : IRequestWrapper<int>
  {
    public string Title { get; set; }
    public string Content { get; set; }
  }

  public class CreateArticleCommandHandler : IHandlerWrapper<CreateArticleCommand, int>
  {
    private readonly IApplicationDbContext _context;

    public CreateArticleCommandHandler(IApplicationDbContext context)
    {
      _context = context;
    }

    public async Task<Response<int>> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
    {
      var article = new Article()
      {
        Title = request.Title,
        Content = request.Content,
        Created = DateTime.Now
      };
      await _context.Articles.AddAsync(article);

      await _context.SaveChangesAsync(cancellationToken);

      return Response.Ok(article.Id, "Article created");
    }
  }
}