using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    // Class variables
    [SerializeField] private float horsePower = 0.0f;
    [SerializeField] private float turnSpeed = 45.0f;
    [SerializeField] private float horizontalInput;
    [SerializeField] private float forwardInput;
    [SerializeField] private GameObject centerOfMass;
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private float speed;

    
    private Rigidbody playerRb;

    public KeyCode switchKey;
    public string inputID;
    public Camera MainCamera;
    public Camera FirstPersonCamera;
    // Start is called before the first frame update
    void Start()
    {
        // Grab Rigibody component
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
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
        // transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
        // Move the vehicle based on the horizontal input
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

        // Update the speedometer
        speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f); // 3.6 for kph
        speedometerText.SetText("Speed: " + speed + " mph");
    }
}
