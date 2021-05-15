using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOnEvent : MonoBehaviour
{
    [SerializeField] Transform Waypoint;
    Vector3 normalPos;
    [SerializeField]private float speed =0.2f;
    bool IsActive = false;
    // Start is called before the first frame update
    void Start()
    {
        normalPos = transform.position;
    }
    private void Update()
    {
       if (IsActive) transform.position = Vector3.MoveTowards(transform.position, Waypoint.position, speed);
    }
    public void goToWaypoint()
    {
        IsActive = true;
    }
}
