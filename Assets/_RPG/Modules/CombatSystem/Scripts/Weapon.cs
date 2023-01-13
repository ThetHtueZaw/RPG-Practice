using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private CharacterStats _CharacterStats;

    private AnimationEventReceiver _AnimationEventReceiver;

    private Collider _Collider;

    private void Start()
    {
        _CharacterStats= GetComponentInParent<CharacterStats>();
        _Collider = GetComponent<Collider>();

        _Collider.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out CharacterStats otherStats))
        {
            Debug.Log($"Hit {otherStats.gameObject.name}");
            otherStats.TakeDamage(_CharacterStats);
        }
    }

    public void StartListenAnimationEvent(AnimationEventReceiver animationEventReceiver)
    {
        _AnimationEventReceiver = animationEventReceiver;

        _AnimationEventReceiver.OnHitStarted += EnableColliderOnHitStart;
        _AnimationEventReceiver.OnHitEnded += DisableColliderOnHitEnd;
    }

    public void EnableColliderOnHitStart()
    {
        _Collider.enabled = true;
    }
    
    public void DisableColliderOnHitEnd()
    {
        _Collider.enabled = false;
    }

    private void OnDestroy()
    {
        _AnimationEventReceiver.OnHitStarted -= EnableColliderOnHitStart;
        _AnimationEventReceiver.OnHitEnded -= DisableColliderOnHitEnd;
    }

}
