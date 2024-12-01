using System;
using Unity.VisualScripting;
using UnityEngine;

public class GlobalVariable : MonoBehaviour
{
    public Texture2D eye_cursor;
    public bool[] phase = new bool[4];
    public static GlobalVariable instance;
    public bool is_puzzle_solved = false;
    public bool is_Typing = false;
    public bool is_window_block_remove = false;
    public bool is_next_lvl = true;
    public bool is_statue_down = false;
    public bool is_obs_correct = false;
    public bool lvl_5_done = false;
    public bool is_scanning = false;
    public bool is_console_on = false;
    public bool is_glyph_dialouge = false;
    public bool[] is_lvl_dialouge = new bool[5];
    public bool is_cryo_dialouge = false;
    public bool is_pickable_lvl4 = true;
    public bool is_cutscene = false;

    public bool should_keep = true;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        if (should_keep)
        DontDestroyOnLoad(gameObject);
    }
   
    void Start()
    {
        phase[0] = true;
        is_obs_correct = false;
       

    }



}
