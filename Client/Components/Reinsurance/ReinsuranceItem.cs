namespace Graphene.Front.Client.Components;

public class ReinsuranceItem : ComponentBase
{
    [CascadingParameter] private Reinsurance Reinsurance { get; set; }
    [Parameter] public string Title { get; set; }
    [Parameter] public RenderFragment ChildContent { get; set; }

    protected override Task OnInitializedAsync()
    {
        Console.WriteLine("ReinsuranceItem");
        if (Reinsurance == null)
            throw new ArgumentNullException($"A 'ReinsuranceItem' must be a child of a 'Reinsurance' component");

        Reinsurance.AddItem(this);

        return Task.CompletedTask;
    }
}