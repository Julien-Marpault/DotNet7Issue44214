namespace Graphene.Front.Client.ViewModels;

public record ArticleThumbnailViewModel
{
    private ArticleThumbnailViewModel(int id, decimal price, string title, string slug, VisualThumbnailViewModel visual)
    {
        Id = id;
        Price = price;
        Title = title;
        Slug = slug;
        Visual = visual;
    }
    public int Id { get; }
    public decimal Price { get; }
    public string Title { get; }
    public string Slug { get; }
    public VisualThumbnailViewModel Visual { get; set; }

}