using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentTeamCaptainController : MonoBehaviour , IMoveToPlayer
{
    Transform playerTransform;

    [SerializeField]
    float moveSpeed;

    float followingDistance = 6f;
    bool isChangeDirection = false;
    public void MoveToPlayer()
    {
        if(!isChangeDirection)
        {
            if (transform.position.z >= followingDistance)
                transform.LookAt(playerTransform);
            else
            {
                transform.LookAt(Vector3.forward);
                isChangeDirection = true;
            }
        }
        
        transform.Translate(Vector3.forward*moveSpeed*Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }
}
