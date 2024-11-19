using UnityEngine;

public class Door_script : MonoBehaviour
{

   private void OnTriggerEnter2D(Collider2D other) {
    if(other.gameObject.CompareTag("Door"))
    {
        Debug.Log("solved");
        GlobalVariable.instance.is_puzzle_solved = true;
        
    }
   }
}
