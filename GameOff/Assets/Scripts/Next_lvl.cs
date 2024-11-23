using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_lvl : MonoBehaviour
{
    public bool isNextLvl = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            if (isNextLvl)
                Invoke("NextLvl", 0.5f);
            else
                Invoke("PreviousLvl", 0.5f);
        }
    }
    public void NextLvl()
    {
        GlobalVariable.instance.is_next_lvl = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        FindFirstObjectByType<DialogueSystem>().TextErase();
        
    }
    public void PreviousLvl()
    {
        GlobalVariable.instance.is_next_lvl = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        PersistantDataMangaer.instance.SaveGame();

    
    }
    
}
