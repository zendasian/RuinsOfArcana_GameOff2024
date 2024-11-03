using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class items_show : MonoBehaviour
{
    public SpriteRenderer SpriteRenderer;
 
    public Inventory_itelms inventory;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpriteRenderer.sprite = inventory.ItemSprite;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (inventory.Actions.Contains("Apple"))
        gameObject.SetActive(false);
    }
}
