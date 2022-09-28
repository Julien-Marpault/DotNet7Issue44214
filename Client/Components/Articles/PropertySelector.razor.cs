namespace Graphene.Front.Client.Components.Articles;

public partial class PropertySelector : ComponentBase
{
    [Parameter] public Dictionary<string, Guid> SelectedProperties { get; set; }
    [Parameter] public IGrouping<string, ArticleProperty> Properties { get; set; }
    [Parameter] public EventCallback OnPropertyChange { get; set; }
    protected PropertyType propertyType;

    protected override void OnInitialized()
    {
        if (SelectedProperties == null)
            throw new ArgumentNullException(nameof(SelectedProperties));
        propertyType = Properties.First().PropertyType;
    }

    protected void SelectProperty(ChangeEventArgs e)
    {
        Console.WriteLine($"SelectProperty : {e.Value}");
    }

    private async Task PropertyChanged((string Type, Guid Value) property)
    {
        Console.WriteLine($"PropertyChanged : {property.Type} {property.Value}");
        SelectedProperties[property.Type] = property.Value;
        if (OnPropertyChange.HasDelegate)
            await OnPropertyChange.InvokeAsync();
    }
}