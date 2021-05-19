using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlActions : MonoBehaviour
{
    public GameObject flute;
    Bar bar;
    private bool isPlayingFlute = false;
    [SerializeField] Transform fluteTransform;
    // Start is called before the first frame update
    void Start()
    {
        fluteTransform = transform.Find("FluteTransform");
        bar = FindObjectOfType<Bar>();
        //flute.transform.position = new Vector3(transform.position.x + 0.8f, transform.position.y - 0.5f, transform.position.z);
        flute.transform.position = fluteTransform.position;
        flute.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("PlayFlute") && (bar.getBarValue() >= 0.0f))
        {
            playFlute();
        }
        else if (isPlayingFlute)
        {
            isPlayingFlute = false;
            hideFlute();
        }
    }

    public void playFlute()
    {
        if (bar.getBarValue() > 0)
        {
            isPlayingFlute = true;
            bar.decreaseBar();

            if (!flute.active)
            {
                flute.SetActive(true);
            }
            
        }
    }

    public void hideFlute()
    {
        flute.SetActive(false);
    }
}
