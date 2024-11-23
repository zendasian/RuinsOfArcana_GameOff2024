using UnityEngine;
using UnityEngine.SceneManagement;
public class Door_anim_lvl4 : MonoBehaviour
{
    Animator animator;
    Inventory_manager inventory_manager;
    public Items item;
    void Start()
    {
        animator = GetComponent<Animator>();
        inventory_manager = FindFirstObjectByType<Inventory_manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnMouseDown() 
    {
        if(inventory_manager.item.Contains(item))
        {
            animator.SetBool("DoorOpen", true);
        }
        else
        {
            
            animator.SetBool("AccessDenied", true);
        }
    }
    public void ResetAccessDenied()
    {
        animator.SetBool("AccessDenied", false);
    }
    public void NextLevel()
    {
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
       
    }
}
