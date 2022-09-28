namespace Graphene.Front.Client.ViewModels;

public class VisualThumbnailViewModel
{
    private VisualThumbnailViewModel(string fileName, int width, int height)
    {
        FileName = fileName;
        Width = width;
        Height = height;
    }

    public string FileName { get; }
    public int Width { get; }
    public int Height { get; }

   
}
