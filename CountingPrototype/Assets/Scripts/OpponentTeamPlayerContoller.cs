using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentTeamPlayerContoller : MoveRandom , IMoveToPlayer
{
   
    public float moveSpeedDirectionZ;
    float changeDirectionTime = 2f;
    float time=2;
    int randomDirection = 0;
    float spawnRangeX = 30;
    [SerializeField]
    ParticleSystem particleExplosion;

    public void MoveToPlayer()
    {
        transform.Translate(Vector3.forward * moveSpeedDirectionZ *Time.deltaTime );
        base.AnimatorController(0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > changeDirectionTime)
        {
            randomDirection = Random.Range(-1, 2);
            time = 0;
        }

        base.MoveAxisX(randomDirection);
        base.DetermineDistance(spawnRangeX);
        MoveToPlayer();
     
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            particleExplosion.Play();
        }
    }
}
