using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] AudioSource musicSrc;
    [SerializeField] AudioSource SFXsource;
    [SerializeField] AudioSource SFXsource1;

    [Header("Audio Clips")]
    public AudioClip background;
    public AudioClip footsteps;
    public AudioClip doorOpen;
    public AudioClip collectKey;
    public AudioClip switched;


    public static AudioManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        musicSrc.clip = background;
        musicSrc.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXsource.PlayOneShot(clip);
    }

    public void PlayFootsteps()
    {
        if (!SFXsource.isPlaying) 
        {
            SFXsource.clip = footsteps;
            SFXsource.loop = true; 
            SFXsource.Play();
        }
    }

    public void StopFootsteps()
    {
        if (SFXsource.isPlaying)
        {
            SFXsource.Stop();
            SFXsource.loop = false;
        }
    }

    public void PlayKeyCollected()
    {
        SFXsource1.PlayOneShot(collectKey);
    }

    public void PlayDoorOpen()
    {
        SFXsource1.PlayOneShot(doorOpen);
    }

    public void PlaySwitched()
    {
        SFXsource1.PlayOneShot(switched);
    }
}
