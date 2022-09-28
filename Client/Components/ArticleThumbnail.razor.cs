using Graphene.Front.Client.ViewModels;

namespace Graphene.Front.Client.Components;

public partial class ArticleThumbnail : ComponentBase
{
    [Parameter] public ArticleThumbnailViewModel Model { get; set; }
    [Parameter] public ArticleThumbnailOptions Options { get; set; }
    [Parameter] public string Category { get; set; }
    [Parameter] public RenderFragment? Caption { get; set; }

    [Parameter] public RenderFragment? AddToCartButton { get; set; }
    [Parameter] public RenderFragment? AddToWishlistButton { get; set; }
    [CascadingParameter] private Cart Cart { get; set; }


    protected override void OnInitialized()
    {
        Console.WriteLine($"Model : {Model}");
    }

    private void AddToCart()
    {
        //Cart.Add(Model, 1);
    }

    private static void AddToWishlist()
    {
        Console.WriteLine("AddToWishlist()");
    }
}