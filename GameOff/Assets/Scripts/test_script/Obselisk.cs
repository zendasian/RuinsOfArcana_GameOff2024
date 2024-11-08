using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class Obselisk : MonoBehaviour
{
    bool isplayercollidig = false;
    [SerializeField, HideInInspector]
    public bool isright;

    public float correctangle;

    [SerializeField]
    float rotationangle = 0f;
    
    public bool isagnglecorrect = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && isplayercollidig)
        {
           
            rotationangle += 120f;
            transform.eulerAngles = new Vector3(0,rotationangle,0);
            
        }
        if (correctangle == UnityEditor.TransformUtils.GetInspectorRotation(transform).y)
        {
            
            isagnglecorrect = true; 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            isplayercollidig=true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            isplayercollidig = false;
        }
    }
}
