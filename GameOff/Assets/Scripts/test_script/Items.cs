using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Items", menuName = "Scriptable Inventory/Items")]
public class Items : ScriptableObject
{
    public string name;
    public Sprite icon;
    public string description;
    public List<string> Actions = new List<string>();
    public Texture2D cursor;
}
