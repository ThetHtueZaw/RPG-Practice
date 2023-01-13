using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterAnimator : MonoBehaviour
{
    protected Animator _Animator;

    private MyCharacterController _CharacterController;
    private CharacterCombat _CharacterCombat;

    private AnimatorOverrideController _AnimatorOverrideController;

    public AnimationClip ReplaceableClip;
    protected AnimationClip[] _CurrentAnimationClips;

    protected Dictionary<Equipment, AnimationClip[]> WeaponAnimationDic = new Dictionary<Equipment, AnimationClip[]>();

    public AnimationKeyValue[] WeaponAnimations;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        _Animator = GetComponentInChildren<Animator>();
        _CharacterController = GetComponent<MyCharacterController>();
        _CharacterCombat = GetComponent<CharacterCombat>();

        _AnimatorOverrideController = new AnimatorOverrideController(_Animator.runtimeAnimatorController);
        _Animator.runtimeAnimatorController = _AnimatorOverrideController;

        foreach (var animation in WeaponAnimations)
        {
            WeaponAnimationDic.Add(animation.Equipment, animation.AnimationClips);
        }

        GetComponent<CharacterCombat>().OnAttack += OnAttack;

        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        HandlePlayerMoveAnimation();
        HandlePlayerAttackAnimation();
    }

    private void HandlePlayerMoveAnimation()
    {
        if (_Animator == null)
        {
            return;
        }

        _Animator.SetFloat(Constants.MOVE_SPEED, _CharacterController.Movement.magnitude);
    }

    private void HandlePlayerAttackAnimation()
    {
        if (_Animator == null)
        {
            return;
        }
        _Animator.SetBool(Constants.IN_COMBAT, _CharacterCombat.InCombat);
    }

    public void OnAttack()
    {
        if (_Animator == null)
        {
            return;
        }

        _AnimatorOverrideController[ReplaceableClip.name] = _CurrentAnimationClips[Random.Range(0, _CurrentAnimationClips.Length)];

        _Animator.SetTrigger(Constants.ATTACK);
    }

    protected virtual void OnDestroy()
    {
        
    }
}
