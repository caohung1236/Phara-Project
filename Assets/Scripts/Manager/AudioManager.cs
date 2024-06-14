using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;
    private static AudioManager instance;

    public static AudioManager Instance { get => instance; }

    private void Awake()
    {
        if (AudioManager.instance != null)
        {
            Debug.LogError("Only 1 AudioManager allow to exist");
        }
        AudioManager.instance = this;
    }

    private void Start()
    {
        PlayMusic("Map1");
    }
    
    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.LogError("Sound Not Found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.Play();
        }
    }

    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, a => a.name == name);

        if (s == null)
        {
            Debug.LogError("Sound Not Found");
        }
        else
        {
            sfxSource.PlayOneShot(s.clip);
        }
    }

    public void ToggleMusic()
    {
        musicSource.mute = !musicSource.mute;
    }

    public void ToggleSFX()
    {
        sfxSource.mute = !sfxSource.mute;
    }

    public void MusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSource.volume = volume;
    }
}
