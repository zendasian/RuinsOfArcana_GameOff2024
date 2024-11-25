using UnityEngine;
using TMPro;
using System.Collections;

public class Scanner_dialouge : MonoBehaviour
{

    [Header("UI Components")]
    public TextMeshProUGUI dialogueText;

    [Header("Typing Settings")]
    public float typingSpeed = 0.05f;

    private bool isTyping = false;

    public static Scanner_dialouge instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        dialogueText = GameObject.FindWithTag("Scan_text").GetComponent<TextMeshProUGUI>();
    }
    private void Start() 
    {
        
       
    }
    public void DisplayDialogue(string dialogue)
    {

        if (!isTyping)
        {
            StartCoroutine(TypeDialogue(dialogue));
        }
    }

    // Coroutine for the typing effect
    private IEnumerator TypeDialogue(string dialogue)
    {
        isTyping = true;
        dialogueText.text = "";

        foreach (char letter in dialogue.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }

        
        Invoke("TextErase", 3.0f);
    }
    public void TextErase()
    {
        isTyping = false;
        dialogueText.text = "";
        
    }




}