using Unity.Jobs;
using UnityEngine;
using UnityEngine.UI;

public class Item_UI : MonoBehaviour
{
    public int Slotindex;

    [HideInInspector]
    public Items slotItem;
   
    private void Update()
    {
        if (slotItem != null)
        {
            gameObject.GetComponent<Image>().sprite = slotItem.icon;
        }
    }
    
   public void onclick()
    {

        gameObject.GetComponentInParent<Inventory_manager>().ItemIntractions(Slotindex, slotItem);


    }

    
    
}
