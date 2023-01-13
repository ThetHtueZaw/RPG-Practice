using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : ScriptableObject
{
    public string Name;
    public Sprite Icon;

    [TextArea(3, 10)]
    public string Description;

    public virtual void Use()
    {
        Debug.Log($"Using {Name}");

        InventoryManager.Instance.RemoveItem(this);
    }
}
