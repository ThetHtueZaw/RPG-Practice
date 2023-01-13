using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthHandler : MonoBehaviour
{
    public GameObject HealthUIPrefab;
    public Transform RootUI;

    private EnemyStats _EnemyStats;
    private EnemyHealthUI _HealthUI;

    // Start is called before the first frame update
    void Start()
    {
        _HealthUI = Instantiate(HealthUIPrefab).GetComponent<EnemyHealthUI>();

        _EnemyStats = GetComponent<EnemyStats>();
        _EnemyStats.OnHealthChanged += OnHealthChanged;

        OnHealthChanged(_EnemyStats.CurrentHealth, _EnemyStats.MaxHealth);
    }

    private void Update()
    {
        if(_HealthUI == null)
        {
            return;
        }

        _HealthUI.transform.position = RootUI.position;
    }

    private void OnDestroy()
    {
        Destroy(_HealthUI.gameObject);
        _HealthUI = null;
    }

    void OnHealthChanged(int currentHealth, int maxHealth)
    {
        _HealthUI.SetData(_EnemyStats.CurrentHealth, _EnemyStats.MaxHealth);
    }
}
