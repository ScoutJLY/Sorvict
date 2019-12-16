using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump2Behavior : StateMachineBehaviour
{
    public float moveSpeed = 1f;

    Rigidbody2D rb;
    GameObject player;
    Vector2 moveDirection;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        /*
        rb = animator.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        moveDirection = (player.transform.position - animator.transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);  
        */
        player = GameObject.Find("Player");
        moveDirection = new Vector2(player.transform.position.x, 41.47f);

    }

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, moveDirection, moveSpeed);
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FindObjectOfType<AudioManager>().Play("Tortura Impact");
    }
}
