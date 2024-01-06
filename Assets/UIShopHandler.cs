using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIShopHandler : MonoBehaviour
{
    [Header("Item 1")]
    public TextMeshProUGUI itemName1;
    public TextMeshProUGUI itemCost1;
    public TextMeshProUGUI itemStats1;
    [Header("Item 2")]
    public TextMeshProUGUI itemName2;
    public TextMeshProUGUI itemCost2;
    public TextMeshProUGUI itemStats2;
    [Header("Item 3")]
    public TextMeshProUGUI itemName3;
    public TextMeshProUGUI itemCost3;
    public TextMeshProUGUI itemStats3;

    public void UpdateItem(int itemNumber, string itemName, string itemCost, string itemStats)
    {
        switch (itemNumber)
        {
            case 1:
                itemName1.text = itemName;
                itemCost1.text = itemCost;
                itemStats1.text = itemStats;
                break;
            case 2:
                itemName2.text = itemName;
                itemCost2.text = itemCost;
                itemStats2.text = itemStats;
                break;
            case 3:
                itemName3.text = itemName;
                itemCost3.text = itemCost;
                itemStats3.text = itemStats;
                break;
            default:
                CDL.LogError<UIShopHandler>("Invalid item number!");
                break;
        }
    }
}
