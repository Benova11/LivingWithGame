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
         
            if (Input.GetKey(KeyCode.Space))
            {
              
                if (GetComponent<Collider2D>().isTrigger == true)
                {
                  
                    GetComponent<Collider2D>().isTrigger = false;
                }
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Movement>())
        {
            
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
