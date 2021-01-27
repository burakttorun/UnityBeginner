using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandom : MonoBehaviour
{
    
    public float moveSpeedDirectionX; 
    protected Animator npcAnim;
    
    public void Awake()
    {
        npcAnim = GetComponent<Animator>();
    }

    protected void MoveAxisX(float randomDirection)
    {
        transform.Translate(Vector3.right * moveSpeedDirectionX * randomDirection *Time.deltaTime);
       
    }

    protected void DetermineDistance(float maxDistance)
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

    public void CatchAnimation(bool isDeath)
    {
        npcAnim.SetBool("Death_b", isDeath);
        npcAnim.SetInteger("DeathType_int", 1);
    }

    public void AnimatorController(float npcSpeed)
    {
        npcAnim.SetFloat("Speed_f", npcSpeed);
    }
}

public interface IMoveToPlayer
{
    void MoveToPlayer();

}