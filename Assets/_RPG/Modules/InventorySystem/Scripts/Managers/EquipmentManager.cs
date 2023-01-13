using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    #region Singleton

    public static EquipmentManager Instance;

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

    public Equipment[] DefaultEquipments;
    public Equipment[] CurrentEquipments;

    public SkinnedMeshRenderer Root;

    public Renderer[] CurrentRenderers;

    public Transform LSlot;
    public Transform RSlot;

    public System.Action<Equipment, Equipment> OnEquipmentChanged;

    // Start is called before the first frame update
    void Start()
    {
        CurrentEquipments = new Equipment[Enum.GetNames(typeof(EquipmentSlots)).Length];
        CurrentRenderers = new Renderer[Enum.GetNames(typeof(EquipmentSlots)).Length];

        EquipDefaultEquipments();
    }

    private void EquipDefaultEquipments()
    {
        foreach (Equipment equipment in DefaultEquipments)
        {
            Equip(equipment);
        }
    }

    public void Equip(Equipment equipment)
    {
        Debug.Log($"Equipped : {equipment.Name}");

        Equipment oldEquipment = CurrentEquipments[(int)equipment.Slot];

        if(oldEquipment != null )
        {
            Unequip(oldEquipment);
        }

        CurrentEquipments[(int)equipment.Slot] = equipment;

        if(equipment.MeshRenderer != null )
        {
            SkinnedMeshRenderer newMesh = Instantiate(equipment.MeshRenderer);

            newMesh.rootBone = Root.rootBone;
            newMesh.bones = Root.bones;

            newMesh.gameObject.transform.parent = Root.transform;

            CurrentRenderers[(int)equipment.Slot] = newMesh;
        }
        else
        {
            MeshRenderer newMesh = Instantiate(equipment.AltMeshRenderer);

            if(equipment.Slot == EquipmentSlots.WeaponL)
            {
                newMesh.transform.parent = LSlot;
            }
            else
            {
                newMesh.transform.parent = RSlot;
            }

            newMesh.transform.localPosition = Vector3.zero;
            newMesh.transform.localRotation = Quaternion.identity;
            newMesh.transform.localScale = Vector3.one;

            CurrentRenderers[(int)equipment.Slot] = newMesh;

            newMesh.GetComponent<Weapon>().StartListenAnimationEvent(RSlot.GetComponentInParent<AnimationEventReceiver>());
        }

        PlayerManager.Instance.PlayerStats.ModifyArmor(equipment.ArmorModifier, ModifyType.Add);
        PlayerManager.Instance.PlayerStats.ModifyDamage(equipment.DamageModifier, ModifyType.Add);

        OnEquipmentChanged?.Invoke(oldEquipment, equipment);
    }

    public void Unequip(Equipment equipment)
    {
        CurrentEquipments[(int)equipment.Slot] = null;
        Destroy(CurrentRenderers[(int)equipment.Slot].gameObject);

        PlayerManager.Instance.PlayerStats.ModifyArmor(equipment.ArmorModifier, ModifyType.Remove);
        PlayerManager.Instance.PlayerStats.ModifyDamage(equipment.DamageModifier, ModifyType.Remove);

        if (!equipment.IsDefault)
        {
            InventoryManager.Instance.AddItem(equipment);
        }

        OnEquipmentChanged?.Invoke(equipment, null);
    }

    public void UnequipAll()
    {
        foreach (Equipment equipment in CurrentEquipments)
        {
            if(equipment == null)
            {
                continue;
            }

            Unequip(equipment);
            EquipDefaultEquipments();
        }
    }
}
