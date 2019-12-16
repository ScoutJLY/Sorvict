using UnityEngine;

public class Shooting : MonoBehaviour
{
    public float fireRate = 0;
    public LayerMask targetToHit;

    public Transform BulletTrailPrefab;

    float timeToFire = 0;
    Transform firePoint;

    GameObject portal1;
    GameObject portal2;

    void Awake ()
    {
        firePoint = transform.Find("CastPoint");
        portal1 = GameObject.Find("Portal 1");    
        portal2 = GameObject.Find("Portal 2");
        portal1.SetActive(false);
        portal2.SetActive(false);
    }

    // Update is called once per frame
    void Update ()
    {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                //FindObjectOfType<AudioManager>().Play("Test1");
                ShootBlue();
            }

            if (Input.GetButtonDown("Fire2"))
            {
                //FindObjectOfType<AudioManager>().Play("Test2");
                ShootOrange();
            }
        }
	}

    void ShootBlue()
    {
        //Debug.Log("Shooting Blue");
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint (Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, targetToHit);
        //Effect();
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition)*100);
        if (hit.collider != null)
        {
            portal1.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Portal1");
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            //Debug.Log(hit.point);
            portal1.transform.position = hit.point;
        }
    }
    void ShootOrange()
    {
        //Debug.Log("Shooting Orange");
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
        RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, targetToHit);
        Debug.DrawLine(firePointPosition, (mousePosition - firePointPosition)*100);
        if (hit.collider != null)
        {
            portal2.SetActive(true);
            FindObjectOfType<AudioManager>().Play("Portal2");
            Debug.DrawLine(firePointPosition, hit.point, Color.red);
            //Debug.Log(hit.point);
            portal2.transform.position = hit.point;
        }
    }

    void Effect()
    {
        Instantiate(BulletTrailPrefab, firePoint.position, firePoint.localRotation);
    }
}
