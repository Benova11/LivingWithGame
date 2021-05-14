using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedCameraPoint : MonoBehaviour
{
    [SerializeField] Transform player;
    Vector3 newPos;
    float MaximumHeightToFollowToAdd = 30;
    [SerializeField] float MaximumHeightToFollow ;
    float MaximumHeightToFollowFixt = 30;
    float y;
   
    // Start is called before the first frame update
    void Start()
    {
        y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        newPos = new Vector3(player.position.x, transform.position.y, transform.position.z);
        if (player.position.y > MaximumHeightToFollow)
        {
            newPos = new Vector3(player.position.x, MaximumHeightToFollow/2, transform.position.z);
            MaximumHeightToFollow += MaximumHeightToFollowToAdd;
        }
        else if (player.position.y < MaximumHeightToFollow - MaximumHeightToFollowFixt && player.position.y > MaximumHeightToFollowFixt)
        {
            newPos = new Vector3(player.position.x, MaximumHeightToFollow / 2, transform.position.z);
            MaximumHeightToFollow -= MaximumHeightToFollowToAdd;
        }
        else if (player.position.y < MaximumHeightToFollowFixt)
        {
            MaximumHeightToFollow = MaximumHeightToFollowFixt;
            newPos = new Vector3(player.position.x, y, transform.position.z);
        }
        transform.position = newPos;
    }
}
