using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerController : MonoBehaviour
{
    //Private Variable
    [SerializeField] private float speed;
    [SerializeField] private float horsePower = 0;
    private const float turnSpeed = 50f;
    private float horizontalInput;
    private float forwardInput;

    [SerializeField] GameObject centerOfMass;
    private Rigidbody playerRb;
    [SerializeField] private TextMeshProUGUI speedometerText;
    [SerializeField] private TextMeshProUGUI rpm;

    [SerializeField] private List<WheelCollider> allWheels;
    [SerializeField] private int wheelsOnGround;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (IsOnGround())
        {
            //This is where we get player input
            horizontalInput = Input.GetAxis("Horizontal");
            forwardInput = Input.GetAxis("Vertical");

            //Move to vehicle forward.
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);
            //We turn the vehicle.
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);         
        }
        speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
        speedometerText.text = "Speed: " + speed + " km/h";
        rpm.text = "RPM: " + (speed % 30) * 40;
    }

    bool IsOnGround()
    {
        wheelsOnGround = 0;

        foreach (var wheel in allWheels)
        {
            if (wheel.isGrounded)
                wheelsOnGround++;
        }

        if (wheelsOnGround == 4)
            return true;
        else
            return false;
    }
}
