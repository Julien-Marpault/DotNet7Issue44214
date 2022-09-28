using Graphene.Front.Client.ViewModels;
using Microsoft.JSInterop;

namespace Graphene.Front.Client.Components.ShoppingCart;

public partial class CartContainer : ComponentBase, IDisposable
{
    private bool disposedValue;

    [Parameter] public RenderFragment ChildContent { get; set; }

    //[Inject] private HttpClient HttpClient { get; set; }
    [Inject] private IHttpClientFactory HttpClientFactory { get; set; }

    [Inject] private IJSRuntime JS { get; set; }
    private HttpClient _httpClient;
    public Cart Cart { get; private set; }

    protected override async Task OnInitializedAsync()
    {
        _httpClient = HttpClientFactory.CreateClient("NotAuthenticated");
        string? cartId = await JS.InvokeAsync<string?>("localStorage.getItem", "Cart");
        Console.WriteLine($"Cart : {cartId}");

        Guid cartGuid;

        if (!string.IsNullOrEmpty(cartId))
        {
            cartGuid = Guid.Parse(cartId);
        }
        else
        {
            cartGuid = Guid.Empty;
        }

     
    }

    private async Task Cart_OnChangeAsync(string command, object entity)
    {
        switch (command)
        {
            case "SetAddress":
                Console.WriteLine("Cart_OnChangeAsync SetAddress Start");
                await SetAddress(entity);
                Console.WriteLine("Cart_OnChangeAsync SetAddress Stop");
                break;

            default:
                break;
        }
    }

    private async void Cart_OnChange(string command, object entity)
    {
        switch (command)
        {
            case "AddArticle":
                await AddArticleToCart((DocumentEntry)entity);
                break;

            case "SetQuantity":
                await _httpClient.PutAsJsonAsync($"/api/cart/article", entity);
                break;

            case "RemoveEntry":
                await _httpClient.DeleteAsync($"/api/cart/article/{((DocumentEntry)entity).Id}");
                break;

            case "SetAddress":
                Console.WriteLine("Cart_OnChange SetAddress Start");
                await SetAddress(entity);
                Console.WriteLine("Cart_OnChange SetAddress Stop");
                break;

            default:
                break;
        }
    }

    private async Task SetAddress(object entity)
    {
        HttpClient _authenticatedHttpClient = HttpClientFactory.CreateClient("Authenticated");
        Console.WriteLine("Cart_OnChange PostAsJsonAsync");
        HttpResponseMessage response = await _authenticatedHttpClient.PostAsJsonAsync($"/api/cart/address", entity);
        response.EnsureSuccessStatusCode();
        Guid id = JsonSerializer.Deserialize<Guid>(await response.Content.ReadAsStringAsync());
    }

    private  Task AddArticleToCart(DocumentEntry entity)
    {
      return Task.CompletedTask;    
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                // TODO: dispose managed state (managed objects)
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            disposedValue = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~CartContainer()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}