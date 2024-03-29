using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] private AudioSource _musicAudioSource;
    [SerializeField] private AudioSource _SFXAudioSource;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _SFXSlider;

    private VolumeController _volumeController;
    private SFXClipFactory _SFXClipFactory;
    private MusicClipFactory _musicClipFactory;

    [Header("AudioClips")]
    [SerializeField] private AllClipsHolder _allClipsHolder;
    private void Initialize()
    {
        _volumeController = new VolumeController(_audioMixer, _musicSlider, _SFXSlider);
        _SFXClipFactory = new SFXClipFactory(_allClipsHolder);
        _musicClipFactory = new MusicClipFactory(_allClipsHolder);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Initialize();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void PlayMusic(MusicType musicType)
    {
        _musicAudioSource.clip = _musicClipFactory.GetMusicClip(musicType);
        _musicAudioSource.Play();
    }
    public void PlaySFX(SFXType soundType)
    {
        _SFXAudioSource.clip = _SFXClipFactory.GetSFXClip(soundType);
        _SFXAudioSource.Play();
    }
}
