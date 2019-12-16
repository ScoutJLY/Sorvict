using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieBehavior : StateMachineBehaviour
{
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var die = animator.GetComponent<BossLevel>();
        die.isDead = true;
    }
}
