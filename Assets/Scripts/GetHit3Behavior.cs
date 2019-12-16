﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit3Behavior : StateMachineBehaviour
{
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FindObjectOfType<AudioManager>().Play("Charles GetHit");

        var health = animator.GetComponent<Health>();

        if (health.currentHealth == 3)
        {
            animator.transform.GetChild(0).gameObject.SetActive(true);

            var idle = animator.GetBehaviour<Idle3Behavior>();
            idle.rageCount = 7;

            var dash = animator.GetBehaviour<Dash3Behavior>();
            dash.moveSpeed += 5;
        }

        health.TakeDamage(1);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

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