using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Class variables
    private float speed = 20.0f;
    private float turnSpeed = 45.0f;
    private float horizontalInput;
    private float forwardInput;

    public KeyCode switchKey;
    public string inputID;
    public Camera MainCamera;
    public Camera FirstPersonCamera;
    // Start is called before the first frame update
    void Start()
    {
        // Start with traditional camera enabled
        MainCamera.enabled = true;
        FirstPersonCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If player presses camera change button then switch cameras
        if(Input.GetKeyDown(switchKey) == true)
        {
            MainCamera.enabled = !MainCamera.enabled;
            FirstPersonCamera.enabled = !FirstPersonCamera.enabled;
        }
        // Grab player inputs
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        // Move the vehicle forward based on vertical input
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        // Move the vehicle based on the horizontal input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
    }
}
