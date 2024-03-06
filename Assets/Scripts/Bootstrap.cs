using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private ButtonClickWatcher _goldButton;
    [SerializeField] private ButtonClickWatcher _silverButton;
    [SerializeField] private ResourceWatcher _goldText;
    [SerializeField] private ResourceWatcher _silverText;
    [SerializeField] private ResourceWatcher _totalText;
    private PlayerStats _playerStats;
    private ResourceMediator _resourceMediator;

    private void Awake() 
    {
        _playerStats = new PlayerStats();
        _goldText.Init("Золото");
        _silverText.Init("Серебро");
        _totalText.Init("Всего: ");
        _resourceMediator = new ResourceMediator(_playerStats, _goldButton, _silverButton, _goldText, _silverText, _totalText);
    }

    private void OnDestroy() 
    {
        _resourceMediator.Dispose();
    }
}
