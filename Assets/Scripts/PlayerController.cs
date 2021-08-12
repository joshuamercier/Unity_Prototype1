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
    [SerializeField] private TextMeshProUGUI rpmText;
    [SerializeField] private float speed;
    [SerializeField] private float rpm;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;


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
        playerRb.centerOfMass = centerOfMass.transform.localPosition;
        // Start with traditional camera enabled
        MainCamera.enabled = true;
        FirstPersonCamera.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If player presses camera change button then switch cameras
        if (Input.GetKeyDown(switchKey) == true)
        {
            MainCamera.enabled = !MainCamera.enabled;
            FirstPersonCamera.enabled = !FirstPersonCamera.enabled;
        }

        // Grab player inputs
        horizontalInput = Input.GetAxis("Horizontal" + inputID);
        forwardInput = Input.GetAxis("Vertical" + inputID);

        if (IsOnGround())
        {
            // Update the speedometer
            speed = Mathf.Round(playerRb.velocity.magnitude * 2.237f); // 3.6 for kph
            speedometerText.SetText("Speed: " + speed + " mph");

            //Update the RPM
            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.text = "RPM: " + rpm;
        }

    }

    private void FixedUpdate()
    {
        if (IsOnGround())
        {
            foreach (WheelCollider wheel in allWheels)
            {
                wheel.motorTorque = 0.0001f;
            }

            // Move the vehicle forward based on vertical input
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
            // Move the vehicle based on the horizontal input
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);
        }
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if (wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }

        return wheelsOnGround == allWheels.Count;
    }
}
