namespace Cookbook.Domain.Extensions;

public class BsonCollectionAttribute : Attribute
{
	public string CollectionName { get; }
	public BsonCollectionAttribute(string collectionName)
	{
		CollectionName = collectionName;
	}
}
