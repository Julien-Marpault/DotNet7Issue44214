using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Graphene.Front.Client.ViewModels;

public abstract class DocumentBase 
{
    public DocumentBase()
    {
        ShippingFees = 6.99m;
    }

    protected List<DocumentEntry> entries = new();
    public Guid Id { get; set; }

    public IReadOnlyCollection<DocumentEntry> Entries { get => entries; }

    [StringLength(50)]
    public string? PaymentIntent { get; set; }

    public decimal ShippingFees { get; protected set; }
    public decimal Total { get => Entries.Sum(s => s.Quantity * s.UnitPrice) + ShippingFees; }

    public int EntriesCount { get => Entries.Select(e => e.Quantity).Sum(); }

    public virtual DocumentEntry Add(Article article, int quantity)
    {
        DocumentEntry? entry = Entries.FirstOrDefault(entry => entry.ArticleId == article.Id);
        if (entry == null)
        {
            entry = new DocumentEntry(article, article.Id, Id, quantity);
            entries.Add(entry);
        }
        else
            entry.Add(1);
        Console.WriteLine($"Add(Article article, int {quantity})");
        return entry;
    }

    public virtual DocumentEntry SetQuantity(Article article, int quantity)
    {
        DocumentEntry? entry = Entries.FirstOrDefault(e => e.ArticleId == article.Id);
        if (entry == null)
            return null;
        entry.SetQuantity(quantity);
        Console.WriteLine("SetQuantity(Article article, int quantity)");
        return entry;
    }

    public virtual void SetQuantity(DocumentEntry entry, int quantity)
    {
        entry.SetQuantity(quantity);
        Console.WriteLine("SetQuantity(DocumentEntry entry, int quantity)");
    }

    public virtual void RemoveEntry(DocumentEntry entry)
    {
        entries.Remove(entry);
        Console.WriteLine("RemoveEntry(DocumentEntry entry)");
    }
}
