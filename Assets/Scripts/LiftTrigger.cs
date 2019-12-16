using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftTrigger : MonoBehaviour
{
    public GameObject lift;

    void OnColliderEnter2D(Collider2D other)
    {
        Debug.Log("Entered, Press E");
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E is pressed");
            lift.transform.position = new Vector2(lift.transform.position.x, lift.transform.position.y * Time.deltaTime); 
        }
    }
}
