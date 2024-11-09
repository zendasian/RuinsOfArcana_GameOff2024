using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct TagDialoguePair
{
    public string tag;
    [TextArea(2, 5)] // Optional: Gives a larger input area for dialogue text in the Inspector
    public string dialogue;
}
public class DialogueList : MonoBehaviour
{
    // Dictionary to store tag-dialogue pairs
    //private Dictionary<string, string> dialogueDictionary = new Dictionary<string, string>()
    //{
    //    { "tag_a", "hi how are you" },
    //    { "tag_b", "answer me" },
    //    { "tag_c", "ANSWER ME LUCIFER" },
    //    { "tag_d", "*transforms into michael" }
    //};
    [Header("Tag-Dialogue Pairs")]
    public List<TagDialoguePair> tagDialoguePairs = new List<TagDialoguePair>();

    private Dictionary<string, string> dialogueDictionary = new Dictionary<string, string>();

    private void Awake()
    {
        // Populate the dictionary from the list
        foreach (var pair in tagDialoguePairs)
        {
            if (!dialogueDictionary.ContainsKey(pair.tag))
            {
                dialogueDictionary.Add(pair.tag, pair.dialogue);
            }
        }
    }
    // Method to get dialogue based on tag
    public string GetDialogueByTag(string tag)
    {
        if (dialogueDictionary.ContainsKey(tag))
        {
            return dialogueDictionary[tag];
        }
        else
        {
            return "Dialogue not found for the specified tag.";
        }
    }
}
