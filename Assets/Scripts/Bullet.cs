using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;

    public float moveSpeed = 14f;
    private bool bossHit = false;

    Rigidbody2D rb;
    GameObject player;
    Vector2 moveDirection;

	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        moveDirection = (player.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 10f);

        if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3 (-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            var health = other.gameObject.GetComponent<Health>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }

        if (gameObject.tag == "Bullet")
        {
            if (other.name == "Portal 1")
            {
                bossHit = true;
                transform.localScale = new Vector3(-transform.localScale.x, -transform.localScale.y, transform.localScale.z);
            }
        }

        if (other.tag == "Boss" && bossHit == true)
        {
            var health = other.gameObject.GetComponent<Health>();

            Animator anim = other.GetComponent<Animator>();
            anim.SetTrigger("gethit");

            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }

        if (other.tag == "Enemy" && bossHit == true)
        {
            var health = other.gameObject.GetComponent<Health>();

            if (health != null)
            {
                health.TakeDamage(damage);
            }
            Destroy(gameObject);
        }

        if (other.name == "Wall")
        {
            Destroy(gameObject);
        }
	}
}
