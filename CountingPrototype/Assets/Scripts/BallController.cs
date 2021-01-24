using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    float ballSpeed;
    float maxTorque = 10f;
    Rigidbody BallRb { get { return GetComponent<Rigidbody>(); } }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        BallRb.AddForce(Vector3.forward * ballSpeed * Time.deltaTime);
        BallRb.AddRelativeTorque(maxTorque, 0, 0, ForceMode.Impulse);
    }
}
