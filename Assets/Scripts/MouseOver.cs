using UnityEngine;
using System.Collections;
public class MouseOver : MonoBehaviour
{
    //portals
    public GameObject portal1;
    public GameObject portal2;

    void OnMouseOver()
    {
        /*
        if (gameObject.tag == "Ground")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                {
                    Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);

                    portal1.transform.position = new Vector3(worldPoint.x, worldPoint.y, portal1.transform.position.z);
                }
            }

            if (Input.GetButtonDown("Fire2"))
            {
                Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);

                portal2.transform.position = new Vector3(worldPoint.x, worldPoint.y, portal2.transform.position.z);
            }
        }
        */
    }
}