using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandom : MonoBehaviour
{
    [SerializeField]
    float moveSpeedDirectionX;
    float maxDistance=30f;
    protected void MoveAxisX(float randomDirection)
    {
        transform.Translate(Vector3.right * moveSpeedDirectionX * randomDirection *Time.deltaTime);
    }

    protected void DetermineDistance()
    {
        if(transform.position.x<=-maxDistance)
        {
            transform.position = new Vector3(-maxDistance, transform.position.y, transform.position.z);
        }
        if(transform.position.x >= maxDistance)
        {
            transform.position = new Vector3(maxDistance, transform.position.y, transform.position.z);
        }
    }
}

public interface IMoveToPlayer
{
    void MoveToPlayer();

    void AnimatorController();
}