using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceMediator : IDisposable
{
    private PlayerStats _playerStats;
    private ButtonClickWatcher _goldButton;
    private ButtonClickWatcher _silverButton;
    private ResourceWatcher _goldText;
    private ResourceWatcher _silverText;
    private ResourceWatcher _totalText;

    public ResourceMediator(PlayerStats playerStats, ButtonClickWatcher goldButton, ButtonClickWatcher silverButton, ResourceWatcher goldText, ResourceWatcher silverText, ResourceWatcher totalText)
    {
        _playerStats = playerStats;
        _goldButton = goldButton;
        _silverButton = silverButton;
        _goldText = goldText;
        _silverText = silverText;
        _totalText = totalText;

        _goldButton.clicked.AddListener(OnGoldButtonPressed);
        _silverButton.clicked.AddListener(OnSilverButtonPressed);
        _playerStats.goldChanged+=OnGoldChanged;
        _playerStats.silverChanged+=OnSilverChanged;

        OnGoldChanged(_playerStats.Gold);
        OnSilverChanged(_playerStats.Silver);
    }
    public void Dispose()
    {
        _goldButton.clicked.RemoveListener(OnGoldButtonPressed);
        _silverButton.clicked.RemoveListener(OnSilverButtonPressed);

        _playerStats.goldChanged-=OnGoldChanged;
        _playerStats.silverChanged-=OnSilverChanged;
    }
    private void OnGoldButtonPressed() => _playerStats.AddGold();
    private void OnSilverButtonPressed() => _playerStats.AddSilver();
    private void OnGoldChanged(int amount)
    {
        _goldText.UpdateCount(amount);
        _totalText.UpdateCount(amount+_playerStats.Silver);
    }
    private void OnSilverChanged(int amount)
    {
        _silverText.UpdateCount(amount);
        _totalText.UpdateCount(amount+_playerStats.Gold);
    }
}
