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
        if (currentScene.name == "Level1" && !GlobalVariable.instance.is_lvl_dialouge[0])
        {
            dialogueSystem.DisplayDialogue(">Player: “This place… it’s incredible, like stepping into another time.”");
            GlobalVariable.instance.is_lvl_dialouge[0] = true;
        }
         if (currentScene.name == "Level2" && !GlobalVariable.instance.is_lvl_dialouge[1])
        {
            dialogueSystem.DisplayDialogue(">Player: \"Oh wow… this is it. They’ll _have_ to let me back into the Guild after this!\" ");
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

    }

    void Update()
    {

    }
}
