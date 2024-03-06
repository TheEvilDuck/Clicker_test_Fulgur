using System;

/// <summary>
/// Класс соответствует какому-нибудь конкретному ресурсу. Может быть абстрагировано до просто obsearvable variable при необходимости
/// </summary>
public class PlayerResource
{
    public int Value {get; private set;}

    public event Action<int> changed;

    public PlayerResource(int defaultValue)
    {
        Value = defaultValue;
    }

    

    public void Add(int amount)
    {
        Value+=amount;

        if (Value<0)
            Value = 0;

        changed?.Invoke(Value);
    }
}
