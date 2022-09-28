using Graphene.Front.Client.Models;
using System.ComponentModel.DataAnnotations;

namespace Graphene.Front.Client.ViewModels;

public class Article
{
    public int Id { get; init; }

    [StringLength(100)]
    public string Title { get; init; }
    
    [StringLength(100)]
    public string Slug { get; init; }

    public string Description { get; init; }

    public decimal Price { get; init; }

    public ICollection<Article>? Children { get; init; }

    public ICollection<ArticleProperty> Properties { get; init; } 

    public ICollection<BreadCrumbEntry> BreadCrumbEntries { get; init; }
    public ICollection<Visual> Visuals { get; init; }
}