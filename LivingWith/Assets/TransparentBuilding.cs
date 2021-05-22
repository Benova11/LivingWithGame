using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparentBuilding : MonoBehaviour
{

    [SerializeField] Color TransparentColor;
    Color NormalColor;
    SpriteRenderer sr;
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        NormalColor = sr.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Movement>())
        {
            sr.color = TransparentColor;
        }
    }

    public void beckToNormal()
    {
        sr.color = NormalColor;
    }
}
