using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    [SerializeField]
    float moveSpeed;
    float maxDistance = 25f;
    float moveAxisX;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        moveAxisX = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * moveAxisX * moveSpeed * Time.deltaTime);
        DetermineDistance();
    }

    protected void DetermineDistance()
    {
        if (transform.position.x <= -maxDistance)
        {
            transform.position = new Vector3(-maxDistance, transform.position.y, transform.position.z);
        }
        if (transform.position.x >= maxDistance)
        {
            transform.position = new Vector3(maxDistance, transform.position.y, transform.position.z);
        }
    }
}
