using System.Text.Json.Serialization;

namespace Graphene.Front.Client.ViewModels;

public class DocumentEntry
{
    public DocumentEntry()
    {
    }

    public DocumentEntry(int articleId, Guid cartId, int quantity)
    {
        ArticleId = articleId;
        DocumentId = cartId;
        Quantity = quantity;
    }

    public DocumentEntry(Article article, int articleId, Guid cartId, int quantity)
    {
        //Article = article;
        ArticleId = articleId;
        DocumentId = cartId;
        Quantity = quantity;
    }

  

    private int _quantity;

    public Guid Id { get; set; }

    public int ArticleId { get; set; }

    public decimal UnitPrice { get; set; }
    //public Article? Article { get; set; }

    public int Quantity
    { get { return _quantity; } protected set { _quantity = value; } }

    public Guid DocumentId { get; set; }

    [JsonIgnore]
    public DocumentBase Document { get; set; }

    public void Add(int quantity)
        => _quantity += quantity;

    public void Remove(int quantity)
        => _quantity -= quantity;

    public void SetQuantity(int quantity)
        => _quantity = quantity;

   
}
