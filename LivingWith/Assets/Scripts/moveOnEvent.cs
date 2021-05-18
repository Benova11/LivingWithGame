using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOnEvent : MonoBehaviour
{
    [SerializeField] Transform Waypoint;
    Vector3 normalPos;
    [SerializeField]private float speed =0.2f;
    bool IsActive = false;
    bool IsAtEndPoint = false;
    bool goBack = false;
    [SerializeField] Movement Player;
    // Start is called before the first frame update
    void Start()
    {
        normalPos = transform.position;
    }
    private void Update()
    {
        if (IsActive) 
        {
            transform.position = Vector3.MoveTowards(transform.position, Waypoint.position, speed );
            if (transform.position == Waypoint.position)
            {
                IsActive = false;
                IsAtEndPoint = true;
                Player.gameObject.transform.SetParent(null);
            }
           
        }

        if (goBack)
        {
            transform.position = Vector3.MoveTowards(transform.position, normalPos, speed *0.5F ); 
        }

    }
    public void goToWaypoint()
    {
        IsActive = true;
        IsAtEndPoint = false;
        goBack = false;

    }

    public void GoBeckToStartPos( Movement player)
    {
        if (IsAtEndPoint) 
        {
            IsActive = false;
            goBack = true;
            Player = player;
            Player.gameObject.transform.SetParent(this.gameObject.transform);
        }


    }
}
