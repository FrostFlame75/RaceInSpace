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
    [SerializeField] float yawSens;
    [SerializeField] float accelScale;
    [SerializeField] float drag;
    [SerializeField] float passiveDragRight;
    [SerializeField] float passiveDragUp;
    public bool hasControl;
    Rigidbody rb;
    InputAction steerAction;
    InputAction moveAction;
    InputAction brakeAction;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        steerAction = InputSystem.actions.FindAction("Steer");
        //if (steerAction == null) {
        //    steerAction = InputSystem.actions.FindAction("Move");
        //    moveAction = InputSystem.actions.FindAction("Jump");

        //}

        brakeAction = InputSystem.actions.FindAction("Brake");
        //if (brakeAction == null) steerAction = InputSystem.actions.FindAction("Sprint");

        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasControl)
        {
            float accel;
            // Get current input values every frame
            Vector3 steerValue = steerAction.ReadValue<Vector3>();
            bool moveBool = moveAction.IsPressed();
            bool brakeBool = brakeAction.IsPressed();
            if (moveBool) { accel = accelScale; } else { accel = 0; }
            Vector3 rotation = Vector3.zero;
            if (horizInvert) { steerValue.x *= -1; }
            if (vertInvert) { steerValue.y *= -1; }
            rotation = new Vector3(steerValue.y * pitchSens, steerValue.x * rollSens * -1, steerValue.z * yawSens * -1);



            gameObject.transform.Rotate(rotation * Time.deltaTime);
            rb.AddForce(transform.up * accel);

            if (brakeBool) { rb.AddForce(rb.linearVelocity * -1 * drag); }
            else
            {
                rb.AddForce(Vector3.Dot(rb.linearVelocity, transform.right) * transform.right * passiveDragRight * -1);
                rb.AddForce(Vector3.Dot(rb.linearVelocity, transform.forward) * transform.forward * passiveDragUp * -1);
            }
            if (rb.linearVelocity.magnitude < 0.001)
            {
                rb.linearVelocity = Vector3.zero;
            }
        }

    }

    
}
