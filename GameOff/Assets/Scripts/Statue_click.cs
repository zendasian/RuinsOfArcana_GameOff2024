using UnityEngine;

public class Statue_click : MonoBehaviour
{
    public bool is_spearDown = false;
 private void OnMouseDown()
 {
    gameObject.GetComponent<Animator>().enabled = true;
    is_spearDown = true;
 }
}
