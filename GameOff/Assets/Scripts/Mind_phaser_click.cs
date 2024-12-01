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
        Destroy(GameObject.Find("Canvas"));
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void start_phaser()
    {
        Invoke("turn_on_trigger", 5f);
    }
    void turn_on_trigger()
    {
        GetComponent<BoxCollider>().enabled = true;
    }
        private void OnMouseEnter()
    {
        UnityEngine.Cursor.SetCursor(GlobalVariable.instance.eye_cursor, new Vector2(24, 24), CursorMode.Auto);
    }
    private void OnMouseExit() 
    {
        UnityEngine.Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }


}
