using System;

namespace Domain.Entities
{
  public class Article
  {
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime Created { get; set; }
  }
}