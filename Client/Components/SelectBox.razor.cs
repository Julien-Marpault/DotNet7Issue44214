namespace Graphene.Front.Client.Components;

public partial class SelectBox : ComponentBase
{
    [Parameter] public RenderFragment DropDownArrow { get; set; }
    [Parameter] public string PropertyType { get; set; }
    [Parameter] public IEnumerable<ArticleProperty> Properties { get; set; }
    [Parameter] public EventCallback<(string, Guid)> OnSelect { get; set; }


    /// <summary>
    /// Propriété sélectionnée par défaut.
    /// Première propriété de la liste si non défini
    /// </summary>
    [Parameter] public Guid DefaultProperty { get; set; }

    private bool showOptions;

    protected override void OnInitialized()
    {
    }

    private async Task Select(Guid propertyValueId)
    {
        if (OnSelect.HasDelegate)
            await OnSelect.InvokeAsync((PropertyType, propertyValueId));
        showOptions = false;
    }
}