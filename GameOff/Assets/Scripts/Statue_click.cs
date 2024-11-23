using UnityEngine;

public class Statue_click : MonoBehaviour, IPersistanceManager
{
    public bool is_spearDown = false;

    private void Update()
    {
        if (is_spearDown)
        {
            gameObject.GetComponent<Animator>().enabled = true;
        }
    }
 private void OnMouseDown()
 {
    gameObject.GetComponent<Animator>().enabled = true;
    is_spearDown = true;
 }

 public void LoadData(Level_data data)
 {
    is_spearDown = data.is_statue_down;
 }
 public void SaveData(ref Level_data data)
 {
    data.is_statue_down = is_spearDown;
 }
}
