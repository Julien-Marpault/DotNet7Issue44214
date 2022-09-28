namespace Graphene.Front.Client.ViewModels;

public class CategoryViewModel
{
    public ICollection<BreadCrumbEntry> BreadCrumbEntries { get; set; } = Array.Empty<BreadCrumbEntry>();

    public ICollection<ArticleThumbnailViewModel> Articles { get; set; } = Array.Empty<ArticleThumbnailViewModel>();

    public string? ShortDescription { get; set; }

    public string Title { get; set; }

    public string MetaDescription { get; set; }

  
}
