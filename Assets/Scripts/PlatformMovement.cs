using UnityEngine;

public class PlatformMovement : MonoBehaviour
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
	void Start ()
    {
        startPos = childTransform.localPosition;
        endPos = destination.localPosition;
        nextPos = endPos;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();

        if (Vector3.Distance(childTransform.localPosition, nextPos) <= 0.1)
        {
            ChangeDestination();
        }
	}

    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPos, speed * Time.deltaTime);
    }

    private void ChangeDestination()
    {
        nextPos = nextPos != startPos ? startPos : endPos;
    }
}
