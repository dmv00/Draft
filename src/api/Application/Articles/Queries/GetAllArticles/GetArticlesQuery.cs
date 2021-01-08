using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Articles.Queries.GetAllArticles
{
  public class GetArticlesQuery : IRequestWrapper<IEnumerable<ArticlesDto>>
  {
  }

  public class GetArticlesQueryHandler : IHandlerWrapper<GetArticlesQuery, IEnumerable<ArticlesDto>>
  {
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetArticlesQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public Task<Response<IEnumerable<ArticlesDto>>> Handle(GetArticlesQuery request,
      CancellationToken cancellationToken)
    {
      var articles = _context.Articles
        .Include(ar => ar.Tags)
        .ProjectTo<ArticlesDto>(_mapper.ConfigurationProvider)
        .AsEnumerable();

      return Response.OkFromTask(articles, string.Empty);
    }
  }
}