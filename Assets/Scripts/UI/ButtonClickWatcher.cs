using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonClickWatcher : MonoBehaviour
{
    [SerializeField] private Button _button;

    public UnityEvent clicked => _button.onClick;
}
