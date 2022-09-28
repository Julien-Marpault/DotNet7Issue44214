namespace Graphene.Front.Client.Components;

public partial class Reinsurance : ComponentBase
{
    private readonly List<ReinsuranceItem> items = new();
    [Parameter] public RenderFragment ChildContent { get; set; }

    protected override void OnInitialized()
    {
        Console.WriteLine($"Reinsurance items : {items.Count}");
    }

    protected override Task OnInitializedAsync()
    {
        Console.WriteLine($"Reinsurance items : {items.Count}");
        return Task.CompletedTask;
    }

    public void AddItem(ReinsuranceItem item)
    {
        items.Add(item);
        Console.WriteLine("AddItem");
    }
}