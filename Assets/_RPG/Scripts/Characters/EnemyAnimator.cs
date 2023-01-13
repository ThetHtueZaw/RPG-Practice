using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : CharacterAnimator
{
    protected override void Start()
    {
        base.Start();

        GetComponentInChildren<Weapon>().StartListenAnimationEvent(GetComponentInChildren<AnimationEventReceiver>());
        _CurrentAnimationClips = WeaponAnimations[0].AnimationClips;
    }

    protected override void Update()
    {
        base.Update();
    }
}
