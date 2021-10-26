using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private int _minHealth = 0;
    [SerializeField] private int _maxHealth = 100;
    [SerializeField] private int _health = 100;

    public UnityEvent<int> HealthChanged;

    public int Health
    {
        get => _health;
        private set
        {
            if (_health != value)
                _health = Mathf.Min(_maxHealth, value);

            HealthChanged?.Invoke(_health);
        }
    }

    public int MinHealth => _minHealth;

    public int MaxHealth => _maxHealth;

    private void Start()
    {
        _health = Mathf.Min(_maxHealth, _health);
        //HealthChanged?.Invoke(_health);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            DoDamage();
        if (Input.GetMouseButtonDown(1))
            DoHeal();
    }

    public void DoDamage()
    {
        if (Health <= MinHealth)
            return;

        Health -= 10;
    }

    public void DoHeal()
    {
        if (Health >= MaxHealth)
            return;

        Health += 10;
    }
}
