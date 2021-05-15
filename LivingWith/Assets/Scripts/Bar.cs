using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    float currentBar;
    public float maxBar = 3.0f;
    public float deacreseTmp = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        currentBar = maxBar;
        GetComponent<Slider>().maxValue = maxBar;
        GetComponent<Slider>().value = currentBar;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void decreaseBar()
    {
        currentBar -= deacreseTmp;
        GetComponent<Slider>().value = currentBar;

    }

    public void fillBar(float fillAmount = 0.1f)
    {
        if (fillAmount + currentBar <= maxBar)
        {
            currentBar += fillAmount;
        }
        else
        {
            currentBar = maxBar;
        }
        GetComponent<Slider>().value = currentBar;
    }

    public float getBarValue()
    {
        return currentBar;
    }
}
