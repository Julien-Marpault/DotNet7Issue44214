using System.ComponentModel.DataAnnotations;

namespace Graphene.Front.Client.Models;

public class PropertyValue
{
    public Guid Id { get; set; }

    [StringLength(4000)]
    public string Value { get; set; }

    [StringLength(50)]
    public string PropertyTypeId { get; set; }

    [StringLength(4000)]
    public string? MetaData { get; set; }
}
