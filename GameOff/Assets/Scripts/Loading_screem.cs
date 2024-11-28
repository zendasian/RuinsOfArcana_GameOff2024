using System.Runtime.CompilerServices;
using UnityEngine;

public class Loading_screem : MonoBehaviour
{
    public void SetAnimOutro()
    {
        this.GetComponent<Animator>().SetTrigger("Outro");
        Invoke("setthisOff", 2f);
    }
    public void setthisOff()
    {
        gameObject.SetActive(false);
    }
    
}
