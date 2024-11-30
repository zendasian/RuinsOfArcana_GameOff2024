using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Scene_manager : MonoBehaviour
{
    [SerializeField]
    private GameObject loadingScreen;

    public static Scene_manager instance;

    public bool is_notDestroyed = true;

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
        if (is_notDestroyed)
        DontDestroyOnLoad(gameObject);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    private void Update() {
        if(loadingScreen == null)
        {
            GameObject.FindWithTag("LoadingScreen");
        }
    }
    public void startIenum(bool is_next_lvl)
    {
        StartCoroutine(LoadingStart(is_next_lvl));
    }
    public IEnumerator LoadingStart(bool is_next_level)
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(2f);

        if (is_next_level)
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        if (!is_next_level)
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
        yield return new WaitForSeconds(1f);
        loadingScreen.GetComponent<Animator>().SetTrigger("Outro");
        yield return new WaitForSeconds(2f);
        loadingScreen.SetActive(false);
    }


}
