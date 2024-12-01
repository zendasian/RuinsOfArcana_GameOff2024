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
    private void OnMouseEnter()
    {
        if (!GlobalVariable.instance.is_cryo_dialouge)
        UnityEngine.Cursor.SetCursor(GlobalVariable.instance.eye_cursor, new Vector2(24, 24), CursorMode.Auto);
    }
    private void OnMouseExit()
    {
        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
