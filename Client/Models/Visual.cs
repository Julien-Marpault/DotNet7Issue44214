using System.Text.Json.Serialization;

namespace Graphene.Front.Client.Models;

public class Visual 
{
    public Guid Id { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public VisualFormat Format { get; set; }
}
