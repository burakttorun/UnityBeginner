using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody enemyRB;
    private GameObject player;
    public float speed=3;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = gameObject.GetComponent<Rigidbody>();
        player = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRB.AddForce(lookDirection * speed);

        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }
}
