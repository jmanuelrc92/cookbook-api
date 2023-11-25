using MongoDB.Bson;

namespace Cookbook.Domain.Models.Persistance;

public abstract class Document : IDocument
{
    public ObjectId Id { get; set; }
    public DateTime CreatedAt => Id.CreationTime;
}
