using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public bool zoomInNow = false;
    public bool zoomOutNow = false;
    public float camSize, zoomOutLimit, zoomInLimit, step, timeLerp, timeLerpValue;
    // Start is called before the first frame update
    void Start()
    {

    }//end start

    // Update is called once per frame
    void Update()
    {

        if (zoomInNow)
        {
            ZoomIn();
            //GetComponent<CameraFollows>().enabled = true;
        }
        if (zoomOutNow)
        {
            ZoomOut();
            //GetComponent<CameraFollows>().enabled = false;

        }

        camSize = Camera.main.orthographicSize;
        timeLerpValue = timeLerp * Time.deltaTime;
    }//end update


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Zoom Box Trigger")
        {
            zoomOutNow = true;
            Debug.Log("Zoom out now");
        }


    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Zoom Box Trigger")
        {
            zoomInNow = true;
            Debug.Log("Zoom in now");
        }

    }

    //LOGIC TO REMEMEBER:
    //increasing camera size = Zoom Out
    //decreasing camera size = Zoom In

    void ZoomIn()
    {
        if (Camera.main.orthographicSize > zoomInLimit)
        {
            zoomOutNow = false;
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Camera.main.orthographicSize + -step, timeLerpValue);
        }
        else if (Camera.main.orthographicSize < zoomInLimit)
        {
            //zoomInNow = false;
        }
    }//end zoomIn

    void ZoomOut()
    {
        if (Camera.main.orthographicSize < zoomOutLimit)
        {
            zoomInNow = false;
            Camera.main.orthographicSize = Mathf.Lerp(Camera.main.orthographicSize, Camera.main.orthographicSize + step, timeLerpValue);
        }
        else if (Camera.main.orthographicSize > zoomOutLimit)
        {
            //zoomOutNow = false;
        }
    }//end zoomOut
}//end class
