using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   
    public int max_hp = 100;
    public int HP;
    public float movespeed = 5f;
    private Rigidbody2D rb;
    private bool facing_right = true;

    public Transform attackpoint;
    public float attackrange = 0.5f;
    public LayerMask enemyLayers;
    private bool is_moving = false;
    private bool isFlash = false;
    private Animator animator;
    public PlayerHealthbar healthbar;
    public static PlayerMovement instance;
    public int attack_damage = 20;
    
    Vector2 movement;
    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        healthbar.SetMaxHealth(max_hp);
        HP = max_hp;
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
        if(Input.GetKeyDown(KeyCode.Space) && !isFlash) 
        {   
            animator.SetTrigger("Attack");
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackpoint.position,attackrange,enemyLayers);
            foreach(Collider2D enemy in hitEnemies)
            {
                if(enemy.name == "Boss")
                {
                    enemy.GetComponent<Boss>().TakeDamage(attack_damage);
                }
                else
                {
                    enemy.GetComponent<Enemy>().TakeDamage(attack_damage);
                }
            }
        }
    }
    public void TakeDamage(int damage)
    {
        if(!isFlash)
        {
            HP -= damage;
            healthbar.SetHealth(HP);
            if(HP<=0)
            {   
                AudioManager.instance.PlayExplosion();
                animator.Play("Spider_death");
                ButtonControl.instance.GameOver();
                
            }
            AudioManager.instance.PlayTakeHit();
        isFlash = true;
        StartCoroutine(flash());
        }
        
        
    }
    IEnumerator flash()
    {
        for(int i = 0; i< 10; i++)
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.5f);
            yield return new WaitForSeconds(0.1f);
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(0.1f);
        }
        isFlash = false;
    }
    public void PlayAttackSound()
    {
        AudioManager.instance.Playplayerattack();
    }

       public void AddHP(int hp_gain)
    {
        if(HP<max_hp)
        {   
            AudioManager.instance.PlayNoice();
            HP += hp_gain;
            healthbar.SetHealth(HP);
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackpoint.position,attackrange);
    }
}

