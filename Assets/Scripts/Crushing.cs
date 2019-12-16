using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crushing : MonoBehaviour
{
    public GameObject player;

	// Use this for initialization
	void Start ()
    {
        //player = GameObject.Find("player");
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Head")
        {
            Debug.Log("Collapsed");
            var health = player.gameObject.GetComponent<Health>();

            health.TakeDamage(999);
        }
    }
}
