using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileOrange : MonoBehaviour
{
    GameObject portal2;
    GameObject portal1;

    void Start()
    {
        portal1 = GameObject.Find("Portal 1");
        portal2 = GameObject.Find("Portal 2");
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            portal1.GetComponent<TeleportObject>().allowOrange = true;
            FindObjectOfType<AudioManager>().Play("Portal2");
            portal2.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }

        if (other.name == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
