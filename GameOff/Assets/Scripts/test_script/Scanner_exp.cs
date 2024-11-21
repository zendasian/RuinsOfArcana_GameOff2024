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
    public float scanner_cooldown = 30f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C) && is_scannerReady)
        {
            scanner_list.AddRange(GameObject.FindGameObjectsWithTag("items"));
            Vector2 playerpos = gameObject.transform.position;
            Debug.Log(scanner_list.Count);
            
            foreach (GameObject scanner in scanner_list)
            {
                distance_list.Add(Vector2.Distance(scanner.transform.position, playerpos));
            }
            if (distance_list.Min() <= scanner_range)
            {
                int minIndex = distance_list.IndexOf(distance_list.Min());
                Debug.Log(scanner_list[minIndex].GetComponent<Items_Object>().item.name);
            }
            else
            {
                Debug.Log("No item found");
            }
            distance_list.Clear();
            scanner_list.Clear();
            is_scannerReady = false;
            Invoke("scannerTimer", scanner_cooldown);
        }
        else if (Input.GetKeyDown(KeyCode.C) && !is_scannerReady)
        {
            Debug.Log("Scanner is not ready");
        }
    }

    private void scannerTimer()
    {
        is_scannerReady = true;
        Debug.Log("Scanner is ready");
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
