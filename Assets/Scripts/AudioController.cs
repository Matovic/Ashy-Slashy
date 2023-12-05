using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource _soundtrack;
    private void Start()
    {
        _soundtrack = GetComponent<AudioSource>();
        _soundtrack.mute = PlayerPrefs.GetInt("mute") == 1; 
        _soundtrack.volume = PlayerPrefs.GetFloat("volume");
    }
}
