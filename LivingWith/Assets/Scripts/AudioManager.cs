using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
   [SerializeField] AudioSource _AudioSource1;
   [SerializeField] AudioSource _AudioSource_amb_voices;

    [SerializeField] AudioClip lvl1_music_loop;
    [SerializeField] AudioClip amb_voices;
    // Start is called before the first frame update
    void Start()
    {
        _AudioSource1.PlayOneShot(lvl1_music_loop);
        _AudioSource_amb_voices.PlayOneShot(amb_voices);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_AudioSource1.isPlaying)
        {
            Debug.Log("new lvl 11");
            _AudioSource1.PlayOneShot(lvl1_music_loop);
        }       
        if (!_AudioSource_amb_voices.isPlaying)
        {
            Debug.Log("new amp");
            _AudioSource_amb_voices.PlayOneShot(amb_voices);
        }
    }
}
