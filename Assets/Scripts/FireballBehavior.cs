using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballBehavior : StateMachineBehaviour
{
    public GameObject bullet;

    public float fireRate = 1f;
    public float nextFire;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        nextFire = Time.time;
    }

	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, animator.transform.position, animator.transform.rotation);
            //Inferno Fireball Cast
            FindObjectOfType<AudioManager>().Play("Inferno Fireball Cast");
            nextFire = Time.time + fireRate;
        }
    }
}
