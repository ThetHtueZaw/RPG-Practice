using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public GameObject RootUI;

    public InventoryItemSlot[] ItemSlots;

    private void Start()
    {
        InventoryManager.Instance.OnInventoryChanged += UpdateUIOnInventoryChanged;

        ItemSlots = RootUI.GetComponentsInChildren<InventoryItemSlot>();
    }

    public void ToggleUI()
    {
        RootUI.SetActive(!RootUI.activeSelf);
    }

    public void UpdateUIOnInventoryChanged(List<Item> items)
    {
        foreach (InventoryItemSlot slot in ItemSlots)
        {
            slot.ClearUIData();
        }

        for (int index = 0; index < items.Count; index++)
        {
            ItemSlots[index].SetUIData(items[index]);
        }
    }
}
