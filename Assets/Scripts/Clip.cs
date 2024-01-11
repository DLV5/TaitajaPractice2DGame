using UnityEngine;
using System;

public interface Clip
{
    string ClipName { get; }
    AudioClip Clip { get; }
}
