using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class vs : MonoBehaviour
{
    [SerializeField] PostProcessVolume _PostProcessVolume;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<GirlActions>().playMode)
        {
            _PostProcessVolume.enabled = false;
        }
    }
}
