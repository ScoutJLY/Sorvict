using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle2Behavior : StateMachineBehaviour
{
    private int rand;
    private int count = 0;

    [HideInInspector] public Vector3 bossScale;
    [HideInInspector] public bool faceLeft = true;
    private GameObject player;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.Find("Player");

        if (player.transform.position.x > animator.transform.position.x && faceLeft == true)
        {
            faceLeft = false;

            bossScale = animator.transform.localScale;
            bossScale.x *= -1;
            animator.transform.localScale = bossScale;
        }
        if (player.transform.position.x < animator.transform.position.x && faceLeft == false)
        {
            faceLeft = true;

            bossScale = animator.transform.localScale;
            bossScale.x *= -1;
            animator.transform.localScale = bossScale;
        }

        count++;
        if (count % 3 == 0)
        {
            animator.SetTrigger("Cooldown");
        }
        else
        {
            rand = Random.Range(0, 3);

            if (rand == 0)
            {
                animator.SetTrigger("Jump");
            }
            if (rand == 1)
            {
                animator.SetTrigger("Shockwave");
            }
            else
            {
                animator.SetTrigger("Kick");
            }
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (player.transform.position.x > animator.transform.position.x && faceLeft == true)
        {
            faceLeft = false;

            bossScale = animator.transform.localScale;
            bossScale.x *= -1;
            animator.transform.localScale = bossScale;
        }
        if (player.transform.position.x < animator.transform.position.x && faceLeft == false)
        {
            faceLeft = true;

            bossScale = animator.transform.localScale;
            bossScale.x *= -1;
            animator.transform.localScale = bossScale;
        }
    } 
}
