using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyGFX : MonoBehaviour
{
    public AIPath aiPath;


	// Use this for initialization
	void Update ()
    {
        if (aiPath.desiredVelocity.x >= 0.01f && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            //Debug.Log(transform.localScale.y);
        }
        else if (aiPath.desiredVelocity.x <= 0.01f && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            //Debug.Log(transform.localScale.y);
        }
	}
}
