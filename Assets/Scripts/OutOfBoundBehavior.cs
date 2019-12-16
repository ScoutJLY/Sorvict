using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundBehavior : StateMachineBehaviour
{
    public float minDistance;
    public float maxDistance;
    Rigidbody2D rb;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb = animator.GetComponent<Rigidbody2D>();

        if (animator.transform.position.x < minDistance)
        {
            animator.transform.position = new Vector2(animator.transform.position.x + 2, animator.transform.position.y);
            rb.velocity = new Vector2(0,0);
        }

        if (animator.transform.position.x > maxDistance)
        {
            animator.transform.position = new Vector2(animator.transform.position.x - 2, animator.transform.position.y);
            rb.velocity = new Vector2(0, 0);
        }
    }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	//override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
