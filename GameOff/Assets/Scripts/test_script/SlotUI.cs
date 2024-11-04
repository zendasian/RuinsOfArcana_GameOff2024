using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlotUI : MonoBehaviour
{
    public int slotnum;
    Items item;
    SpriteRenderer icon;
    
    
    
    void Start()
    {
        icon = GetComponent<SpriteRenderer>();

    }


    private void Update()
    {
       
    }
}
