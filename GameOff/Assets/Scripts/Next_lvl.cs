using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Next_lvl : MonoBehaviour
{
    [SerializeField]
    private GameObject loadingscreen;
    public bool isNextLvl = false;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (loadingscreen == null)
            loadingscreen = GameObject.FindWithTag("LoadingScreen");

        
        if (other.CompareTag("Player"))
        {
            if (isNextLvl)
                Invoke("NextLvl", 0f); // Added required time parameter
            else
                Invoke("PreviousLvl", 0f);
        }
    }
    private void NextLvl()
    {
        GlobalVariable.instance.is_next_lvl = true;
        Scene_manager.instance.startIenum(true);
        
    }
    private void PreviousLvl()
    {
        GlobalVariable.instance.is_next_lvl = false;
        Scene_manager.instance.startIenum(false);
    }
    
}
