using System.Collections.Generic;
using UnityEngine;

public class ObjectScanner : MonoBehaviour
{
    public List<string> targetTags = new List<string> { "apple", "banana", "orange" };
    public float scanRadius = 2.0f; // 200 pixels is equivalent to 2 units in Unity
    public string playerTag = "Player";

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            ScanNearbyObjects();
        }
    }

    void ScanNearbyObjects()
    {
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        
        if (player != null)
        {
            Vector2 playerPosition = player.transform.position;

            foreach (string tag in targetTags)
            {
                // Find all objects with the current tag
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);

                foreach (GameObject obj in objectsWithTag)
                {
                    // Calculate the distance between the player and the object
                    float distance = Vector2.Distance(playerPosition, obj.transform.position);

                    // Check if the object is within the scan radius
                    if (distance <= scanRadius)
                    {
                        // Log the object's description to the console
                        Debug.Log($"Object: {obj.name}, Tag: {obj.tag}, Position: {obj.transform.position}");
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize the scan radius in the scene view
        Gizmos.color = Color.red;
        GameObject player = GameObject.FindGameObjectWithTag(playerTag);
        if (player != null)
        {
            Gizmos.DrawWireSphere(player.transform.position, scanRadius);
        }
    }
}