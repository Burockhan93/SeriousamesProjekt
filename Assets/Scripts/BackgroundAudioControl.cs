using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudioControl : MonoBehaviour
{

    [SerializeField] AudioClip sound;
    private AudioSource audio;

    // Start is called before the first frame update
    void Start()
    {
        //play background music in a loop
        audio = gameObject.AddComponent<AudioSource>();
        audio.playOnAwake = true;
        audio.clip = sound;
        audio.loop = true;
        audio.volume = audio.volume / 10; 
        audio.Play();
    }

}
