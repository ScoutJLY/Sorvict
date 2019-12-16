using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private int act = 1;

	// Use this for initialization
	void Start ()
    {
        if (act == 1)
        {
            FindObjectOfType<AudioManager>().Play("Act 1");
        }
        if (act == 2)
        {
            FindObjectOfType<AudioManager>().Play("Act 2");
        }
        if (act == 3)
        {
            FindObjectOfType<AudioManager>().Play("Act 3");
        }
    }
}
