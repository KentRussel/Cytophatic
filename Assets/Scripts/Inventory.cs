using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryBar : MonoBehaviour
{
    // The character that the inventory bar belongs to
    public GameObject character;

    // The maximum number of items that the inventory can hold
    public int maxInventorySize = 10;

    // The list of items currently in the inventory
    private List<GameObject> inventory = new List<GameObject>();

    // The UI images that will display the items in the inventory
    public Image[] inventorySlots;

    void Start()
    {
        // Initialize the inventory slots
        for (int i = 0; i < inventorySlots.Length; i++)
        {
            inventorySlots[i].gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Update the inventory UI
        for (int i = 0; i < inventory.Count; i++)
        {
            inventorySlots[i].gameObject.SetActive(true);
            inventorySlots[i].sprite = inventory[i].GetComponent<SpriteRenderer>().sprite;
        }
    }

    public void AddItem(GameObject item)
    {
        // Add an item to the inventory if there is room
        if (inventory.Count < maxInventorySize)
        {
            inventory.Add(item);
        }
    }

    public void RemoveItem(GameObject item)
    {
        // Remove an item from the inventory
        inventory.Remove(item);
    }
}

