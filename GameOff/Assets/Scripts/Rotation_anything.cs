using UnityEngine;

public class Rotation_anything : MonoBehaviour
{
    public float maxRotationSpeed = 100f; // Maximum rotation speed in degrees per second
    public float acceleration = 20f;     // Rotation acceleration in degrees per second squared
    private float currentRotationSpeed = 0f; // Current rotation speed
    public float clockWise = 1;

    void Update()
    {
        if (GlobalVariable.instance.lvl_5_done)
        {
            // Increment the current rotation speed with acceleration
            currentRotationSpeed += acceleration * Time.deltaTime;

            // Clamp the speed to the maximum rotation speed
            currentRotationSpeed = Mathf.Clamp(currentRotationSpeed, 0f, maxRotationSpeed);

            // Rotate the object around its Y-axis
            transform.Rotate(0, 0, currentRotationSpeed * clockWise * Time.deltaTime);
        }
    }

    public void StartRotation()
    {
        GlobalVariable.instance.lvl_5_done = true;
    }
    

}
