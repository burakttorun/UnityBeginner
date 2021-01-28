using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentTeamPlayerController : NpcController, IMoveToPlayer
{
   
    public float moveSpeedDirectionZ;
    float changeDirectionTime = 2f;
    float time=2;
    int randomDirection = 0;
    float spawnRangeX = 30;
    float destroyBound = -3f;
    [SerializeField]
    ParticleSystem particleExplosion;
    GameManager gameManager;
    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
    public void MoveToPlayer() //Method of moving towards the player.
    {
        transform.Translate(Vector3.forward * moveSpeedDirectionZ *Time.deltaTime );
        base.AnimatorController(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            time += Time.deltaTime;

            if (time > changeDirectionTime)
            {
                randomDirection = Random.Range(-1, 2);
                time = 0;
            }

            if (transform.position.z < destroyBound)
                Destroy(gameObject);
            base.MoveAxisX(randomDirection);
            base.DetermineDistance(spawnRangeX);
            MoveToPlayer();
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        //The method that creates an explosion effect when the ball hits the object to which the script is attached.
        if (other.CompareTag("Ball"))
        {
            particleExplosion.Play();
        }
    }
}
