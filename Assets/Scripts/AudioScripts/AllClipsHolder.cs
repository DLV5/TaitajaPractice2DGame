using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AudioManager/Create All Clips Holder")]
public class AllClipsHolder : ScriptableObject
{
    [SerializeField] private List<MusicClip> musicClips;
    [SerializeField] private List<SFXClip> SFXClips;

    public IEnumerable<MusicClip> allMusicClips => musicClips;
    public IEnumerable<SFXClip> allSFXClips => SFXClips;
}
