using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Articles.Common
{
  public class TagDto
    : IMapFrom<Tag>
  {
    public string Content { get; set; }
    public string HexColor { get; set; }
  }
}