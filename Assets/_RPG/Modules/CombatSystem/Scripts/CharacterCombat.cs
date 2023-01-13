using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    public float AttackSpeed;
    private float _AttackCountDown;

    public float InCombatDuration;
    private float _InCombatCountDown;

    public bool InCombat;

    public System.Action OnAttack;

    protected virtual void Update()
    {
        _AttackCountDown -= Time.deltaTime;

        _InCombatCountDown -= Time.deltaTime;

        if (_InCombatCountDown <= 0)
        {
            InCombat = false;
        }
    }

    public void Attack()
    {
        InCombat = true;

        if(_AttackCountDown > 0)
        {
            return;
        }

        _AttackCountDown = 1 / AttackSpeed;
        _InCombatCountDown = InCombatDuration;

        Debug.Log("Attack!!!");
        OnAttack?.Invoke();
    }
}
