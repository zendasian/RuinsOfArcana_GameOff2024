using UnityEngine;

public class Anim_reset : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void reset_anim_console()
    {
        GetComponent<Animator>().SetBool("is_active", false);
    }
}
