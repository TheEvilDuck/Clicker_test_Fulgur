using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Этот класс в какой-то степени является медиатором между объектами, отображающими ресурсы, и самими ресурсами.
/// Но также нужен для настройки этих самых объектов:
/// в инспекторе в списке создается конфиг, прокидывается объект и указывается, изменение какого ресурса
/// будет отслеживать обьъект. Так как это монобех, то для инициализации нужно вызвать метод Init, в котором автоматически создадутся
/// все зависимости отображения от изменения модели.
/// </summary>
public class ResourceWatchers: MonoBehaviour
{
    [SerializeField] private List<Config> _configs;
    [SerializeField] private ResourceWatcher _totalText;

    private ResourcesConfig _resourcesConfig;
    private IPlayerResourceStorage _playerStats;

    public void Init(ResourcesConfig resourcesConfig, IPlayerResourceStorage playerStats)
    {
        _resourcesConfig = resourcesConfig;
        _playerStats = playerStats;

        foreach (ResourcesConfigElement resourceConfig in _resourcesConfig.Resources)
        {
            Config config = _configs.Find((x) => resourceConfig.resourceType==x.resourceType);

            if (config!=null)
            {
                config.resourceWatcher.Init(resourceConfig.name);
                PlayerResource playerResource = _playerStats.GetResourceOfType(resourceConfig.resourceType);

                if (playerResource == null)
                    continue;
                
                playerResource.changed+=config.resourceWatcher.UpdateCount;
                playerResource.changed+=OnAnyResourceChanged;
                config.resourceWatcher.UpdateCount(playerResource.Value);
            }
        }

        _totalText.Init(resourcesConfig.TotalText);
        _totalText.UpdateCount(_playerStats.TotalAmount);
    }

    private void OnAnyResourceChanged(int amount) => _totalText.UpdateCount(_playerStats.TotalAmount);

    private void OnDestroy() 
    {
        foreach (ResourcesConfigElement resourceConfig in _resourcesConfig.Resources)
        {
            Config config = _configs.Find((x) => resourceConfig.resourceType==x.resourceType);

            if (config!=null)
            {
                PlayerResource playerResource = _playerStats.GetResourceOfType(resourceConfig.resourceType);

                if (playerResource == null)
                    continue;

                playerResource.changed-=config.resourceWatcher.UpdateCount;
                playerResource.changed-=OnAnyResourceChanged;
            }
        }
    }

    [Serializable]
    private class Config
    {
        public ResourceWatcher resourceWatcher;
        public ResourceType resourceType;
    }
}