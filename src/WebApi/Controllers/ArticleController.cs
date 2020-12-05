using System.Threading.Tasks;
using Application.Articles.Queries;
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
  }
}