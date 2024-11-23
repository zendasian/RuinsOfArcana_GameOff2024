using System;
using Unity.VisualScripting;
using UnityEngine;

public class GlobalVariable : MonoBehaviour
{
    public bool[] phase = new bool[4];
    public static GlobalVariable instance;
    public bool is_puzzle_solved = false;
    public bool is_Typing = false;
    public bool is_window_block_remove = false;
    public bool is_next_lvl = true;
    public bool is_statue_down = false;
    public bool is_obs_correct = false;


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
        is_obs_correct = false;
       

    }



}
