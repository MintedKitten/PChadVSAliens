using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_walk : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    public float speed = 2.5f;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
       rb = animator.GetComponent<Rigidbody2D>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    { 
      
      if(Vector2.Distance(player.position,rb.position) >= 2.7)
      {
         Vector2 target = new Vector2(player.position.x,player.position.y);
         Vector2 new_position = Vector2.MoveTowards(rb.position,target,speed * Time.fixedDeltaTime);
         rb.MovePosition(new_position);
      }
      else
      {
         animator.SetTrigger("Smash");
      }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("Attack");
       animator.ResetTrigger("Smash");
    }

    
}
