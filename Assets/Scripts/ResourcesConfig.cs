using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Это база данных, определяющая названия ресурсов и их дефолтные значения. В теории может быть заменена на класс для локализации и отдельный конфиг для
/// дефолтных значений.
/// </summary>
[CreateAssetMenu(menuName = "Configs", fileName = "Configs/New Resources config")]
public class ResourcesConfig : ScriptableObject
{
    [SerializeField] private List<ResourcesConfigElement> _resources;

    [field: SerializeField] public string TotalText;
    public IEnumerable<ResourcesConfigElement> Resources => _resources;

    public ResourcesConfigElement GetConfigOfType(ResourceType resourceType) => _resources.Find((x) => x.resourceType==resourceType);
    private void OnValidate() 
    {
        List<ResourceType> addedTypes = new List<ResourceType>();

        foreach (ResourcesConfigElement resourceConfig in _resources)
        {
            if (addedTypes.Contains(resourceConfig.resourceType))
            {
                resourceConfig.resourceType = ResourceType.None;
                Debug.LogError("Resources config must not have type dublicates");
            }
            else
                addedTypes.Add(resourceConfig.resourceType);
        }
    }
}
