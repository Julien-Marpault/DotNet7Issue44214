using System.Text.Json.Serialization;

namespace Graphene.Front.Client.Components.Navigation;

public class BreadCrumbItem
{
    [JsonPropertyName("@id")]
    public string Id { get; set; } = default!;

    [JsonPropertyName("name")]
    public string Name { get; set; } = default!;
}