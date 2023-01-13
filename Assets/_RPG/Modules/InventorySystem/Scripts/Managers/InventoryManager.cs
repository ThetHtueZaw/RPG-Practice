using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    #region Singleton

    public static InventoryManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log($"Duplicate {this.name}");
        }
    }

    #endregion

    [SerializeField]
    private List<Item> _Items = new List<Item>();

    public delegate void OnInventoryChange(List<Item> items);
    public OnInventoryChange OnInventoryChanged;

    public int Space = 20;

    public bool AddItem(Item item)
    {
        if(_Items.Count == Space)
        {
            Debug.Log("Inventory Full!!");

            return false;
        }

        _Items.Add(item);
        OnInventoryChanged?.Invoke(_Items);
        return true;
    }

    public void RemoveItem(Item item)
    {
        _Items.Remove(item);
        OnInventoryChanged?.Invoke(_Items);
    }
}
