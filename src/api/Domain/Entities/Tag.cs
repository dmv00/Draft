using System.Collections.Generic;

namespace Domain.Entities
{
  public class Tag
  {
    public int Id { get; set; }
    public string Content { get; set; }
    public string HexColor { get; set; }
    public IEnumerable<Article> Articles { get; set; }
  }
}