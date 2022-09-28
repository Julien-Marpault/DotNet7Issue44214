using Graphene.Front.Client.Components;
using Graphene.Front.Client.ViewModels;

namespace Graphene.Front.Client.Pages.Catalogue;

public partial class Category : ComponentBase
{
    private HttpClient _httpClient;
    [Inject] private IHttpClientFactory HttpClientFactory { get; set; }

    [Parameter] public string Slug { get; set; }

    private CategoryViewModel viewModel;

    //private Article[] articles = Array.Empty<Article>();
    private bool isLoading = true;

    private ArticleThumbnailOptions options;

    protected override async Task OnInitializedAsync()
    {
      
    }
}