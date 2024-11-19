using UnityEngine;

public class Crystal_ball_roatate : MonoBehaviour
{
    

    Collider2D self_collider;
    [SerializeField]
    GameObject Door_trigger;
    [SerializeField]
    float Correct_angle = 135;

 

    Ray Ray_self;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        self_collider = this.GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {

        if (self_collider.IsTouchingLayers(LayerMask.GetMask("Player")) && Input.GetKeyDown(KeyCode.Q) && !GlobalVariable.instance.is_puzzle_solved)
        {
            transform.Rotate(0, 0, 45);

        }


        if (UnityEditor.TransformUtils.GetInspectorRotation(transform).z == Correct_angle)
        {
            GlobalVariable.instance.is_puzzle_solved = true;
        }
        
        
    }


}
