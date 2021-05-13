using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraChanger : MonoBehaviour
{

    [SerializeField] GameObject TargetGroup;
    [SerializeField] Transform newTransform;
    [SerializeField] float Weight = 1;
    [SerializeField] float radius = 5;

    [SerializeField] bool removeTransform;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("in");
            if (!removeTransform)
            {
                TargetGroup.GetComponent<CinemachineTargetGroup>().AddMember(newTransform, 1, 10);
            }

        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("in");
            if (!removeTransform)
            {
                TargetGroup.GetComponent<CinemachineTargetGroup>().RemoveMember(newTransform);
            }
        }
    }
}
