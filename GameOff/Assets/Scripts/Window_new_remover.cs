using UnityEngine;
using UnityEngine.Events;

public class Window_new_remover : MonoBehaviour
{
    public UnityEvent onRemove;
    Inventory_manager inventory_manager;

    public GameObject window;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventory_manager = GameObject.Find("InventoryManager").GetComponent<Inventory_manager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        if (inventory_manager.tempItem != null)
            inventory_manager.GameObjectInteraction(window);

    }
}
