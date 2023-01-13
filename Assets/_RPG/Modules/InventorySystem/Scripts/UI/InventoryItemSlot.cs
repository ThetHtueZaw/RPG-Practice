using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlot : MonoBehaviour
{
    public Image Icon;
    public Image RemoveButton;

    private Item _CurrentItem;

    public void SetUIData(Item item)
    {
        _CurrentItem = item;

        Icon.sprite = item.Icon;

        Icon.enabled = true;
        RemoveButton.enabled = true;
    }

    public void ClearUIData()
    {
        _CurrentItem = null;

        Icon.enabled = false;
        RemoveButton.enabled = false;
    }

    public void Remove()
    {
        InventoryManager.Instance.RemoveItem(_CurrentItem);
    }

    public void Use()
    {
        if(_CurrentItem == null)
        {
            return;
        }
        _CurrentItem.Use();
    }
}
