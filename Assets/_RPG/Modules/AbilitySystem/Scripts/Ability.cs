using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : Item
{
    public float Cooldown;
    public float ActiveTime;

    public virtual void Activate(GameObject activator)
    {
        Debug.Log($"Activate {Name}");
    }

    public override void Use()
    {
        base.Use();

        AbilityManager.Instance.Equip( this );
    }
}
