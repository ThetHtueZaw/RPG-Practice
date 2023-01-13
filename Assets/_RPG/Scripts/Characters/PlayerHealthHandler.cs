using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthHandler : MonoBehaviour
{
    private PlayerStats _PlayerStats;
    public PlayerHealthUI HealthUI;

    // Start is called before the first frame update
    void Start()
    {
        _PlayerStats = GetComponent<PlayerStats>();

        _PlayerStats.OnHealthChanged += OnHealthChanged;

        OnHealthChanged(_PlayerStats.CurrentHealth, _PlayerStats.MaxHealth);
    }

    void OnHealthChanged(int currentHealth, int maxHealth)
    {
        HealthUI.SetData(_PlayerStats.CurrentHealth, _PlayerStats.MaxHealth);
    }
}
