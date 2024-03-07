using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource musicSource;
    [SerializeField]
    private AudioClip musicClip;

    private void Awake()
    {
        musicSource = GameObject.Find("Music").GetComponent<AudioSource>();
    }

    private void Start()
    {
        musicSource.clip = musicClip;
        musicSource.loop = true;
        musicSource.Play();
    }
}
