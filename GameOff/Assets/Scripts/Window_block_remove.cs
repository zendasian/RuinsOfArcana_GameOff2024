using UnityEngine;

public class Window_block_remove : MonoBehaviour
{
    Inventory_manager inventory_manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory_manager = GameObject.Find("InventoryManager").GetComponent<Inventory_manager>();
    }

    // Update is called once per frame
    private void OnMouseDown() 
    {
        Debug.Log("Window block remove");
        inventory_manager.GameObjectInteraction(gameObject);
    }
}
