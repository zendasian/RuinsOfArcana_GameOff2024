using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Mind_phaser_click : MonoBehaviour
{
    public UnityEvent mind_phaser_clicked;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnMouseDown() 
    {
        mind_phaser_clicked.Invoke();
        Invoke("next_level", 4f);
    }
    void next_level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
