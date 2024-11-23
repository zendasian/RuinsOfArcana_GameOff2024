using UnityEngine;
using UnityEngine.Events;
public class Skeli_controller : MonoBehaviour
{
    public Items item;
    Inventory_manager inventory_manager;
    public UnityEvent on_skeli_done;
    void Start()
    {
        inventory_manager = FindFirstObjectByType<Inventory_manager>();
    }

    void Update()
    {
        
    }
    private void OnMouseDown() 
    {
        if (inventory_manager.tempItem == item)
        {
            inventory_manager.item.Remove(item);
            on_skeli_done.Invoke();
        }
    }
}
