using UnityEngine;

public class Dialouge_once : MonoBehaviour
{
    public string dialogue;
   
   private void OnMouseDown() 
   {
        
       
            FindFirstObjectByType<DialogueSystem>().DisplayDialogue("Player: \"What were they doing with them? This… this feels wrong\"");
            
        
   }
}
