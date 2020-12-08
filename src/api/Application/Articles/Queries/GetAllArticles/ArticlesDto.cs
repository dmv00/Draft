using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Articles.Queries.GetAllArticles
{
  public class ArticlesDto
    : IMapFrom<Article>
  {
    public int Id { get; set; }
    public string Title { get; set; }
  }
}