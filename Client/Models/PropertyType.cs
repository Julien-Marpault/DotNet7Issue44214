using System.ComponentModel.DataAnnotations;

namespace Graphene.Front.Client.Models;

public class PropertyType
{
    [StringLength(50)]
    public string Id { get; set; }

    public bool IsFilterable { get; set; }

    public bool IsVariant { get; set; }

    public InputType InputType { get; set; }
}
