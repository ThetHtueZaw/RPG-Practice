using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : CharacterAnimator
{
    protected override void Start()
    {
        base.Start();

        EquipmentManager.Instance.OnEquipmentChanged += UpdateAnimationOnEquipmentChange;

        for (int i = 0; i < WeaponAnimations.Length; i++)
        {
            if (WeaponAnimations[i].Equipment.IsDefault)
            {
                _CurrentAnimationClips = WeaponAnimations[i].AnimationClips;

                break;
            }
        }
    }


    protected override void OnDestroy()
    {
        base.OnDestroy();

        EquipmentManager.Instance.OnEquipmentChanged -= UpdateAnimationOnEquipmentChange;
    }

    public void UpdateAnimationOnEquipmentChange(Equipment oldEquipment, Equipment newEquipment)
    {
        Debug.Log("AnimationOnEquipmentChanged");


        if(oldEquipment != null)
        {
            if(oldEquipment.Slot == EquipmentSlots.WeaponR)
            {
                _Animator.SetLayerWeight(1, 0);
            }
            else if (oldEquipment.Slot == EquipmentSlots.WeaponL)
            {
                _Animator.SetLayerWeight(2, 0);
            }
        }

        if (newEquipment != null)
        {
            if (newEquipment.Slot == EquipmentSlots.WeaponR)
            {
                _Animator.SetLayerWeight(1, 1);
            }
            else if (newEquipment.Slot == EquipmentSlots.WeaponL)
            {
                _Animator.SetLayerWeight(2, 1);
            }

            if (newEquipment.Slot == EquipmentSlots.WeaponL || newEquipment.Slot == EquipmentSlots.WeaponR)
            {
                _CurrentAnimationClips = WeaponAnimationDic[newEquipment];
            }
        }
    }
}
