using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityButtonUI : MonoBehaviour
{
    public Image Icon;
    public Image Cooldown;

    public void SetData(Ability ability)
    {
        Icon.sprite = ability.Icon;
        Icon.enabled = true;
        Cooldown.fillAmount = 0;
    }

    public void ClearData()
    {
        Icon.enabled = false;
    }

    public void UpdateCooldownImage(float currentAmount, float maxAmount)
    {
        Cooldown.fillAmount = currentAmount/maxAmount;
    }
}
