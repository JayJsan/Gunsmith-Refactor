using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [Header("Configuration")]
    public int shopLevel = 1;
    public int shopLevelCap = 3;
    public int minimumItemCost = 100;
    public int maximumItemCost = 1000;
    public int minimumItemStats = 1;
    public int maximumItemStats = 3;
    public int refreshCost = 100;
    [Header("References")]
    public UIShopHandler uiShopHandler;
    // ==== VARIABLES ====
    private List<Item> shopItems = new List<Item>(3);

    void Start()
    {
        if (uiShopHandler == null)
        {
            CDL.LogError<ShopManager>("UI Shop Handler not found!");
        }
    }

    /// <summary>
    /// Refreshes the shop, changing the items and their stats.
    /// </summary>
    public void RefreshShop()
    {
        shopItems.Clear();
        GenerateShopItems();
        UpdateUI();
    }

    private void UpdateUI()
    {
        for (int i = 0; i < shopItems.Count; i++)
        {
            uiShopHandler.UpdateItem(i + 1, shopItems[i].name, shopItems[i].cost.ToString(), shopItems[i].GetStats());
        }
        uiShopHandler.UpdateRefreshCost(refreshCost.ToString());
    }

    public void GenerateShopItems()
    {
        for (int i = 0; i < shopLevel; i++)
        {
            shopItems.Add(GenerateItem());
        }
    }

    private Item GenerateItem()
    {
        Item item = new Item();
        item.name = "Item" + Random.Range(0, 1000);
        item.cost = 100;

        for (int i = 0; i < Random.Range(minimumItemStats, maximumItemStats); i++)
        {
            item.itemStats.Add(new ItemStat());
        }

        // randomize each stat
        foreach (ItemStat stat in item.itemStats)
        {
            int random = Random.Range(0, 2);

            switch (random)
            {
                case 0:
                    stat.flatAmount = Random.Range(-10, 10 * shopLevel);
                    break;
                case 1:
                    stat.percentageAmount = Random.Range(-5, 33 * shopLevel) / 100;
                    break;
                case 2:
                    stat.flatAmount = Random.Range(1, 10);
                    stat.percentageAmount = Random.Range(-5, 33 * shopLevel) / 100;
                    break;
            }

            stat.type = (Stats.Type)Random.Range(0, 3);
        }
        return item;
    }
}
