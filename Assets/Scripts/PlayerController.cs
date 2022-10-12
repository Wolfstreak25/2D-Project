 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public ScoreManager scoreManager;
    public GameOverController gameOverController;
    public Animator animator;
    public Collider2D collider2d;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundlayer;
    private bool istouchingGround;
    private float maxYvel;
    public float speed;
    public float jump;
    private Vector3 respawn;
    bool crouch = false;
    
    private Rigidbody2D rigidbody2d;
    
    private void Awake() 
    {
        Debug.Log("Player controller awake");
        respawn = transform.position;
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
    }
    public void KillPlayer()
    {
        HealthManager.health--;
        if(HealthManager.health <= 0)
        {
            Debug.Log("Player Killed");
            Death();
        }
        else
        {
            StartCoroutine(GetHurt());
        }
        
    }
    IEnumerator GetHurt()
    {
        Physics2D.IgnoreLayerCollision(0, 6);
        animator.SetTrigger("EnemyAttack");
        SoundManager.Instance.Play(Sounds.EnemyAttack);
        yield return new WaitForSeconds(3);
        Physics2D.IgnoreLayerCollision(0, 6, false);
    }
    
    public void PickUpObject()
    {
        Debug.Log("Object picked up");
        SoundManager.Instance.Play(Sounds.Collectible);
        scoreManager.IncreaseScore(10);
    }
    public void Update()
    {
        
        istouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundlayer);
        float horizontalspeed = Input.GetAxisRaw("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");
        maxYvel = rigidbody2d.velocity.y ;
        //PlayerAnimations
        PlayerAnimations(horizontalspeed, VerticalInput);
        if(maxYvel <= -10 && istouchingGround != true )
        {
            Debug.Log("falling");
            maxYvel = 0 ;
            Death();
            Spawn(respawn);
        }
        //Character movement
        MoveCharacter(horizontalspeed, VerticalInput);
    }
    private void PlayerAnimations(float horizontal, float vertical)
    {
        //PlayerAnimations
        //WALK
        //RUN
        if (Input.GetKey(KeyCode.LeftShift))
            {
                horizontal = horizontal*4 ;
            }
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        //JUMP
        Jump(vertical);

        //CROUCH
        if (Input.GetKey(KeyCode.LeftControl) && crouch == false)
        {
            Crouch(true);
            crouch = true;
        }
        else if (Input.GetKey(KeyCode.LeftControl) && crouch == true)
        {
            Crouch(false);
            crouch = false;
        }

        //STAFF ATTACK
        if (Input.GetKey(KeyCode.E))
        {
            animator.SetTrigger("Attack");
        }

        //FLIPPING
        Vector3 scale = transform.localScale;
        if(horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        else if(horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }
        transform.localScale = scale;
    }
    public void Crouch(bool crouch)
    {
        animator.SetBool("Crouch", crouch);
    }
    public void Jump(float vertical)
    {    
		if (vertical > 0 && istouchingGround )
        {
            animator.SetTrigger("Jump");            
        }
    }
    public void Death()
    {    
            SoundManager.Instance.Play(Sounds.PlayerDeath);
            animator.SetTrigger("Death");  
            Debug.Log("Player died");
            gameOverController.PlayerDied();
            this.enabled = false;         
    }
    private void MoveCharacter(float horizontal, float vertical)
    {
        //Move charachter Horizontally
        Vector3 position = transform.position;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            position.x += horizontal * speed * 3 * Time.deltaTime;
        }
        else
        {
            position.x += horizontal * speed * Time.deltaTime;
        }
        
        transform.position = position ;

        //Move charachter vertically
        if(vertical > 0 && istouchingGround)
        {   
            maxYvel = 0;
            rigidbody2d.AddForce(new Vector2(0f, jump),ForceMode2D.Force); 
        }
    }
    public void Spawn (Vector3 respawn)
    {
        transform.position = respawn;
        Debug.Log("Player Spawned");
    }
}