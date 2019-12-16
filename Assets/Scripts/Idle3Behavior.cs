using UnityEngine;

public class Idle3Behavior : StateMachineBehaviour
{
    private int rand;
    private int count = 0;
    [HideInInspector] public int rageCount = 5;

    [HideInInspector] public Vector3 bossScale;
    [HideInInspector] public bool faceLeft = true;
    private GameObject player;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
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

        if (count % rageCount == 0)
        {
            animator.SetTrigger("Ulti");
        }
        var health = animator.GetComponent<Health>();
        if (health.currentHealth <= 0)
        {
            animator.SetTrigger("Die");
        }
        else
        {
            rand = Random.Range(0, 3);

            if (rand == 0)
            {
                animator.SetTrigger("Spear");
            }
            if (rand == 1)
            {
                animator.SetTrigger("Shockwave");
            }
            if (rand == 2)
            {
                animator.SetTrigger("Dash");
            }
        }
    }
}
