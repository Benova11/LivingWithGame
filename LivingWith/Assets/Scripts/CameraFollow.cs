using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform followTransform;
    //public BoxCollider2D mapBounds;

   // private float xMin, xMax, yMin, yMax;
    //private float camY,camX;
    //private float camOrthsize;
    //private float cameraRatio;
    private Camera mainCam;
    private Vector3 smoothPos;
    public float smoothSpeed = 0.5f;
    private bool manualy = false;
    private float zpos;
    private float manualZpos;
    private bool setToManual = false;
    private bool trigerPoint1 = false;
    private bool fireCamp = false;
    private bool cameraMoved = false;
    [SerializeField] private Transform cameraTrigeer;
    [SerializeField] private Transform cameraTrigeerEnd;
    [SerializeField] private Transform fireCampPos;

    private void Start()
    {
        //xMin = mapBounds.bounds.min.x;
        //xMax = mapBounds.bounds.max.x;
        //yMin = mapBounds.bounds.min.y;
        //yMax = mapBounds.bounds.max.y;
        mainCam = GetComponent<Camera>();
        //StartCoroutine(ExampleCoroutine());
        //camOrthsize = mainCam.orthographicSize;
        //cameraRatio = (xMax + camOrthsize) / 2.0f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        //camY = Mathf.Clamp(followTransform.position.y, yMin + camOrthsize, yMax - camOrthsize);
        //camX = Mathf.Clamp(followTransform.position.x, xMin + cameraRatio, xMax - cameraRatio);
       if (!manualy){
           zpos = -18;
        }else if (zpos == -18){
            zpos = this.transform.position.z - 8;
        }
        if (transform.position.x > cameraTrigeer.position.x){
            manualy = true;
        }
        if (transform.position.x > cameraTrigeerEnd.position.x){
            manualy = false;
        }
        if (transform.position.x >= fireCampPos.position.x && !cameraMoved){
            smoothPos = Vector3.Lerp(this.transform.position, new Vector3(followTransform.transform.position.x + 15, followTransform.transform.position.y + 6, zpos), smoothSpeed - 0.05f);
            this.transform.position = smoothPos;
            if (!fireCamp){
            StartCoroutine(seeFireCamp());
            fireCamp = true;
            }
        }

        if (!fireCamp){
        smoothPos = Vector3.Lerp(this.transform.position, new Vector3(followTransform.transform.position.x + 4, followTransform.transform.position.y + 6, zpos), smoothSpeed);
        this.transform.position = smoothPos; 
        }
    }

    IEnumerator seeFireCamp()
    {
        //Print the time of when the function is first called.
        Debug.Log("MANUAL" + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        //yield return new WaitForSeconds(2);
        //smoothPos = Vector3.Lerp(this.transform.position, new Vector3(followTransform.transform.position.x + 15, followTransform.transform.position.y + 6, zpos), smoothSpeed - 0.05f);
        //this.transform.position = smoothPos;
        yield return new WaitForSeconds(5); 
        smoothPos = Vector3.Lerp(this.transform.position, new Vector3(followTransform.transform.position.x -15, followTransform.transform.position.y + 6, zpos), smoothSpeed);
        this.transform.position = smoothPos;
        fireCamp = false;
        cameraMoved = true;
        //manualy = true;
        //manualZpos = -20;
        //yield return new WaitForSeconds(5);
        //manualZpos = -25;
        //setToManual = false;
        //this.transform.position = new Vector3()

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }

      IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);
        manualy = true;
        yield return new WaitForSeconds(5);
        manualy = false;
        //this.transform.position = new Vector3()

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    }
}
