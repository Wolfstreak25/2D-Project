using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator EnemyAnime;
    private void Awake() 
    {
        Debug.Log("Enemy controller awake");
    }
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Debug.Log("Enemy Trigger");
        //if(collision.gameObject.CompareTag("Player"))
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //Enemt Attacked;
            Attack();
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.KillPlayer();
        }
        
    }
    public void Attack()
    {
        EnemyAnime.SetTrigger("Attack");
        Debug.Log("Chomper Attacked ");
    }
}
