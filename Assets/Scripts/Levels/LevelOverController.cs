using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelOverController : MonoBehaviour
{
    private void Awake() 
    {
        Debug.Log("Level controller awake");
    }
    public NextLevelController nextlevel;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        
        Debug.Log("Level Trigger");
        //if(collision.gameObject.CompareTag("Player"))
        if(collision.gameObject.GetComponent<PlayerController>() != null)
        {
            //Level is Over;
            Debug.Log("level Finished by The Player");
           //LevelManager.Instance.SetLevelStatus(SceneManager.GetActiveScene().name, LevelStatus.Completed);
            LevelManager.Instance.MarkCurrentComplete();
            nextlevel.LevelComplete();
        }        
    }
}
