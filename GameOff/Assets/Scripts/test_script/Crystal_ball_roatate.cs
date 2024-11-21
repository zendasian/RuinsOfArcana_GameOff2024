using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
public class Crystal_ball_roatate : MonoBehaviour
{
    

    Collider2D self_collider;
    [SerializeField]
    GameObject Door_trigger;
    [SerializeField]
    float Correct_angle = 135;

    public UnityEvent puzzleSolved;
    DialogueSystem dialogueSystem;
    Ray Ray_self;
    bool is_typed = false;
    bool is_typed_2 = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        self_collider = this.GetComponent<Collider2D>();
        dialogueSystem = FindFirstObjectByType<DialogueSystem>();
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
            if (!is_typed)
            {
                is_typed = true;
                dialogueSystem.DisplayDialogue("I think I've found the key to the crystal ball but I need to remove the window block first.");
                
            }
            
        }
        if (UnityEditor.TransformUtils.GetInspectorRotation(transform).z == Correct_angle && GlobalVariable.instance.is_window_block_remove)
        {
            if (!is_typed_2)   
            {
                is_typed_2 = true;
                puzzleSolved.Invoke();
            }
            
        }
        
        
    }
   


}
