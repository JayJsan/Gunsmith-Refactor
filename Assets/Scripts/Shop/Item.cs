using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public string name;
    public int cost;

    public List<ItemStat> itemStats = new List<ItemStat>();
    public string GetStats()
    {
        string stats = "";
        for (int i = 0; i < itemStats.Count; i++)
        {
            stats += itemStats[i].type.ToString() + " " + itemStats[i].flatAmount + " " + itemStats[i].percentageAmount + "\n";
        }
        return stats;
    }
}
