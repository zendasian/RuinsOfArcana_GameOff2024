using UnityEngine;

public class Lvl6_cutscene_trigger : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GlobalVariable.instance.is_cutscene = true;
            
            GameObject.FindWithTag("Player").GetComponent<Animator>().SetBool("is_walking", false);
            FindFirstObjectByType<Dialouge_list>().lvl6_director_ienum();
            

        }
        
    }
}
