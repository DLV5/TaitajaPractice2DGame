using System;
using UnityEngine;

[Serializable]
public class SFXClip : Clip
{
    [SerializeField] private SFXType _type;
    [SerializeField] private AudioClip _clip;
    public string ClipName => _type.ToString();
    public AudioClip Clip => _clip;
}
