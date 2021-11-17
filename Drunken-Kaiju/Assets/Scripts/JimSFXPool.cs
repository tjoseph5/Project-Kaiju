using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JimSFXPool : MonoBehaviour
{
    public static JimSFXPool singleton;

    //Audio Clips
    [Header("SFXs Clip")]
    public List<AudioClip> audioClips = new List<AudioClip>();

    private void Awake()
    {
        singleton = this;
    }
}
