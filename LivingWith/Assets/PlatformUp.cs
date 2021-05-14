using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformUp : MonoBehaviour
{
    [SerializeField] Movement player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

      
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Movement>())
        {
            Debug.Log("hit1");
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log("hit3");
                if (GetComponent<Collider2D>().isTrigger == true)
                {
                    Debug.Log("hit4");
                    GetComponent<Collider2D>().isTrigger = false;
                }
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Movement>())
        {
            Debug.Log("hit2");
            if (Input.GetKeyDown(KeyCode.S))
            {
                if (GetComponent<Collider2D>().isTrigger == false)
                {
                    GetComponent<Collider2D>().isTrigger = true;
                }

            }
        }
    }
}
