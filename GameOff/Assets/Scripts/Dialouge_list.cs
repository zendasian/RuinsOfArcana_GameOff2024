using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialouge_list : MonoBehaviour
{
    public static Dialouge_list instance;
    DialogueSystem dialogueSystem;
    [SerializeField]
    private GameObject LoadingScreen;
    [SerializeField]
    private GameObject CS;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        dialogueSystem = GameObject.FindFirstObjectByType<DialogueSystem>();
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Level1" && !GlobalVariable.instance.is_lvl_dialouge[0])
        {
            dialogueSystem.DisplayDialogue(">Player: “This place… it’s incredible, like stepping into another time.”");
            GlobalVariable.instance.is_lvl_dialouge[0] = true;
        }
         if (currentScene.name == "Level2" && !GlobalVariable.instance.is_lvl_dialouge[1])
        {
            dialogueSystem.DisplayDialogue(">Player: \"Oh wow… this is it. They’ll have to let me back into the Guild after this!\" ");
            GlobalVariable.instance.is_lvl_dialouge[1] = true;
        }
        if (currentScene.name == "Level3" && !GlobalVariable.instance.is_lvl_dialouge[2])
        {
            dialogueSystem.DisplayDialogue("Player: \"this place, these engraving, Its feels religious.\"");
            GlobalVariable.instance.is_lvl_dialouge[2] = true;
        }
        if (currentScene.name == "Level4" && !GlobalVariable.instance.is_lvl_dialouge[3])
        {
            dialogueSystem.DisplayDialogue("Player: \"Whoa… a tomb. Looks royal\"");
            GlobalVariable.instance.is_lvl_dialouge[3] = true;
        }
        if (currentScene.name == "Level5" && !GlobalVariable.instance.is_lvl_dialouge[4])
        {
            dialogueSystem.DisplayDialogue("Player: \"The temple… it’s just a front. This is a lab…\"");
            GlobalVariable.instance.is_lvl_dialouge[4] = true;
        }
        if (currentScene.name == "Cutscene1")
        {
            StartCoroutine("CS_1_dialouge");
        }

    }
    private IEnumerator CS_1_dialouge()
    {
        DialogueSystem dialogueSystem = FindFirstObjectByType<DialogueSystem>();
        yield return new WaitForSeconds(2f);
        dialogueSystem.DisplayDialogue(">Sensor: \"Alert: Energy surge detected. \" ");
        yield return new WaitForSeconds(5f);
        dialogueSystem.DisplayDialogue(">Player: “Iron-Comet to Cell17. SE region, Arcana Belt. ”");
        yield return new WaitForSeconds(5f);
        dialogueSystem.DisplayDialogue(">Detecting a cosmic energy spike at coordinates 3.141, 592, 653.");
        yield return new WaitForSeconds(6f);
        dialogueSystem.DisplayDialogue(">Player: “Comms jammed. Guess I’m greenlighting this recon myself.”");
        yield return new WaitForSeconds(6f);
        
        LoadingScreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        CS.GetComponent<Animator>().SetTrigger("CS2");
        LoadingScreen.GetComponent<Animator>().SetTrigger("Outro");
        yield return new WaitForSeconds(5f);

        dialogueSystem.DisplayDialogue("The dwarf planet appears as the ship approaches.");
        yield return new WaitForSeconds(5f);
        dialogueSystem.DisplayDialogue("Player: “A whole planet… just sitting here, unnoticed. Let’s see what it’s hiding.”");
        yield return new WaitForSeconds(7f);

        LoadingScreen.SetActive(true);
        yield return new WaitForSeconds(3f);
        CS.GetComponent<Animator>().SetTrigger("CS3");
        LoadingScreen.GetComponent<Animator>().SetTrigger("Outro");
        yield return new WaitForSeconds(5f);

        dialogueSystem.DisplayDialogue("Player: “A temple… that means civilization. Scanning now.”");
        yield return new WaitForSeconds(5f);
        dialogueSystem.DisplayDialogue("Data Sphere: “No life detected within 10,000 units.”");
        yield return new WaitForSeconds(5f);
        dialogueSystem.DisplayDialogue("Player: “An empty planet with active energy. What happened here?”");


        

        yield return null;
    }



}
