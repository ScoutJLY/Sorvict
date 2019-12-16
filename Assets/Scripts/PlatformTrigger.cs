using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    private Vector3 startPos;

    private Vector3 endPos;

    private Vector3 nextPos;

    [SerializeField]
    private Transform childTransform;

    [SerializeField]
    private Transform destination;

    [SerializeField]
    private float speed;

    // Use this for initialization
    void Start()
    {
        startPos = childTransform.localPosition;
        endPos = destination.localPosition;
        nextPos = endPos;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Moving");
            Move();
        }
    }

    private void Move()
    {
        Debug.Log("Moving");
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPos, speed * Time.deltaTime);
    }
}
