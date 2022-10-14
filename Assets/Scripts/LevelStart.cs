using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class LevelStart : MonoBehaviour
{
    
    private Vector3 spawn;
    public GameObject Player;
    
    private void Awake() 
    {
        
        Debug.Log("Level Start");
        SoundManager.Instance.Play(Sounds.Start);
        spawn = transform.position;
        Player.transform.position = spawn ;
        Debug.Log("Player Spawned");
    }
}
