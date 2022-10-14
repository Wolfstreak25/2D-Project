using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform Player;
    private Vector3 Position;
    void Update()
    {
        Position = Player.transform.position + new Vector3(0, 3, -15);
        transform.position = Position;
    }
}
