using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : StateMachineBehaviour
{   
    Transform player;
    Rigidbody2D rb;
    public float speed = 2.5f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       rb = animator.GetComponent<Rigidbody2D>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      if(Vector2.Distance(player.position,rb.position) >= 1.4)
      {
         Vector2 target = new Vector2(player.position.x,player.position.y);
         Vector2 new_position = Vector2.MoveTowards(rb.position,target,speed * Time.fixedDeltaTime);
         rb.MovePosition(new_position);
      }
    //   else
    //   {
    //      animator.SetTrigger("Smash");
    //   }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
         animator.ResetTrigger("Attack");
    }

   
}
