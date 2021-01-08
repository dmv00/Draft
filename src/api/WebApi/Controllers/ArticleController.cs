using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Articles.Commands.Create;
using Application.Articles.Commands.Delete;
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
    public async Task<Response<IEnumerable<ArticlesDto>>> Get()
    {
      return await Mediator.Send(new GetArticlesQuery());
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
    [HttpDelete("{articleId}")]
    public async Task<Response<int>> Delete([FromRoute]DeleteArticleCommand command)
    {
      return await Mediator.Send(command);
    }
  }
}