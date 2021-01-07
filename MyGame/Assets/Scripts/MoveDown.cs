using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    public float speed = 5.0f;
    private float zDestroy = -10.0f;
    private Rigidbody objectRB;
    // Start is called before the first frame update
    void Start()
    {
        objectRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(Vector3.back * speed*Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        if (transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }

        //if(gameObject.name == "Enemy4")
        //{
        //    objectRB.AddTorque(new Vector3(30, 30, 30));
        //}
    }
}
