using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [Header("Configuration")]
    public KeyCode inventoryKey = KeyCode.Tab;
    [Header("References")]
    public GameObject inventoryPanel;

    // ==========================================
    // Variables
    // ==========================================
    private bool inventoryOpen = false;

    void Start()
    {
        inventoryPanel.SetActive(false);
    }

    void Update()
    {
        ToggleInventoryOnPress();
    }

    private void ToggleInventoryOnPress()
    {
        if (Input.GetKeyDown(inventoryKey))
        {
            ToggleInventory();
        }
    }

    private void ToggleInventory()
    {
        inventoryOpen = !inventoryOpen;
        inventoryPanel.SetActive(inventoryOpen);
    }
}
