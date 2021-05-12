using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{

    public float speed;
    public Transform followTransform;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void FixedUpdate() {
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(followTransform.transform.position.x - 3, followTransform.transform.position.y + 0.5f, transform.position.z), speed);
    }
    // Update is called once per frame
}
