using UnityEngine;

public class Camera_zoom_zone : MonoBehaviour
{
    public GameObject camera_zoom;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            camera_zoom.GetComponent<Animator>().SetBool("Is_zoom", true);
            Debug.Log("zoom");
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            camera_zoom.GetComponent<Animator>().SetBool("Is_zoom", false);
            Debug.Log("zoom out");
        }
    }
}
