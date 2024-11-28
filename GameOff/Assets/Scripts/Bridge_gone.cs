using UnityEngine;

public class Bridge_gone : MonoBehaviour
{
    [SerializeField]
    GameObject bridge;
    bool isBridgeGone = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
         if (other.gameObject.CompareTag("Player") && !isBridgeGone)
        {
            isBridgeGone = true;
            bridge.GetComponent<Animator>().SetTrigger("Down");
            GameObject.FindFirstObjectByType<DialogueSystem>().DisplayDialogue(">Player: \"well shit.. I'll have to find another way\"");
        }
    }
}
