using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    float ballSpeed;  
    int goalValue=6;
    GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * ballSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tribune"))
        {
            gameObject.SetActive(false);
        }

        if (other.CompareTag("OpponentTeamPlayer"))
        {
            gameManager.MakeScore(-goalValue); //Scores.
            other.gameObject.GetComponent<NpcController>().CatchAnimation(true); //Runs the animation.
            //Stops the movement of the object it strikes.
            other.gameObject.GetComponent<OpponentTeamPlayerController>().moveSpeedDirectionZ = 0;
            other.gameObject.GetComponent<OpponentTeamPlayerController>().moveSpeedDirectionX = 0;
            Destroy(other.gameObject, 0.9f); //The object hit. It disappears after 0.9 seconds.
        }
        if (other.CompareTag("OpponentTeamCaptain"))
        {
            gameManager.MakeScore(-goalValue);//Scores.
            other.gameObject.GetComponent<NpcController>().CatchAnimation(true);//Runs the animation.
            //Stops the movement of the object it strikes.
            other.gameObject.GetComponent<OpponentTeamCaptainController>().moveSpeedDirectionZ = 0;
            Destroy(other.gameObject, 0.9f); //The object hit. It disappears after 0.9 seconds.
        }

        if (other.CompareTag("Teammate"))
        {
            gameManager.MakeScore(goalValue);//Scores.
            other.gameObject.GetComponent<NpcController>().moveSpeedDirectionX = 0;
            
        }


        gameObject.SetActive(false); //Turns off the visibility of the ball.
    }

}
