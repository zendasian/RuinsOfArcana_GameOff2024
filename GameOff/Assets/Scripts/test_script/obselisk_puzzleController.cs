using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

public class obselisk_puzzleController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> obselisks = new List<GameObject>();

    int amountofobselisk;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        amountofobselisk = this.transform.childCount;

        for (int i= 0; i <= amountofobselisk; i++) 
        {
            obselisks.Add(this.transform.GetChild(i).gameObject);

        }
    }

    // Update is called once per frame
    void Update()
    {
        //checks if all the children have correct agnle. could have done with for loop but its only three so its fine
        if (obselisks[0].GetComponent<Obselisk>().isagnglecorrect && obselisks[1].GetComponent<Obselisk>().isagnglecorrect && obselisks[2].GetComponent<Obselisk>().isagnglecorrect)
        {
            Debug.Log("level complete!!!!!!!!!!!!!!!!");
        }
    }
}
