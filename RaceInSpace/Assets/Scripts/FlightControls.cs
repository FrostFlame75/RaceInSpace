using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class FlightControls : MonoBehaviour
{
    // Importing variables
    [SerializeField] bool vertInvert;
    [SerializeField] bool horizInvert;
    [SerializeField] float pitchSens;
    [SerializeField] float rollSens;
    [SerializeField] float accelScale;
    [SerializeField] float drag;
    Rigidbody rb;
    InputAction steerAction;
    InputAction moveAction;
    InputAction brakeAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        steerAction = InputSystem.actions.FindAction("Steer");
        brakeAction = InputSystem.actions.FindAction("Brake");
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {          
        float accel;
        // Get current input values every frame
        Vector2 steerValue = steerAction.ReadValue<Vector2>();
        bool moveBool = moveAction.IsPressed();
        bool brakeBool = brakeAction.IsPressed();
        if (moveBool) { accel = accelScale; } else { accel = 0; }
            Vector3 rotation = Vector3.zero;

        rotation = new Vector3(steerValue.y * pitchSens, steerValue.x * rollSens * -1, 0);
        

        
        gameObject.transform.Rotate(rotation * Time.deltaTime);
        rb.AddForce(transform.up * accel);
        if (brakeBool) { rb.AddForce(rb.linearVelocity * -1 * drag); }
        if (rb.linearVelocity.magnitude < 0.001)
        {
            rb.linearVelocity = Vector3.zero;
        }

    }

    
}
