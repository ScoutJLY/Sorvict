using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spear : MonoBehaviour
{
    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;

    public float moveSpeed = 14f;

    Rigidbody2D rb;
    GameObject player, portal1, portal2;
    Vector2 moveDirection;

    public GameObject spearParticle;

    //private Transform defaultPos;

    // Use this for initialization
    void Start()
    {
        //defaultPos = new Vector3(11.5f, 6f, 0f);
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        moveDirection = (player.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        Destroy(gameObject, 10f);
        portal1 = GameObject.Find("Portal 1");
        portal2 = GameObject.Find("Portal 2");

        if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = -transform.localScale;
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

        if (other.name == "Portal 1")
        {
            var portal = portal1.GetComponent<TeleportObject>();
            Instantiate(spearParticle, portal1.transform.position, Quaternion.identity);
            portal.allowBlue = false;
            portal1.transform.position = new Vector3(-10f, -50f, 0f);
        }

        if (other.name == "Portal 2")
        {
            var portal = portal1.GetComponent<TeleportObject>();
            Instantiate(spearParticle, portal2.transform.position, Quaternion.identity);
            portal.allowOrange = false;
            portal2.transform.position = new Vector3(-10f, -50f, 0f);
        }
    }
}
