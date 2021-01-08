using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Articles.Common;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Articles.Commands.Create
{
  public class CreateArticleCommand : IRequestWrapper<int>
  {
    public string Title { get; set; }
    public string Content { get; set; }
    public IEnumerable<string> Tags { get; set; }
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
        Created = DateTime.Now,
        Updated = DateTime.Now,
      };
      var tags = await _context.Tags.Where(t => request.Tags.Contains(t.Content)).ToArrayAsync();
      
      article.Tags = tags;
      
      await _context.Articles.AddAsync(article);

      await _context.SaveChangesAsync(cancellationToken);

      return Response.Ok(article.Id, "Article created");
    }
  }
}