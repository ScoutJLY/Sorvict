using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour {

    public GameObject Door;
    public GameObject lightgreen;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "door block")
        {
            lightgreen.GetComponent<Light>().color = Color.green;
            print("ccb");
            FindObjectOfType<AudioManager>().Play("Unlock");
        }
    }
}
