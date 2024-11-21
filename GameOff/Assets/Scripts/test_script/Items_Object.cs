using System.Linq.Expressions;
using UnityEngine;

public class Items_Object : MonoBehaviour
{
    public Items item;

    SpriteRenderer sprite_this;
    private DialogueSystem dialogueSystem;
    public int PhaseIndex;
    public bool is_Pickable = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (is_Pickable)
        {
            sprite_this = GetComponent<SpriteRenderer>();
            sprite_this.sprite = item.icon;
            dialogueSystem = FindFirstObjectByType<DialogueSystem>();
        }

    }
    private void Awake() 
    {
        dialogueSystem = FindFirstObjectByType<DialogueSystem>();
    }

    private void OnMouseDown()
    {
        if (GameObject.FindGameObjectWithTag("Globalvariable").GetComponent<GlobalVariable>().phase[PhaseIndex] && !GlobalVariable.instance.is_Typing && is_Pickable)
        {
            FindFirstObjectByType<Inventory_manager>().Additems(item, gameObject);
            FindFirstObjectByType<Audio_Manager>().Play("Pickup");

        }

        //Debug.Log("ClickHandler Working");
        //if (dialogueSystem != null)
        //{
        //    Debug.Log("dialogueSystem Not Null");
        //    string objectTag = item.name;
        //    dialogueSystem.DisplayDialogueByTag(objectTag);
        //}
        if (is_Pickable)
            dialogueSystem.DisplayDialogue(item.description);
    }

}