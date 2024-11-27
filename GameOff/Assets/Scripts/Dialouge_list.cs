using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialouge_list : MonoBehaviour
{
    public static Dialouge_list instance;
    DialogueSystem dialogueSystem;
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
        if (currentScene.name == "Level1")
        {
            dialogueSystem.DisplayDialogue(">Player: “This place… it’s incredible, like stepping into another time.”");
        }
         if (currentScene.name == "Level2")
        {
            dialogueSystem.DisplayDialogue(">Player: \"Oh wow… this is it. They’ll _have_ to let me back into the Guild after this!\" ");
        }
        if (currentScene.name == "Level3")
        {
            dialogueSystem.DisplayDialogue("Player: \"this place, these engraving, Its feels religious.\"");
        }
        if (currentScene.name == "Level4")
        {
            dialogueSystem.DisplayDialogue("Player: \"Whoa… a tomb. Looks royal\"");
        }
        if (currentScene.name == "Level5")
        {
            dialogueSystem.DisplayDialogue("Player: \"The temple… it’s just a front. This is a lab…\"");
        }

    }

    void Update()
    {

    }
}
