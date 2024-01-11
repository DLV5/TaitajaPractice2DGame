
using UnityEngine;
using System;

public class SFXClipFactory
{
    private AllClipsHolder _allClipsHolder;
    public SFXClipFactory(AllClipsHolder allClipsHolder)
    {
        _allClipsHolder = allClipsHolder;
    }
    public AudioClip GetSFXClip(SFXType type)
    {
        foreach (SFXClip SFXClip in _allClipsHolder.allSFXClips)
        {
            if (SFXClip.ClipName == type.ToString())
            {
                return SFXClip.Clip;
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
