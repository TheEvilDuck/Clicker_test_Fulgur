using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Этот класс в какой-то степени является медиатором между кнопками изменения ресурсов и самими ресурсами.
/// Но также нужен для настройки кнопок: у объекта этого класса 
/// в инспекторе в списке создается конфиг, прокидывается кнопка и указывается, какой ресурс и в каком количестве будет
/// изменен при клике на кнопку. Так как это монобех, то для инициализации нужно вызвать метод Init
/// </summary>
public class ResourceButtons: MonoBehaviour
{
    [SerializeField] private List<ButtonConfig> _configs;

    public void Init(PlayerStats playerStats)
    {
        foreach (ButtonConfig config in _configs)
        {
            if (config.resourceType == ResourceType.None)
            {
                Debug.LogWarning("There is a button with None resource type in resourceButton object, it will be ignored");
                continue;
            }

            //В этом классе нет отписок, т.к. unity event'ы, насколько я знаю, сами очищаются при уничтожении
            config.button.clicked.AddListener(()=>
            {
                playerStats.AddResource(config.resourceType, config.amount);
            });
        }
    }


    /// <summary>
    /// Внутренний конфиг, чтобы выставить каждой кнопке соответствие ресурсу.
    /// Чисто технически позволяет сделать разные кнопки даже на один ресурс
    /// </summary>
    [Serializable]
    private class ButtonConfig
    {
        public ButtonClickWatcher button;
        public ResourceType resourceType;
        public int amount = 1;
    }
}