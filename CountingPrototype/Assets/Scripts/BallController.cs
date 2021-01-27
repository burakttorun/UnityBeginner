using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    float ballSpeed;
    float time;
    float deActiveTime=3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= deActiveTime)
        {
            gameObject.SetActive(false);
            time = 0;
        }
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
            other.gameObject.GetComponent<MoveRandom>().CatchAnimation(true);
            other.gameObject.GetComponent<OpponentTeamPlayerContoller>().moveSpeedDirectionZ = 0;
            other.gameObject.GetComponent<OpponentTeamPlayerContoller>().moveSpeedDirectionX = 0;
            Destroy(other.gameObject, 0.9f);
        }
        if (other.CompareTag("OpponentTeamCaptain"))
        {
            other.gameObject.GetComponent<MoveRandom>().CatchAnimation(true);
            other.gameObject.GetComponent<OpponentTeamCaptainController>().moveSpeedDirectionZ = 0;
            Destroy(other.gameObject, 0.9f);
        }

        if (other.CompareTag("Teammate"))
        {
            
            other.gameObject.GetComponent<MoveRandom>().moveSpeedDirectionX = 0;
            
        }


        gameObject.SetActive(false);
    }


}
