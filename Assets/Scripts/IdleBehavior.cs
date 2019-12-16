using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehavior : StateMachineBehaviour
{
    private int rand;
    private Rigidbody2D rb;
    private GameObject player;
    [HideInInspector] public Vector3 bossScale;
    [HideInInspector] public bool faceLeft = true;
    private bool rageMode = false;
    private int rageThreshold;


    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var health = animator.GetComponent<Health>();
        rageThreshold = health.startingHealth;
        //Debug.Log("Rage threshold is " + rageThreshold / 2);
        //Debug.Log(health.currentHealth);
        if (health.currentHealth <= rageThreshold / 2 && !rageMode)
        {
            Debug.Log("Rage Mode");
            var rage = animator.GetBehaviour<DashBehavior>();
            rage.moveSpeed += 5;
            Debug.Log(rage.moveSpeed);
            rageMode = true;
            animator.transform.GetChild(0).gameObject.SetActive(true);
        }

        rand = Random.Range(0, 2);

        if (rand == 0)
        {
            animator.SetTrigger("fireball");
        }
        else
        {
            animator.SetTrigger("charge");
        }

        player = GameObject.Find("Player");

        rb = animator.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 0);

        if (health.currentHealth <= 0)
        {
            animator.SetTrigger("die");
        }
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
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

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
