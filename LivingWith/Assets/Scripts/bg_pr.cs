using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bg_pr : MonoBehaviour
{
    private Transform cam;
    Vector3 LastCamPos;
    [SerializeField]float PrallexEffectMuliti = 0.5F;
    float textutreSize;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        LastCamPos = cam.position;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        textutreSize = texture.width / sprite.pixelsPerUnit;

    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 deltaMovement = cam.position - LastCamPos;
        
        transform.position += deltaMovement * PrallexEffectMuliti;
        LastCamPos = cam.position;

        if (Mathf.Abs( cam.position.x - transform.position.x )>= textutreSize)
        {
            float offsetPosX = (cam.position.x - transform.position.x) % textutreSize;
            transform.position = new Vector3(cam.position.x + offsetPosX, transform.position.y);        
            
        }
    }
}
