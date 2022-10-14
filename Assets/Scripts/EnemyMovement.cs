using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [HideInInspector]
    public bool mustPatrol;
    public float walkSpeed;
    public Transform PlatformDetect;
    public LayerMask Layer;
    private bool mustFlip;
    public Collider2D EnemyCollider;
    public Rigidbody2D rigidBody2D;
    
    void Start()
    {
        mustPatrol = true;
    }
    private void FixedUpdate() 
    {
        if(mustPatrol)
        {
            mustFlip = !Physics2D.OverlapCircle(PlatformDetect.position, 0.1f, Layer);
        }
    }
    void Update()
    {
        if(mustPatrol)
        {
            Patrol();
        }
    }
    void Patrol()
    {
        if (mustFlip)
        {
            Flip();
        }
        rigidBody2D.velocity=new Vector2(walkSpeed * Time.fixedDeltaTime, rigidBody2D.velocity.y);
    }
    void Flip()
    {
        mustPatrol = false;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustPatrol = true;
    }
}
