using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private AudioSource _soundtrack;
    private void Start()
    {
        _soundtrack = GetComponent<AudioSource>();
        _soundtrack.volume = PlayerPrefs.GetFloat("volume") == 0.0f ? 1.00f : PlayerPrefs.GetFloat("volume");
    }
}
