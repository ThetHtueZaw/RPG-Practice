using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interactable
{
    public Item Item;

    public override void Interact(Collider other)
    {
        base.Interact(other);

        if(InventoryManager.Instance.AddItem(Item) == false)
        {
            return;
        }

        Debug.Log($"Picking Up {Item.Name}");
        Destroy(gameObject);
    }
}
