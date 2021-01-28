using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcController : MonoBehaviour
{
    
    public float moveSpeedDirectionX; 
    protected Animator npcAnim;
    
    public void Awake()
    {
        npcAnim = GetComponent<Animator>();
    }

    //Method to move connected objects randomly along the x-axis.
    protected void MoveAxisX(float randomDirection)
    {
        transform.Translate(Vector3.right * moveSpeedDirectionX * randomDirection *Time.deltaTime);
       
    }
    //The part that determines the boundary of the objects on the x-axis.
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

    //The code that starts the catch animation for characters.
    public void CatchAnimation(bool isDeath)
    {
        npcAnim.SetBool("Death_b", isDeath);
        npcAnim.SetInteger("DeathType_int", 1);
    }

    //Control of walking and running animations
    public void AnimatorController(float npcSpeed)
    {
        npcAnim.SetFloat("Speed_f", npcSpeed);
    }
}

public interface IMoveToPlayer
{
    void MoveToPlayer();

}