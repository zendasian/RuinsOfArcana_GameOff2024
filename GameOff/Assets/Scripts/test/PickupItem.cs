using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public Item item;

    private void OnMouseDown()
    {
        InventoryManager.Instance.AddItem(item);
        Destroy(gameObject); // Optionally remove the item from the scene.
    }
}