using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ResourceWatcher : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _targetText;
    private string _resourceName;

    public void Init(string resourceName)
    {
        _resourceName = resourceName;
    }

    public virtual void UpdateCount(int count)
    {
        _targetText.text = $"{_resourceName}: {count}";
    }

}
