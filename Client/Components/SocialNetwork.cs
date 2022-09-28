namespace Graphene.Front.Client.Components;

public class SocialNetwork : ComponentBase
{
    [CascadingParameter] public SocialNetworks Parent { get; set; }
    [Parameter] public string Name { get; set; }
    [Parameter] public string Link { get; set; }
    [Parameter] public RenderFragment ChildContent { get; set; }

    protected override void OnInitialized()
    {
        Parent.Networks.Add(this);
    }
}