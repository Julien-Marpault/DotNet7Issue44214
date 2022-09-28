
using Graphene.Front.Client.Models;
using Graphene.Front.Client.ViewModels;

namespace Graphene.Front.Client.Pages.Catalogue;

public partial class Product : ComponentBase
{
    [CascadingParameter] private Cart Cart { get; set; }
    [Parameter] public string? Category { get; set; }
    [Parameter] public string? Slug { get; set; }
    [Inject] private IHttpClientFactory HttpClientFactory { get; set; }
    private HttpClient _httpClient;
    private Article articleGroup = default!;
    private Article article = default!;
    private bool isLoading = true;
    private IEnumerable<IGrouping<string, ArticleProperty>> propertyGroups;
    private Dictionary<string, Guid> selectedProperties = new();

    protected override async Task OnInitializedAsync()
    {
        _httpClient = HttpClientFactory.CreateClient("NotAuthenticated");

        articleGroup = await _httpClient.GetFromJsonAsync<Article>($"/api/articles/{Slug}");
        Console.WriteLine(JsonSerializer.Serialize(articleGroup, new JsonSerializerOptions { WriteIndented = true }));
        propertyGroups = articleGroup.Children?.SelectMany(s => s.Properties.Where(pr => pr.PropertyType.IsVariant == true)).GroupBy(group => group.PropertyTypeId);
        foreach (var group in propertyGroups)
        {
            //if (group.Any(s => s.PropertyType.IsVariant == true))
            //{
            selectedProperties.Add(group.Key, group.First().PropertyValueId);
            Console.WriteLine("Add Group");
            Console.WriteLine(JsonSerializer.Serialize(group, new JsonSerializerOptions { WriteIndented = true }));
            //}
        }
        SelectCurrentArticle();
        isLoading = false;
    }

    private void AddToCart()
    {
        Console.WriteLine("AddToCart()");
        Console.WriteLine($"Cart : {Cart.Id}");
        Cart.Add(article, 1);
    }

    private void SelectCurrentArticle()
    {
        article = articleGroup.Children
            .Where(child => child.Properties.Where(pr => pr.PropertyType.IsVariant == true)
            .All(prop => selectedProperties[prop.PropertyTypeId] == child.Properties.First(p => p.PropertyTypeId == prop.PropertyTypeId).PropertyValueId)).First();
        Console.WriteLine($"Current Article :{article.Id} {article.Title}");
    }

    private void UpdateActiveArticle()
    {
        Console.WriteLine("UpdateActiveArticle()");
        SelectCurrentArticle();
        StateHasChanged();
    }
}