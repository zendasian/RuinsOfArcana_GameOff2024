using UnityEngine;

public class Statue_click : MonoBehaviour
{
   public bool is_spearDown = false;
   private void Update()
   {
      if (GlobalVariable.instance.is_statue_down)
      {
         gameObject.GetComponent<Animator>().enabled = true;
         
         
      }
   }
   private void OnMouseDown()
   {
      gameObject.GetComponent<Animator>().enabled = true;
      if (this.GetComponent<Items_Object>() != null)
      {
         this.GetComponent<Items_Object>().enabled = false;
      }
      
      is_spearDown = true;
   }



}
