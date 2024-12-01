using UnityEngine;

public class Dialouge_once : MonoBehaviour
{
    public string dialogue;

    private void OnMouseDown()
    {

        if (!GlobalVariable.instance.is_cryo_dialouge)
        {
            FindFirstObjectByType<DialogueSystem>().DisplayDialogue("Player: \"What were they doing with them? This… this feels wrong\"");
            GlobalVariable.instance.is_cryo_dialouge = true;
        }



    }
}
