using System.Linq.Expressions;
using UnityEngine;

public class Items_Object : MonoBehaviour
{
    public Items item;

    SpriteRenderer sprite_this;

    public int PhaseIndex;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite_this = GetComponent<SpriteRenderer>();
        sprite_this.sprite = item.icon;
        
    }

    private void OnMouseDown()
    {
        if (GameObject.FindGameObjectWithTag("Globalvariable").GetComponent<GlobalVariable>().phase[PhaseIndex])
        {
            FindFirstObjectByType<Inventory_manager>().Additems(item);
            gameObject.SetActive(false);
        }
            
       
        
    }

}