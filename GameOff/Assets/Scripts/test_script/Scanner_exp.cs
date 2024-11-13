using UnityEngine;
using System.Collections.Generic;
public class Scanner_exp : MonoBehaviour
{
    [SerializeField]
    List<GameObject> scanner_list = new List<GameObject>();
    List<float> distance_list = new List<float>();
    public float scanner_range = 5;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scanner_list.AddRange(GameObject.FindGameObjectsWithTag("items"));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Vector2 playerpos = gameObject.transform.position;
            foreach (GameObject scanner in scanner_list)
            {
                Sort_distance(scanner, playerpos);
            }
        }
    }

    void Sort_distance(GameObject scanner, Vector2 playerpos)
    {
        float plyerdistance = Vector2.Distance(scanner.transform.position, playerpos);
                if (plyerdistance <= scanner_range)
                {
                    Debug.Log(scanner.GetComponent<Items_Object>().item.name);
                    
                }
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
