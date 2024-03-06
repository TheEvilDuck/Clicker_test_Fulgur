using System;

public class PlayerStats
{
    private int _silver;
    private int _gold;

    public event Action<int> goldChanged;
    public event Action<int> silverChanged;

    public int Gold => _gold;
    public int Silver => _silver;

    public void AddGold()
    {
        _gold++;
        goldChanged?.Invoke(_gold);
    }

    public void AddSilver()
    {
        _silver++;
        silverChanged?.Invoke(_silver);
    }
}
