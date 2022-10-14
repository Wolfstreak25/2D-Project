using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision) 
    {
        Debug.Log("collectible Trigger");
        //if(collision.gameObject.CompareTag("Player"))
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //collected;
            Debug.Log("The Player picked collectible ");
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            playerController.PickUpObject();
            Destroy(gameObject);
        }
        
    }
}
