using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    #region Singleton

    public static AbilityManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log($"Duplicate {this.name}");
        }
    }

    #endregion

    [SerializeField]
    private Ability[] _CurrentAbilities;

    public System.Action<int, int, Ability, Ability> OnAbilityChange;

    private void Start()
    {
        _CurrentAbilities = new Ability[Enum.GetNames(typeof(AbilitySlot)).Length];
    }

    public void Equip(Ability ability)
    {
        bool hasEmptySpace = false;

        for (int index = 0; index < _CurrentAbilities.Length; index++)
        {
            if (_CurrentAbilities[index] == null)
            {
                _CurrentAbilities[index] = ability;
                hasEmptySpace = true;
                OnAbilityChange?.Invoke(index, 0, ability, null);
                break;
            }
        }

        if (hasEmptySpace == false)
        {
            Unequip(0);
            _CurrentAbilities[0] = ability;
            OnAbilityChange?.Invoke(0, 0, ability, null);
        }
    }

    public void Unequip(int slot)
    {
        InventoryManager.Instance.AddItem(_CurrentAbilities[slot]);
        OnAbilityChange?.Invoke(0, slot, null, _CurrentAbilities[slot]);
        _CurrentAbilities[slot] = null;
    }

    public void UnequipAll()
    {
        for (int index = 0; index < _CurrentAbilities.Length; index++)
        {
            if (_CurrentAbilities[index] == null )
            {
                return;
            }

            InventoryManager.Instance.AddItem(_CurrentAbilities[index]);
            _CurrentAbilities[index] = null;
        }
    }
}
