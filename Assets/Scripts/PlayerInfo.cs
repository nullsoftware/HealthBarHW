using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class PlayerInfo : MonoBehaviour
{
    [SerializeField] private int _health = 100;

    public UnityEvent<int> HealthChanged;

    public int Health
    {
        get => _health;
        private set
        {
            if (_health != value)
                _health = value;

            HealthChanged?.Invoke(_health);
        }
    }

    private void Start()
    {
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
        if (Health <= 0)
            return;

        Health -= 10;
    }

    public void DoHeal()
    {
        if (Health >= 100)
            return;

        Health += 10;
    }
}
