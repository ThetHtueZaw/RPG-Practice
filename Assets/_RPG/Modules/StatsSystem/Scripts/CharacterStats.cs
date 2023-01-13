using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterStats : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;

    public int MaxMana;
    public int CurrentMana;

    public Stats Armor;
    public Stats Damage;

    public System.Action<int, int> OnHealthChanged;

    protected virtual void Awake()
    {
        CurrentHealth = MaxHealth;
        CurrentMana = MaxMana;
    }

    public void ModifyArmor(int modifier, ModifyType modifyType)
    {
        if(modifier == 0)
        {
            return;
        }

        switch (modifyType)
        {
            case ModifyType.Add:
                Armor.Add(modifier); break;

            case ModifyType.Remove:
                Armor.Remove(modifier); break;
        }
    }

    public void ModifyDamage(int modifier, ModifyType modifyType)
    {
        if (modifier == 0)
        {
            return;
        }

        switch (modifyType)
        {
            case ModifyType.Add:
                Damage.Add(modifier); break;

            case ModifyType.Remove:
                Damage.Remove(modifier); break;
        }
    }

    public void TakeDamage(CharacterStats attackerStats)
    {
        CurrentHealth -= attackerStats.Damage.GetValue();

        OnHealthChanged?.Invoke(CurrentHealth, MaxHealth);

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        
    }
}
