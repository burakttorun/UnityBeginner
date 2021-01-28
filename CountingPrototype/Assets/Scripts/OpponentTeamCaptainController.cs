using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentTeamCaptainController : NpcController, IMoveToPlayer
{
    Transform playerTransform;


    public float moveSpeedDirectionZ;

    float followingDistance = 6f;
    bool isChangeDirection = false;

    [SerializeField]
    ParticleSystem particleExplosion;

    float destroyBound = -3f;

    GameManager gameManager;
    public void MoveToPlayer() //Method for the captain to run towards the player.
    {
        base.AnimatorController(0.75f);
        if (!isChangeDirection)
        {
            if (transform.position.z >= followingDistance)
                transform.LookAt(playerTransform);
            else
            {
                transform.LookAt(Vector3.forward);
                isChangeDirection = true;
            }
        }

        transform.Translate(Vector3.forward * moveSpeedDirectionZ * Time.deltaTime);
    }

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            MoveToPlayer();
            if (transform.position.z < destroyBound)
                Destroy(gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            particleExplosion.Play();
        }
    }
}
