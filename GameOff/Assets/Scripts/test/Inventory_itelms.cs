using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Inventory_itelms", menuName = "Scriptable Objects/Inventory_items")]
public class Inventory_itelms : ScriptableObject
{
    public Sprite ItemSprite;
    public string Description;

    public List<string> Actions = new List<string>();
}
