using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialouge_list : MonoBehaviour
{
    [SerializeField]
    private GameObject Death_scene;
    public static Dialouge_list instance;
    DialogueSystem dialogueSystem;
    [SerializeField]
    private GameObject LoadingScreen;
    [SerializeField]
    private GameObject CS;
    [SerializeField]
    private GameObject document;
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
            Audio_Manager.instance.Play("BG_score");
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
        if (currentScene.name == "Level6")
        {
            StartCoroutine("Lvl6_dialouges");
        }

    }
    private IEnumerator CS_1_dialouge()
    {
        DialogueSystem dialogueSystem = FindFirstObjectByType<DialogueSystem>();
        Audio_Manager.instance.Play("Energy_surge");
        yield return new WaitForSeconds(2f);
        dialogueSystem.DisplayDialogue(">Sensor: \"Alert: Energy surge detected. \" ");
        yield return new WaitForSeconds(5f);
        dialogueSystem.DisplayDialogue(">Player: “Iron-Comet to Cell17. SE region, Arcana Belt. ”");
        yield return new WaitForSeconds(5f);
        dialogueSystem.DisplayDialogue(">Detecting a cosmic energy spike at coordinates 3.141, 592, 653.");
        yield return new WaitForSeconds(6f);
        dialogueSystem.DisplayDialogue(">Player: “Comms jammed. Guess I’m greenlighting this recon myself.”");
        yield return new WaitForSeconds(6f);
        Audio_Manager.instance.Stop("Intro_BG");
        Audio_Manager.instance.Stop("Energy_surge");

        LoadingScreen.SetActive(true);
        Audio_Manager.instance.Play("Planet_reveal");
        yield return new WaitForSeconds(3f);
        CS.GetComponent<Animator>().SetTrigger("CS2");
        LoadingScreen.GetComponent<Animator>().SetTrigger("Outro");
        yield return new WaitForSeconds(5f);

        dialogueSystem.DisplayDialogue("The dwarf planet appears as the ship approaches.");
        yield return new WaitForSeconds(6f);
        dialogueSystem.DisplayDialogue("Player: “A whole planet… just sitting here, unnoticed. Let’s see what it’s hiding.”");
        yield return new WaitForSeconds(7f);
        Audio_Manager.instance.Stop("Planet_reveal");

        LoadingScreen.SetActive(true);
        
        yield return new WaitForSeconds(3f);
        Audio_Manager.instance.Play("Reveal_full");
        CS.GetComponent<Animator>().SetTrigger("CS3");
        LoadingScreen.GetComponent<Animator>().SetTrigger("Outro");
        yield return new WaitForSeconds(5f);

        dialogueSystem.DisplayDialogue("Player: “A temple… that means civilization. Scanning now.”");
        yield return new WaitForSeconds(5f);
        dialogueSystem.DisplayDialogue("Data Sphere: “No life detected within 10,000 units.”");
        yield return new WaitForSeconds(5f);
        dialogueSystem.DisplayDialogue("Player: “An empty planet with active energy. What happened here?”");
        yield return new WaitForSeconds(5f);
        Audio_Manager.instance.Stop("Reveal_full");
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);




        yield return null;
    }

    public void dialouge_stick_pickup()
    {
        StartCoroutine("Stick_dilouge");
    }
    IEnumerator Stick_dilouge()
    {
        yield return new WaitForSeconds(5f);
        FindFirstObjectByType<DialogueSystem>().DisplayDialogue("Player: \"whoops...dang it...well, this stick might come in handy later.\"");

        yield return null;
    }
    IEnumerator Lvl6_dialouges()
    {
        DialogueSystem dialogueSystem = FindFirstObjectByType<DialogueSystem>();
        GlobalVariable.instance.is_cutscene = true;
        dialogueSystem.DisplayDialogue(">Voice: \"You touched me… Are you here to hurt me, like the others?\"");
        yield return new WaitForSeconds(6f);
        dialogueSystem.DisplayDialogue(">Player: \"No! I’m not like them, I wouldn't hurt anyone\"");
        yield return new WaitForSeconds(5f);
        dialogueSystem.DisplayDialogue(">Voice: \"Not like them? Are you sure?\"");
        yield return new WaitForSeconds(4f);
        GameObject.FindWithTag("White_screen").GetComponent<Animator>().SetTrigger("Fade_out");
        yield return new WaitForSeconds(2f);
        dialogueSystem.DisplayDialogue(">Player: \"Where… where am I?\"");
        GlobalVariable.instance.is_cutscene = false;

        yield return null;
    }
    public void lvl6_director_ienum()
    {
        StartCoroutine("Lvl6_director_dialouges");
    }
    public IEnumerator Lvl6_director_dialouges()
    {


        DialogueSystem dialogueSystem = FindFirstObjectByType<DialogueSystem>();
        GlobalVariable.instance.is_cutscene = true;
        dialogueSystem.DisplayDialogue(">Player: \"Director… no. Not again…\"");
        yield return new WaitForSeconds(4f);
        dialogueSystem.DisplayDialogue(">Director: \"Still confident in those calculations, Kara? Still so sure of yourself?\"");
        yield return new WaitForSeconds(7f);
        dialogueSystem.DisplayDialogue(">Player: \"I’m sorry… I—\"");
        yield return new WaitForSeconds(4f);
        dialogueSystem.DisplayDialogue(">Director: \"Sorry? One dead. The rest in comas. All because of you.\"");
        yield return new WaitForSeconds(6f);
        dialogueSystem.DisplayDialogue(">Director: \"This wasn’t just a mistake. This was arrogance, Kara. Your arrogance.\"");
        yield return new WaitForSeconds(7f);
        dialogueSystem.DisplayDialogue(">Player: \"I didn’t mean to… I didn’t— \"");
        yield return new WaitForSeconds(4f);
        dialogueSystem.DisplayDialogue(">Director: \"You’re done. Fired from the Guild. Forever.\"");
        yield return new WaitForSeconds(5f);

        GameObject.FindWithTag("White_screen").GetComponent<Animator>().SetTrigger("Fade_in");
        yield return new WaitForSeconds(3f);

        dialogueSystem.DisplayDialogue(">Voice: \"You think they’ll forgive you? You want to use me to crawl back to them?\"");
        yield return new WaitForSeconds(7f);
        dialogueSystem.DisplayDialogue(">Player: \"No… I just…I need to make things right\"");
        yield return new WaitForSeconds(5f);
        dialogueSystem.DisplayDialogue(">Voice: \"By giving me back to those who will hurt me just like the one before\"");
        yield return new WaitForSeconds(6f);
        dialogueSystem.DisplayDialogue(">Voice: \"I won't let you take me\"");
        yield return new WaitForSeconds(4f);
        dialogueSystem.DisplayDialogue(">Player: \"no...\"");
        yield return new WaitForSeconds(3f);

        Death_scene.SetActive(true);
        yield return new WaitForSeconds(3f);
        GameObject.FindWithTag("White_screen").GetComponent<Animator>().SetTrigger("Fade_out");
        dialogueSystem.textColorWhite();
        yield return new WaitForSeconds(2f);

        dialogueSystem.DisplayDialogue(">Data Sphere: \"Vital signs critical. Warning: Vital signs critical.\"");
        yield return new WaitForSeconds(7f);
        dialogueSystem.DisplayDialogue(">Data Sphere: \"No vitals readings detected. Status: Deceased\"");
        yield return new WaitForSeconds(6f);
        LoadingScreen.SetActive(true);
        yield return new WaitForSeconds(2f);

        document.SetActive(true);

        dialogueSystem.DisplayDialogue("One Cycle later");
        yield return new WaitForSeconds(3f);

        dialogueSystem.DisplayDialogue(">voice one: \"Subject: Dr. Kara Thorne. \"");
        yield return new WaitForSeconds(4f);
        dialogueSystem.DisplayDialogue(">voice one: \"Former lead researcher of the Guild\"");
        yield return new WaitForSeconds(4f);
        dialogueSystem.DisplayDialogue(">voice one: \"Current affiliation: Cell 17.\"");
        yield return new WaitForSeconds(4f);
        dialogueSystem.DisplayDialogue(">voice one:  \"Last known coordinates: 3.141, 592, 653, SE region, Arcana Belt\"");
        yield return new WaitForSeconds(7f);
        dialogueSystem.DisplayDialogue("> voice one: \"Interesting... nothing was discovered there. A practically unexplorable zone.\"");
        yield return new WaitForSeconds(8f);
        dialogueSystem.DisplayDialogue(">voice two: \"But she found something. A surge... that we didn’t\"");
        yield return new WaitForSeconds(6f);
        document.GetComponent<Animator>().enabled = true;
        dialogueSystem.DisplayDialogue(">voice one: \"Data purge initiated.\"");
        yield return new WaitForSeconds(4f);
        dialogueSystem.DisplayDialogue(">voice two: \"Send in the recon teams.\"");
        yield return new WaitForSeconds(5f);
        dialogueSystem.DisplayDialogue(">voice one: \"What if we really find it, sire?\"");
        yield return new WaitForSeconds(5f);
        dialogueSystem.DisplayDialogue(">Voice  two: \"We mobilize the Mothership\"");







        yield return null;

    }



}
