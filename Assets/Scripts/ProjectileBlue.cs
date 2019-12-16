using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBlue : MonoBehaviour
{
    GameObject portal1;

    void Start()
    {
        portal1 = GameObject.Find("Portal 1");
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Ground")
        {
            portal1.GetComponent<TeleportObject>().allowBlue = true;
            FindObjectOfType<AudioManager>().Play("Portal1");
            portal1.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }

        if (other.name == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
