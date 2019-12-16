using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{
    public float Seconds = 0;

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, Seconds);
	}
}
