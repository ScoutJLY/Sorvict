using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CooldownBehavior : StateMachineBehaviour
{
    GameObject boss;

	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss = GameObject.Find("Tortura_Head");
        boss.GetComponent<Collider2D>().enabled = true;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
