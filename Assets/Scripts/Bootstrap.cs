using UnityEngine;

/// <summary>
/// Точка входа проекта
/// </summary>
public class Bootstrap : MonoBehaviour
{
    [SerializeField] private ResourcesConfig _resourcesConfig;
    [SerializeField] private ResourceButtons _resourceButtons;
    [SerializeField] private ResourceWatchers _resourceWatchers;
    private PlayerResourceStorage _playerStats;
    private void Awake() 
    {
        _playerStats = new PlayerResourceStorage();

        foreach (ResourcesConfigElement resourceConfig in _resourcesConfig.Resources)
        {
            if (resourceConfig.resourceType == ResourceType.None)
            {
                Debug.LogWarning($"There is resource config element with None resource type, it will be ignored. Name: {resourceConfig.name}");
                continue;
            }

            _playerStats.RegisterResource(resourceConfig.resourceType, new PlayerResource(resourceConfig.defaultValue));
        }

        _resourceWatchers.Init(_resourcesConfig, _playerStats);
        _resourceButtons.Init(_playerStats);
    }
}
