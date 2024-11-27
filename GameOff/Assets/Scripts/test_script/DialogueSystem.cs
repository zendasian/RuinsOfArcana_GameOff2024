using System.Collections;
using UnityEngine;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    [Header("UI Components")]
    public TextMeshProUGUI dialogueText;

    [Header("Typing Settings")]
    public float typingSpeed = 0.03f;

    private bool isTyping = false;

    

    // Reference to DialogueList component
    //private DialogueList dialogueList;

    private void Start()
    {
        dialogueText = GameObject.Find("Dialouges").GetComponent<TextMeshProUGUI>();
        //dialogueList = FindFirstObjectByType<DialogueList>();
    }

    // Function to be called when an object is clicked, passing its tag
    //public void DisplayDialogueByTag(string tag)
    //{
    //    Debug.Log("DisplayDialogueByTag Called");
    //    if (dialogueList != null && !isTyping)
    //    {
    //        string dialogue = dialogueList.GetDialogueByTag(tag);
    //        StartCoroutine(TypeDialogue(dialogue));
    //    }
    //}

    // Function to display any dialogue passed as a parameter
    public void DisplayDialogue(string dialogue)
    {

        if (!GlobalVariable.instance.is_Typing)
        {
            StartCoroutine(TypeDialogue(dialogue));
        }
    }

    // Coroutine for the typing effect
    private IEnumerator TypeDialogue(string dialogue)
    {
        GlobalVariable.instance.is_Typing = true;
        dialogueText.text = "";

        foreach (char letter in dialogue.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        
        Invoke("TextErase", 2.0f);
    }
    public void TextErase()
    {
        dialogueText.text = "";
        GlobalVariable.instance.is_Typing = false;
    }
}
