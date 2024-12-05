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
      if (this.GetComponent<Items_Object>().isActiveAndEnabled)
      {
         Audio_Manager.instance.Play("Statue_click");
         this.GetComponent<Items_Object>().enabled = false;
         
      }

      is_spearDown = true;
   }
   private void OnMouseEnter()
   {
      if (!is_spearDown && FindFirstObjectByType<Inventory_manager>().tempItem == null)
      UnityEngine.Cursor.SetCursor(GlobalVariable.instance.eye_cursor, new Vector2(24, 24), CursorMode.Auto);
   }
   private void OnMouseExit()
   {
      if(FindFirstObjectByType<Inventory_manager>().tempItem == null)
      UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
   }



}
