using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float moveSpeed;
    float maxDistance = 25f;
    float moveAxisX;
    float playerWalkAnimLimit = 0.1f;
    Animator playerAnim;
    [SerializeField]
    Transform throwingBallPos;
    float repeatTime = 1.5f;
    float time=2;
    // Start is called before the first frame update
    void Start()
    {
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time > repeatTime)
        {
            PlayerShoot();    
        }
        else
        {
            playerAnim.SetInteger("WeaponType_int", 0);
        }
        PlayerMovement();
        DetermineDistance();

        
    }
    private void PlayerShoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject pooledBall = ObjectPooler.SharedInstance.GetPooledObject();
            if (pooledBall != null)
            {
                playerAnim.SetInteger("WeaponType_int", 10);
                pooledBall.SetActive(true);
                pooledBall.transform.position = throwingBallPos.position;
                time = 0;
            }

        }

    }

    private void PlayerMovement()
    {
        moveAxisX = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * moveAxisX * moveSpeed * Time.deltaTime);
        if (Mathf.Abs(moveAxisX) >= playerWalkAnimLimit)
            playerAnim.SetFloat("Speed_f", 0.5f);
        else
            playerAnim.SetFloat("Speed_f", 0.15f);

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
