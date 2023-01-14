using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityHolder : MonoBehaviour
{
    public Ability Ability;
    private float _ActivateTime;
    private float _Cooldown;

    public AbilitySlot AbilitySlot;

    private float _ActiveTimeCountDown;
    private float _CooldownCountDown;

    private enum AbilityState
    {
        READY,
        ACTIVE,
        COOLDOWN
    }

    private AbilityState _CurrentState = AbilityState.READY;

    private void Start()
    {
        AbilityManager.Instance.OnAbilityChange += OnAbilityChange;
    }

    private void Update()
    {
        if(_CurrentState == AbilityState.ACTIVE)
        {
            if(_ActiveTimeCountDown > 0)
            {
                _ActiveTimeCountDown -= Time.deltaTime;
            }
            else
            {
                _CooldownCountDown = _Cooldown;
                _CurrentState = AbilityState.COOLDOWN;
            }
        }

        if (_CurrentState == AbilityState.COOLDOWN)
        {
            if (_CooldownCountDown > 0)
            {
                _CooldownCountDown -= Time.deltaTime;
            }
            else
            {
                _CurrentState = AbilityState.READY;
            }
        }
    }

    public void OnAbilityChange(int newSlot, int oldSlot, Ability newAbility, Ability oldAbility)
    {
        if(oldAbility != null && oldSlot == (int)AbilitySlot)
        {
            Ability = null;
        }

        if (newAbility != null && newSlot == (int)AbilitySlot)
        {
            Ability = newAbility;
            _ActivateTime = Ability.ActiveTime;
            _Cooldown = Ability.Cooldown;
        }
    }

    public void Attack()
    {
        if(Ability == null)
        {
            return;
        }

        if(_CurrentState == AbilityState.READY)
        {
            Ability.Activate(PlayerManager.Instance.PlayerStats.gameObject);
            _ActiveTimeCountDown = _ActivateTime;
            _CooldownCountDown = _Cooldown;
            _CurrentState = AbilityState.ACTIVE;
        }
    }
}
