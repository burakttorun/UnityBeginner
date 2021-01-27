using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeammateController : MoveRandom
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
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > changeDirectionTime)
        {   
            if(time>changeAnimTime)
                gameObject.GetComponent<MoveRandom>().CatchAnimation(false);
            randomDirection = Random.Range(-1, 2);
            time = 0;
        }

        base.MoveAxisX(randomDirection);
        base.AnimatorController(npcSpeed);
        base.DetermineDistance(spawnRangeX);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            foreach (var item in particleFireworks)
            {
                item.Play();
            }
            gameObject.GetComponent<MoveRandom>().CatchAnimation(true);
            StartCoroutine("DelayDisplacement");
            other.gameObject.SetActive(false);
        }
    }

    IEnumerator DelayDisplacement()
    { 
        yield return new WaitForSeconds(1.5f);
        transform.position = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, positionZ);
    }

  
}
