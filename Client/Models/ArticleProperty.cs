using System.ComponentModel.DataAnnotations;

namespace Graphene.Front.Client.Models;

public class ArticleProperty
{
    public int ArticleId { get; set; }

    [StringLength(50)]
    public string PropertyTypeId { get; set; }

    public PropertyType PropertyType { get; set; }

    public Guid PropertyValueId { get; set; }

    public PropertyValue PropertyValue { get; set; }

    /// <summary>
    /// Ordre de tri de la propriété
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// Colueur pour les icones
    /// </summary>
    //[StringLength(21)]
    //public string Color { get; set; }
}
