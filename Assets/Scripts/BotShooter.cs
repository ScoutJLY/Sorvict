using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotShooter : MonoBehaviour
{
    public GameObject bullet;

    public float fireRate = 1f;
    public float nextFire;

	// Use this for initialization
	void Start ()
    {
        nextFire = Time.time;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Time.time > nextFire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
	}
}
