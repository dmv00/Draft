using System;
using System.Collections.Generic;

namespace Domain.Entities
{
  public class Article
  {
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public IEnumerable<Tag> Tags { get; set; }
  }
}