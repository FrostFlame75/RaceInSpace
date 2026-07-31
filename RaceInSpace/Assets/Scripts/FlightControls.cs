using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

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
    [SerializeField] RaceManager rm;
    [SerializeField] int timeScale;
    public bool hasControl;
    Rigidbody rb;
    InputAction steerAction;
    InputAction moveAction;
    InputAction brakeAction;
    InputAction quit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        steerAction = InputSystem.actions.FindAction("Steer");
        quit = InputSystem.actions.FindAction("QuitLevel");
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
        bool moveBool = moveAction.IsPressed();
        bool brakeBool = brakeAction.IsPressed();
        bool quitbool = quit.IsPressed();
        if (!hasControl && !moveBool) hasControl = true;
        if (hasControl)
        {
            float accel;
            // Get current input values every frame
            Vector3 steerValue = steerAction.ReadValue<Vector3>();
            
            if (moveBool) { accel = accelScale; } else { accel = 0; }
            Vector3 rotation = Vector3.zero;
            steerValue.y *= PlayerPrefs.GetInt("VertMultiplier", 1);
            steerValue.z *= PlayerPrefs.GetInt("HorizMultiplier", 1);

            
            rotation = new Vector3(steerValue.y * pitchSens, steerValue.x * rollSens * -1, steerValue.z * yawSens * -1);
            if (!rm.isRaceGoing)
            {
                if (steerValue.magnitude != 0 || moveBool || brakeBool)
                {
                    rm.RaceStart();
                }
            }
            



            gameObject.transform.Rotate(rotation * Time.deltaTime);
            rb.AddForce(transform.up * accel * Time.deltaTime * timeScale);

            if (brakeBool) { rb.AddForce(rb.linearVelocity * -1 * drag * Time.deltaTime * timeScale); }
            else
            {
                rb.AddForce(Vector3.Dot(rb.linearVelocity, transform.right) * transform.right * passiveDragRight * -1 * Time.deltaTime * timeScale);
                rb.AddForce(Vector3.Dot(rb.linearVelocity, transform.forward) * transform.forward * passiveDragUp * -1 * Time.deltaTime * timeScale);
            }
            if (rb.linearVelocity.magnitude < 0.001)
            {
                rb.linearVelocity = Vector3.zero;
            }
            if (quitbool)
            {
                SceneManager.LoadScene("LevelSelect");
            }
        }
        

    }

    
}
