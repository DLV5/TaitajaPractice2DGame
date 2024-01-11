using System;
using UnityEngine;
[Serializable]
public class MusicClip : Clip
{
    [SerializeField] private MusicType _type;
    [SerializeField] private AudioClip _clip;
    public string ClipName => _type.ToString();
    public AudioClip Clip => _clip;
}
