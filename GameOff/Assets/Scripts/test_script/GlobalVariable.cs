using System;
using Unity.VisualScripting;
using UnityEngine;

public class GlobalVariable : MonoBehaviour
{
    public bool[] phase = new bool[4];

    public static GlobalVariable instance;

    public bool is_puzzle_solved = false;


    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
   
    void Start()
    {
        phase[0] = true;
       

    }



}
