using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit2Behavior : StateMachineBehaviour
{

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        FindObjectOfType<AudioManager>().Play("Inferno GetHit");

        var health = animator.GetComponent<Health>();

        if (health.currentHealth <= 0)
        {
            GameObject boss = GameObject.Find("Inferno");

            boss.GetComponent<Collider2D>().enabled = false;
            boss.GetComponent<Damage>().enabled = false;

            animator.SetTrigger("die");
        }
    }
}
