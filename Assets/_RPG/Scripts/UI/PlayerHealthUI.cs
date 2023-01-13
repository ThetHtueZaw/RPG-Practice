using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthUI : MonoBehaviour
{
    private Slider _HealthSlider;

    // Start is called before the first frame update
    void Awake()
    {
        _HealthSlider= GetComponent<Slider>();
    }

    public void SetData(int currentHealth, int maxHealth)
    {
        _HealthSlider.value = (float)currentHealth / (float)maxHealth;
    }
}
