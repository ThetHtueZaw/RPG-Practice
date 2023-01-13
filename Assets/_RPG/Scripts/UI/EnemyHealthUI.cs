using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    public Slider _HealthSlider;

    public void SetData(int currentHealth, int maxHealth)
    {
        _HealthSlider.value = (float)currentHealth / (float)maxHealth;
    }
}
