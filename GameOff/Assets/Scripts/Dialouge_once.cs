using UnityEngine;

public class Dialouge_once : MonoBehaviour
{
    public string dialogue;
   
   private void OnMouseDown() 
   {
        if (!GlobalVariable.instance.is_cryo_dialouge)
        {
            GlobalVariable.instance.is_cryo_dialouge = true;
            FindFirstObjectByType<DialogueSystem>().DisplayDialogue("Player: \"What were they doing with them? This… this feels wrong\"");
            
        }
   }
}
