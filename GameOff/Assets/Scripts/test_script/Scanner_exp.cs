using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class Scanner_exp : MonoBehaviour
{
    [SerializeField]
    List<GameObject> scanner_list = new List<GameObject>();
    List<float> distance_list = new List<float>();
    public float scanner_range = 5;
    bool is_scannerReady = true;
    public float scanner_cooldown = 3f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && is_scannerReady)
        {
            GlobalVariable.instance.is_scanning = true;
            GetComponent<Animator>().SetBool("is_scanning", true);
            scanner_list.AddRange(GameObject.FindGameObjectsWithTag("items"));
            Vector2 playerpos = gameObject.transform.position;
            Debug.Log(scanner_list.Count);
            FindFirstObjectByType<Audio_Manager>().Play("Scanner");
            
            foreach (GameObject scanner in scanner_list)
            {
                distance_list.Add(Vector2.Distance(scanner.transform.position, playerpos));
            }
            if (distance_list.Min() <= scanner_range)
            {
                int minIndex = distance_list.IndexOf(distance_list.Min());
                Scanner_dialouge.instance.DisplayDialogue(scanner_list[minIndex].GetComponent<Items_Object>().item.hint);
            }
            else
            {
                Scanner_dialouge.instance.DisplayDialogue("Nothing here");
            }
            distance_list.Clear();
            scanner_list.Clear();
            is_scannerReady = false;
            Invoke("scannerTimer", scanner_cooldown);
        }
        else if (Input.GetKeyDown(KeyCode.C) && !is_scannerReady)
        {
            Scanner_dialouge.instance.DisplayDialogue("Data Sphere is not ready");
        }
    }

    private void scannerTimer()
    {
        is_scannerReady = true;
        

        Debug.Log("Scanner is ready");
    }
    public void scanner_end_anim()
    {
        GlobalVariable.instance.is_scanning = false;
        GetComponent<Animator>().SetBool("is_scanning", false);
    }
    private void OnDrawGizmosSelected()
    {
        // Visualize the scan radius in the scene view
        Gizmos.color = Color.red;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Gizmos.DrawWireSphere(player.transform.position, scanner_range);
        }
    }
}
