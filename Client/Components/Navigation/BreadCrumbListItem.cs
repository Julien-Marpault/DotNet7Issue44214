using System.Text.Json.Serialization;

namespace Graphene.Front.Client.Components.Navigation
{
    public class BreadCrumbListItem
    {
        [JsonPropertyName("@type")]
        public string Type => "ListItem";

        [JsonPropertyName("position")]
        public int Position { get; set; }

        [JsonPropertyName("item")]
        public BreadCrumbItem Item { get; set; }
    }
}