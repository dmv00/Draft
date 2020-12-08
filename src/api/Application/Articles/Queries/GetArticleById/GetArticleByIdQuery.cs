using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Articles.Queries.GetArticleById
{
  public class GetArticleByIdQuery : IRequestWrapper<ArticleByIdDto>
  {
    public int ArticleId { get; set; }
  }

  public class GetArticleByIdQueryHandler : IHandlerWrapper<GetArticleByIdQuery, ArticleByIdDto>
  {
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetArticleByIdQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task<Response<ArticleByIdDto>> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
    {
      var article = await _context.Articles.FirstOrDefaultAsync(a => a.Id == request.ArticleId,
        cancellationToken: cancellationToken);

      if (article is null)
      {
        throw new NotFoundException(nameof(Article), request.ArticleId);
      }

      var dto = _mapper.Map<Article, ArticleByIdDto>(article);

      return Response.Ok(dto, string.Empty);
    }
  }
}