using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorturaHead : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public GameObject boss;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "GroundCheck")
        {
            FindObjectOfType<AudioManager>().Play("Tortura Impact");

            rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y/2);
            anim.SetTrigger("GetHit");

            var health = boss.GetComponent<Health>();

            if (health != null)
            {
                health.TakeDamage(1);
            }
        }
    }
}
