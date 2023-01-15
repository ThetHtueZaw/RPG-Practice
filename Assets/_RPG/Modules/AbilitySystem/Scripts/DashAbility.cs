using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RPG/AbilitySystem/DashAbility")]
public class DashAbility : Ability
{
    public float DashForce;
    public bool IsDashing;

    public override void Activate(GameObject activator)
    {
        base.Activate(activator);
        Vector3 forceToApply = activator.transform.forward * DashForce;
        activator.GetComponent<Rigidbody>().AddForce(forceToApply, ForceMode.Impulse);
        activator.GetComponentInChildren<Animator>().SetTrigger("Dash");
    }

    
}
