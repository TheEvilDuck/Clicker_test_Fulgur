using System.Collections.Generic;

/// <summary>
/// Отвечает за хранение ресурсов и взаимодействие с ними, в последствии может быть интегрирован в какой-нибудь класс игрока.
/// </summary>
public class PlayerResourceStorage: IPlayerResourceStorage
{
    private Dictionary<ResourceType, PlayerResource> _resources;
    //При большом количестве ресурсов, возможно, есть смысл сумму хранить просто числом, а изменять в методе AddResource
    public int TotalAmount
    {
        get
        {
            int total = 0;

            foreach (var keyValuePair in _resources)
                total+=keyValuePair.Value.Value;

            return total;
        }
    }
    public PlayerResourceStorage()
    {
        _resources = new Dictionary<ResourceType, PlayerResource>();
    }

    public void RegisterResource(ResourceType resourceType, PlayerResource resource)
    {
        _resources.TryAdd(resourceType, resource);
    }
    public void AddResource(ResourceType resourceType, int amount)
    {
        if (_resources.TryGetValue(resourceType, out PlayerResource resource))
            resource.Add(amount);
    }

    public PlayerResource GetResourceOfType(ResourceType resourceType)
    {
        if (_resources.TryGetValue(resourceType, out PlayerResource resource))
            return resource;

        return null;
    }
}
