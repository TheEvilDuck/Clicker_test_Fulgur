public interface IPlayerResourceStorage
{
    int TotalAmount {get;}
    public void AddResource(ResourceType resourceType, int amount);
    public PlayerResource GetResourceOfType(ResourceType resourceType);
}