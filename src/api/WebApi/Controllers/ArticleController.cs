using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Articles.Commands.Create;
using Application.Articles.Commands.Update;
using Application.Articles.Queries.GetAllArticles;
using Application.Articles.Queries.GetArticleById;
using Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
  public class ArticleController : ApiController
  {
    [HttpGet("{articleId}")]
    public async Task<Response<ArticleByIdDto>> Get([FromRoute]GetArticleByIdQuery query)
    {
      return await Mediator.Send(query);
    }

    [HttpGet]
    public async Task<Response<IEnumerable<ArticlesDto>>> Get(GetArticlesQuery query)
    {
      return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<Response<int>> Create(CreateArticleCommand command)
    {
      return await Mediator.Send(command);
    }

    [HttpPut]
    public async Task<Response<int>> Update(UpdateArticleCommand command)
    {
      return await Mediator.Send(command);
    }
  }
}