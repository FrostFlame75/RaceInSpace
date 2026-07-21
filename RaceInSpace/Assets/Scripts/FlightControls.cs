using Unity.VisualScripting;
using UnityEngine;

public class FlightControls : MonoBehaviour
{
    // Importing variables
    [SerializeField] bool vertInvert;
    [SerializeField] bool horizInvert;
    [SerializeField] float turnSens;
    float horizInput;
    float vertInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Get current input values every frame
        horizInput = Input.GetAxis("Horizontal");
        vertInput = Input.GetAxis("Vertical");

        // Inverted controls bit
        if (horizInvert) { horizInput *= -1; }
        if (vertInvert) { vertInput *= -1; }

        // Convert to Rotation
        float horizRotate = 10 * turnSens * horizInput;
        float vertRotate = 10 * turnSens * vertInput;
        Vector3 rotation = new (0.0f, horizRotate, vertRotate);
        gameObject.transform.Rotate(rotation * Time.deltaTime);

    }

    
}
