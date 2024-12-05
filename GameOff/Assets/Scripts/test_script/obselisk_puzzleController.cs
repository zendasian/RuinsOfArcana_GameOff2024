using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;
using System.Linq;

public class obselisk_puzzleController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> obselisks = new List<GameObject>();
    [SerializeField]
    private Items spearhead;

    int amountofobselisk;

    bool is_dialouge = false;

    public UnityEvent puzzleSolved;
    public UnityEvent playerReturns;
    public UnityEvent playerReturn_without_spearhead;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(!GlobalVariable.instance.is_next_lvl && !GlobalVariable.instance.is_spearhead_picked)
        {
            playerReturn_without_spearhead.Invoke();
        }

        if (!GlobalVariable.instance.is_next_lvl && GlobalVariable.instance.is_obs_correct && GlobalVariable.instance.is_spearhead_picked)
        {
            playerReturns.Invoke();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //checks if all the children have correct agnle. could have done with for loop but its only three so its fine
        if (obselisks[0].GetComponent<Obselisk>().isagnglecorrect && obselisks[1].GetComponent<Obselisk>().isagnglecorrect && obselisks[2].GetComponent<Obselisk>().isagnglecorrect)
        {
            puzzleSolved.Invoke();

            obs_dialouge();

            GlobalVariable.instance.is_obs_correct = true;
        }

    }

    public void obs_dialouge()
    {
        if (!is_dialouge)
        {

            FindFirstObjectByType<Audio_Manager>().Play("Bridge_move");
            is_dialouge = true;
            GameObject.FindFirstObjectByType<DialogueSystem>().DisplayDialogue("Player: well that did something! That sound… something massive just moved.");

        }
    }
}
