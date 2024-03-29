using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public bool isFlipped = true;
    public static Enemy instance;
    public Animator animator;

    public int HP = 100;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        animator = animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
    }
    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f,180f,0f);
            isFlipped = false;
        }
        else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f,180,0f);
            isFlipped = true;
        }
    }
    public void TakeDamage(int damage)
    {
        HP -= damage;
        if(HP <= 0)
        {
            AudioManager.instance.PlayExplosion();
            animator.Play("Spider_death");
        }
        StartCoroutine(VisualIndicator(Color.gray));
    }



    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {   
            AudioManager.instance.PlayBlast();
            animator.SetTrigger("Attack");
        }
    }   
}
