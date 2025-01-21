using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    public Transform target;
    public float squishyCam = 0.25f; //Josh's shit..
    public Vector3 offset;
    public CameraZoom camZoom;
    public bool zoomedOut;

    // Update is called once per frame
    void FixedUpdate()
    {
        zoomedOut = camZoom.zoomOutNow;
        Vector3 targetPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(this.transform.position, targetPosition, squishyCam); //this.transform is the camera
        //freeze vertical movement if camera is zoomed out
        if (camZoom.zoomOutNow)
        {
            //smoothedPosition.y = 0;
        }

        this.transform.position = smoothedPosition;

    }
}
