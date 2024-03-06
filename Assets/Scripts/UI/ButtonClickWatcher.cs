using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

/// <summary>
/// Это просто обертка над юнитивской кнопкой. Не люблю настраивать через инспектор, как и не хочется в коде прокидывать всю кнопку
/// Прэтому тут только ивент о клике на чтение
/// </summary>
[RequireComponent(typeof(Button))]
public class ButtonClickWatcher : MonoBehaviour
{
    [SerializeField] private Button _button;

    public UnityEvent clicked => _button.onClick;
}
