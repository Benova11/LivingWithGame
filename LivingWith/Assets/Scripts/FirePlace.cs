using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePlace : MonoBehaviour
{
    Bar bar;

    // Start is called before the first frame update
    void Start()
    {
        bar = FindObjectOfType<Bar>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Movement>())
        {

            bar.fillBar(bar.deacreseTmp);
        }
    }
}
