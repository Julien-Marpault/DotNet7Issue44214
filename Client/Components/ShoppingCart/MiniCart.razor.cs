
using Graphene.Front.Client.ViewModels;

namespace Graphene.Front.Client.Components.ShoppingCart;

public partial class MiniCart : ComponentBase
{
    [CascadingParameter] private Cart Cart { get; set; }
    [Parameter] public EventCallback Hide { get; set; }

    protected override void OnInitialized()
    {
        Console.WriteLine("MiniCart Cart.OnChange");
    }

    private void Cart_OnChange(string arg1, object arg2)
    {
        StateHasChanged();
    }

    public void RemoveEntry(DocumentEntry entry)
    { }
}