using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{ 
    [SerializeField]
    float moveSpeed;

    float moveAxisX;
    // Start is called before the first frame update
    void Start()
    {
        moveAxisX = Input.GetAxis("Horizontal");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * moveAxisX * moveSpeed * Time.deltaTime);
    }
}
