using System;
using System.Collections.Generic;
using Application.Articles.Common;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Articles.Queries.GetArticleById
{
  public class ArticleByIdDto
    : IMapFrom<Article>
  {
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public IEnumerable<TagDto> Tags { get; set; }
  }
}