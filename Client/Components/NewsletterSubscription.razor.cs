using System.Text;

namespace Graphene.Front.Client.Components;

public partial class NewsletterSubscription : ComponentBase
{
    [Inject] private IHttpClientFactory HttpClientFactory { get; set; }

    private string email;
    private HttpClient httpClient;

    protected override void OnInitialized()
    {
        httpClient = HttpClientFactory.CreateClient(Constants.NotAuthenticatedHttpClient);
    }

    private  Task Suscribe()
    {
      return Task.CompletedTask;
    }
}