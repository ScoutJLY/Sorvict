using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash2Behavior : StateMachineBehaviour
{
    public float moveSpeed = 15f;
    private bool bossHit = false;

    Rigidbody2D rb;
    GameObject player;
    Vector2 moveDirection;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.Find("Player");
        var idle = animator.GetBehaviour<Idle2Behavior>();

        if (player.transform.position.x > animator.transform.position.x && idle.faceLeft == true)
        {
            idle.faceLeft = false;

            idle.bossScale = animator.transform.localScale;
            idle.bossScale.x *= -1;
            animator.transform.localScale = idle.bossScale;
        }
        if (player.transform.position.x < animator.transform.position.x && idle.faceLeft == false)
        {
            idle.faceLeft = true;

            idle.bossScale = animator.transform.localScale;
            idle.bossScale.x *= -1;
            animator.transform.localScale = idle.bossScale;
        }

        rb = animator.GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        moveDirection = (player.transform.position - animator.transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rb.velocity = new Vector2(0, 0);
    }
}
