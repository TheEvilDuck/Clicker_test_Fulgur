using System;


/// <summary>
/// Элемент базы данных ресурсов, включающий стринговое имя и дефолтное значение ресурса.
/// </summary>
[Serializable]
public class ResourcesConfigElement
{
    public int defaultValue;
    public string name;
    public ResourceType resourceType;
}