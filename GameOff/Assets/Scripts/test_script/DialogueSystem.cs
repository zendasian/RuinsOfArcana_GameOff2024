using System.Collections;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.InputSystem;

public class DialogueSystem : MonoBehaviour
{
    [Header("UI Components")]
    public TextMeshProUGUI dialogueText;

    [Header("Typing Settings")]
    public float typingSpeed = 0.01f;

    private bool isTyping = false;
    float typingskip = 1;

    

    // Reference to DialogueList component
    //private DialogueList dialogueList;

    private void Start()
    {
        dialogueText = GameObject.Find("Dialouges").GetComponent<TextMeshProUGUI>();
        //dialogueList = FindFirstObjectByType<DialogueList>();
    }
    private void Update() 
    {
        if(Input.GetKey(KeyCode.Mouse1))
        {
            Debug.Log("skipping");
            typingskip = 0f;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            typingskip = 1f;
        }
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
            yield return new WaitForSeconds(typingSpeed * typingskip);
        }


        Invoke("TextErase", 2.0f);
    }
    
    public void TextErase()
    {
        dialogueText.text = "";
        GlobalVariable.instance.is_Typing = false;
    }
    public void textColorWhite()
    {
        dialogueText.color = Color.white;
    }
}
