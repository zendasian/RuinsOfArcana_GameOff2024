using UnityEngine;

public class Skeli_anim : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 public void play_anim()
 {
    GetComponent<Animator>().SetBool("Is_skeli_fall",true);
 }
}
