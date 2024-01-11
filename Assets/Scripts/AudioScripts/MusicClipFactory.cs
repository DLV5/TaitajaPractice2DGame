using System;
using UnityEngine;

public class MusicClipFactory 
{
    private AllClipsHolder _allClipsHolder;
    public MusicClipFactory(AllClipsHolder allClipsHolder)
    {
        _allClipsHolder = allClipsHolder;
    }
    public AudioClip GetMusicClip(MusicType type)
    {
        foreach(MusicClip musicClip in _allClipsHolder.allMusicClips)
        {
            if(musicClip.ClipName == type.ToString())
            {
                return musicClip.Clip;
            }
            else
            {
                continue;
            }
        }
        return null;
        throw new NotImplementedException(nameof(type));
    }
}
