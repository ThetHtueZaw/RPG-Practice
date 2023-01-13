using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "RPG/Item/Equipment")]
public class Equipment : Item
{
    public SkinnedMeshRenderer MeshRenderer;
    public MeshRenderer AltMeshRenderer;

    public EquipmentSlots Slot;

    public bool IsDefault;

    public int ArmorModifier;
    public int DamageModifier;

    public override void Use()
    {
        base.Use();

        EquipmentManager.Instance.Equip(this);
    }
}
