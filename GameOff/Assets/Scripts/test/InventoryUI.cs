using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Transform itemSlotContainer;
    public GameObject itemSlotPrefab;

    private void Start()
    {
        InventoryManager.Instance.Items.ForEach(item => AddItemToUI(item));
    }

    public void AddItemToUI(Item item)
    {
        GameObject slot = Instantiate(itemSlotPrefab, itemSlotContainer);
        Image icon = slot.transform.Find("Icon").GetComponent<Image>();
        icon.sprite = item.icon;
    }

    public void ToggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
    }
}
