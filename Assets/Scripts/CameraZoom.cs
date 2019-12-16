using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraZoom : MonoBehaviour
{
    [SerializeField]
    private float unzoomValue = 20;

    [SerializeField]
    private float zoomValue = 10;

    [SerializeField]
    private float waitTime = 10;

    [SerializeField]
    private GameObject CMCamera;

    // Use this for initialization
    void Start ()
    {
        var vcam = CMCamera.GetComponent<CinemachineVirtualCamera>();
        vcam.m_Lens.OrthographicSize = unzoomValue;
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        var vcam = CMCamera.GetComponent<CinemachineVirtualCamera>();
        yield return new WaitForSeconds(waitTime);
        Debug.Log("Waited!");
        vcam.m_Lens.OrthographicSize = zoomValue;
    }
}
