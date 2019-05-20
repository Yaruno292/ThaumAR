using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour {

    [SerializeField]
    private AudioClip[] writeSounds, zapSounds;
    [SerializeField]
    private AudioClip learnSound, eraseSound;

    private AudioSource audioSource;

    private int i = 0;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //PlayZap(0);
    }

    public void PlayZap(int i)
    {
        //i = Random.Range(0, zapSounds.Length);
        audioSource.clip = zapSounds[i];
        audioSource.Play();
    }

    public void PlayWrite()
    {
        i = Random.Range(0,writeSounds.Length);
        audioSource.clip = writeSounds[i];
        audioSource.Play();
    }

    public void PlayLearn()
    {
        audioSource.clip = learnSound;
        audioSource.Play();
    }

    public void PlayErase()
    {
        audioSource.clip = eraseSound;
        audioSource.Play();
    }
}
