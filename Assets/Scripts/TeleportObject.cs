using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class TeleportObject : MonoBehaviour
{
    public enum TriggerType { Enter, Exit };

    [Tooltip("The Transform to teleport to")]
    [SerializeField] Transform teleportTo;

    [Tooltip("The filter Tag")]
    [SerializeField] string tag = "Player";

    [Tooltip("Trigger Event to Teleport")]
    [SerializeField] TriggerType type;

    //To invert Y velocity of the object
    [System.NonSerialized] public GameObject invertY;
    [System.NonSerialized] public Rigidbody2D rb;

    [System.NonSerialized] public bool allowBlue = false;
    [System.NonSerialized] public bool allowOrange = false;

    //private float invertY;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (allowBlue == true && allowOrange == true)
        {
            if (type != TriggerType.Enter)
            {
                print("if (type != TriggerType.Enter)");
                return;
            }

            if (tag == string.Empty || other.CompareTag(tag))
            {
                FindObjectOfType<AudioManager>().Play("PortalEnter");
                other.transform.position = new Vector2(teleportTo.position.x, teleportTo.position.y);

                invertY = other.gameObject;
                rb = invertY.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
            }

            if (tag == string.Empty || other.CompareTag("Box"))
            {
                FindObjectOfType<AudioManager>().Play("PortalEnter");
                other.transform.position = new Vector2(teleportTo.position.x, teleportTo.position.y);

                invertY = other.gameObject;
                rb = invertY.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(rb.velocity.x, -rb.velocity.y);
            }

            if (tag == string.Empty || other.CompareTag("Bullet"))
            {
                FindObjectOfType<AudioManager>().Play("PortalEnter");
                other.transform.position = new Vector2(teleportTo.position.x, teleportTo.position.y);

                invertY = other.gameObject;
                rb = invertY.GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(-rb.velocity.x, -rb.velocity.y);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (type != TriggerType.Exit)
            return;

        if (tag == string.Empty || other.CompareTag(tag))
        {
            other.transform.position = teleportTo.position;
            //other.transform.position = new Vector2(teleportTo.position.x, teleportTo.position.y + 2.0f);
        }
        if (tag == string.Empty || other.CompareTag("Box"))
        {
            other.transform.position = teleportTo.position;
            //other.transform.position = new Vector2(teleportTo.position.x, teleportTo.position.y + 2.0f);
        }
    }
}
