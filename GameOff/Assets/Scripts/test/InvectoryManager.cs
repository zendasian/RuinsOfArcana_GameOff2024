using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }
    public List<Item> Items { get; private set; } = new List<Item>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void AddItem(Item item)
    {
        Items.Add(item);
        // Optional: Trigger an event or update the UI here.
        Debug.Log($"Added {item.name} to inventory.");
    }

    public void RemoveItem(Item item)
    {
        Items.Remove(item);
        // Optional: Trigger an event or update the UI here.
        Debug.Log($"Removed {item.name} from inventory.");
    }
}