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
    Animator opponentPlayerCaptainAnim;

    public void AnimatorController()
    {
        opponentPlayerCaptainAnim.SetFloat("Speed_f", 0.75f);
    }
    public void MoveToPlayer()
    {
        AnimatorController();
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
        opponentPlayerCaptainAnim = GetComponent<Animator>();
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
    }
}
