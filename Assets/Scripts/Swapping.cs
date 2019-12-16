using UnityEngine;

public class Swapping : MonoBehaviour
{
    public Transform swapWithOrange;
    public Transform swapWithBlue;
    GameObject portalOrange;
    GameObject portalBlue;

    Vector3 temp;

    void Awake ()
    {
        
    }

	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            portalOrange = GameObject.Find("Portal 2");
            portalBlue = GameObject.Find("Portal 1");

            //Debug.Log("Portal Swap!");
            /*
            temp = swapWithOrange.transform.position;
            portalOrange.transform.position = swapWithBlue.transform.position;
            portalBlue.transform.position = temp;
            */

            temp = portalOrange.transform.position;
            portalOrange.transform.position = portalBlue.transform.position;
            portalBlue.transform.position = temp;
        }
    }
}
