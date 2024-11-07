using System;
using Unity.VisualScripting;
using UnityEngine;

public class GlobalVariable : MonoBehaviour
{
    public bool[] phase = new bool[4];

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        phase[0] = true;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame


    
}
