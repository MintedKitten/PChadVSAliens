using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 5f;
    private Rigidbody2D rb;
    private bool facing_right = true;

    public Transform attackpoint;
    public float attackrange = 0.5f;
    public LayerMask enemyLayers;
    private bool is_moving = false;
    private Animator animator;
    

    Vector2 movement;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal",movement.y);
        animator.SetFloat("Vertical",movement.x);
        animator.SetBool("is_moving",is_moving);
        Attack();
        
    }

    void FixedUpdate()
    {
        
        Move();
        FilpSprite();
        
    }

    void Move()
    {
        rb.MovePosition(rb.position + movement * movespeed * Time.fixedDeltaTime);
        is_moving = (Input.GetAxisRaw("Horizontal")!=0 || Input.GetAxisRaw("Vertical")!=0); 
    }

    void FilpSprite()
    {
        
        if (Input.GetAxisRaw("Horizontal") < 0 && facing_right)
        {
            FilpRotation();
        }
        else if (Input.GetAxisRaw("Horizontal") > 0 && !facing_right)
        {
            FilpRotation();
        }
    }
    void FilpRotation()
    {
        facing_right =! facing_right;
        transform.Rotate(0f,180f,0f);
    }

    void Attack()
    {   
        if(Input.GetKeyDown(KeyCode.Space))
        {   
            animator.SetTrigger("Attack");

            // Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position,attackrange,enemyLayers);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackpoint.position,attackrange);
    }
}

