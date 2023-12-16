using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public float MusicVolume = 1;
    public float SfxVolume = 1;
    [SerializeField] private Slider _volumeMusicSlider;
    [SerializeField] private Slider _volumeSFXSlider;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.Play();
        MusicVolume = PlayerPrefs.GetFloat("musicVolume");
        SfxVolume = PlayerPrefs.GetFloat("SFXVolume");
        _volumeMusicSlider.value = MusicVolume;
        _volumeSFXSlider.value = SfxVolume;    
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = MusicVolume;
        PlayerPrefs.SetFloat("musicVolume", MusicVolume);
        PlayerPrefs.SetFloat("SFXVolume", SfxVolume);
    }
    public void UpdateMusicVolume(float volume)
    {
        MusicVolume = volume;
        PlayerPrefs.SetFloat("SFXVolume", SfxVolume);
    }
    public void UpdateSFXVolume(float volume)
    {
        MusicVolume = volume;
        PlayerPrefs.SetFloat("musicVolume", MusicVolume);
    }

    public void ChangeMusic(AudioClip music)
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        audioSource.clip = music;
        audioSource.Play();
    }
}
