using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeController
{
    private AudioMixer _audioMixer;
    private Slider _musicSlider;
    private Slider _SFXSlider;

    const string MIXER_MUSIC = "MusicVolume";    // Exposed param of Music volume (in AudioMixer)
    const string MIXER_SFX = "SFXVolume";        // Exposed param of SFX volume (in AudioMixer)

    public VolumeController (AudioMixer audioMixer, Slider musicSlider, Slider SFXSlider)
    {
        _audioMixer = audioMixer;
        _musicSlider = musicSlider;
        _SFXSlider = SFXSlider;

        _musicSlider.onValueChanged.AddListener(SetMusicVolume);
        _SFXSlider.onValueChanged.AddListener(SetSFXVolume);

        SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume"));
        _musicSlider.value = Mathf.Log10(PlayerPrefs.GetFloat("MusicVolume"));
        SetMusicVolume(PlayerPrefs.GetFloat("SFXVolume"));
        _SFXSlider.value = Mathf.Log10(PlayerPrefs.GetFloat("SFXVolume"));
    }
    public void DestroyObject()
    {
        _musicSlider.onValueChanged.RemoveListener(SetMusicVolume);
        _SFXSlider.onValueChanged.RemoveListener(SetSFXVolume);
    }

    private void SetMusicVolume(float value)
    {
        Debug.Log("Music");
        _audioMixer.SetFloat(MIXER_MUSIC, Mathf.Log10(value) * 20f);
        PlayerPrefs.SetFloat("MusicVolume", value);
    }
    private void SetSFXVolume(float value)
    {
        _audioMixer.SetFloat(MIXER_SFX, Mathf.Log10(value) * 20f);
        PlayerPrefs.SetFloat("SFXVolume", value);
    }

}
