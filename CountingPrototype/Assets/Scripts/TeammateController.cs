using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeammateController : NpcController
{
    float npcSpeed = 0.5f;
    float time = 5;
    float changeDirectionTime = 2.5f;
    float changeAnimTime = 1;
    float randomDirection;
    float spawnRangeX = 25f;
    float positionZ = 42;
    [SerializeField]
    ParticleSystem[] particleFireworks;
    GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {


            time += Time.deltaTime;

            if (time > changeDirectionTime)
            {
                if (time > changeAnimTime)
                    gameObject.GetComponent<NpcController>().CatchAnimation(false);
                randomDirection = Random.Range(-1, 2);
                time = 0;
            }

            base.MoveAxisX(randomDirection);
            base.AnimatorController(npcSpeed);
            base.DetermineDistance(spawnRangeX);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            foreach (var item in particleFireworks)
            {
                item.Play(); //Fireworks effect starts when teammate catches the ball.
            }
            gameObject.GetComponent<NpcController>().CatchAnimation(true);
            StartCoroutine("DelayDisplacement");
            other.gameObject.SetActive(false);
        }
    }

    //Method for delaying teammate relocation.
    IEnumerator DelayDisplacement()
    { 
        yield return new WaitForSeconds(1.5f);
        transform.position = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, positionZ);
    }

  
}
