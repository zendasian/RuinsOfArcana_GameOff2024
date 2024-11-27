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

    bool is_mouse_once = false;

    public Vector3 trigger_correct_position;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        self_collider = this.GetComponent<Collider2D>();
        dialogueSystem = FindFirstObjectByType<DialogueSystem>();
    }

    // Update is called once per frame
    void Update()
    {


        // if (self_collider.IsTouchingLayers(LayerMask.GetMask("Player")) && Input.GetKeyDown(KeyCode.Q) && !GlobalVariable.instance.is_puzzle_solved)
        // {
        //  transform.Rotate(0, 0, 45);
        // }

        // Define a threshold for position comparison
        const float positionThreshold = 0.01f; // Adjust as necessary

        if (Mathf.Abs(Door_trigger.transform.position.x - 18.96f) < positionThreshold &&
            Mathf.Abs(Door_trigger.transform.position.y + 0.64f) < positionThreshold &&
            Mathf.Abs(Door_trigger.transform.position.z - 0.62f) < positionThreshold)
        {
            Debug.Log(Door_trigger.transform.position);
            GlobalVariable.instance.is_puzzle_solved = true;
            if (!is_typed && !GlobalVariable.instance.is_window_block_remove)
            {
                is_typed = true;
                dialogueSystem.DisplayDialogue(">Player: \"No reaction. I must be missing something.\"");
            }

        }

        if (Mathf.Abs(Door_trigger.transform.position.x - 18.96f) < positionThreshold &&
            Mathf.Abs(Door_trigger.transform.position.y + 0.64f) < positionThreshold &&
            Mathf.Abs(Door_trigger.transform.position.z - 0.62f) < positionThreshold &&
            GlobalVariable.instance.is_window_block_remove)
        {
            if (!is_typed_2)
            {
                is_typed_2 = true;
                puzzleSolved.Invoke();
            }

        }
    }

    private void OnMouseDown()
    {
        if (!GlobalVariable.instance.is_puzzle_solved && !GlobalVariable.instance.is_Typing)
            transform.Rotate(0, 0, 45);

        if(!is_mouse_once)
        {
            is_mouse_once = true;
            GameObject.FindFirstObjectByType<DialogueSystem>().DisplayDialogue("Player: This looks like some kind of mechanism. It’s redirecting a beam of light from that window.");
        }
        



    }

}

//UnityEditor.TransformUtils.GetInspectorRotation(transform).z == Correct_angle && GlobalVariable.instance.is_window_block_remove
//UnityEditor.TransformUtils.GetInspectorRotation(transform).z == Correct_angle


