using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stats
{
    [SerializeField]
    private List<int> _Modifiers = new List<int>();

    public void Add(int modifier)
    {
        _Modifiers.Add(modifier);
    }

    public void Remove(int modifier)
    {
        _Modifiers.Remove(modifier);
    }

    public int GetValue()
    {
        int total = 0;

        foreach (int modifier in _Modifiers)
        {
            total += modifier;
        }

        return total;
    }
}
