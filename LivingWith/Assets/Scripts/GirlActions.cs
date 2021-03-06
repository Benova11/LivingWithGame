using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlActions : MonoBehaviour
{
    public GameObject flute;
    Bar bar;
    private bool isPlayingGuitar = false;
    [SerializeField] Transform fluteTransform;
    [SerializeField] AudioClip alice_Cant_play;
    AudioSource _AudioSource;

    public bool playMode;
    bool isPlaying;
    
    // Start is called before the first frame update
    void Start()
    {
        fluteTransform = transform.Find("FluteTransform");
        bar = FindObjectOfType<Bar>();
        //flute.transform.position = new Vector3(transform.position.x + 0.8f, transform.position.y - 0.5f, transform.position.z);
        flute.transform.position = fluteTransform.position;
        flute.SetActive(false);
        _AudioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("PlayFlute") && (bar.getBarValue() >= 0.0f))
        {
            PlayGuitar();
          
        }
        else if (isPlayingGuitar)
        {
            isPlayingGuitar = false;
            HideGuitar();
        
        }
        if (Input.GetButton("PlayFlute") && bar.getBarValue() <= 0 && isPlaying == false)
        {
            StartCoroutine(playOneShot());
        }
    }
    IEnumerator playOneShot()
    {
        isPlaying = true;
        _AudioSource.PlayOneShot(alice_Cant_play);
        yield return new WaitForSeconds(2);
        isPlaying = false;
    }
     void PlayGuitar()
    {
        if (bar.getBarValue() > 0)
        {
            isPlayingGuitar = true; 
            playMode = true;
            bar.decreaseBar();

        }

    }

    public void HideGuitar()
    {   
    playMode = false;
    }
}
