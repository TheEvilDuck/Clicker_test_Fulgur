using TMPro;
using UnityEngine;


/// <summary>
/// Этот класс лишь предоставляет интерфейс взаимодействия с текстовыми полями ресурсов. В теории может быть абстрагирован для того, чтобы 
/// ресурсы могли не только в виде текста отображаться. 
/// </summary>
[RequireComponent(typeof(TextMeshProUGUI))]
public class ResourceWatcher : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _targetText;
    private string _resourceName;

    public void Init(string resourceName)
    {
        _resourceName = resourceName;
    }

    public void UpdateCount(int count)
    {
        _targetText.text = $"{_resourceName}: {count}";
    }

}
