using UnityEngine;

public class Items_Object : MonoBehaviour
{
    public Items item;

    SpriteRenderer sprite_this;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite_this = GetComponent<SpriteRenderer>();
        sprite_this.sprite = item.icon;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
