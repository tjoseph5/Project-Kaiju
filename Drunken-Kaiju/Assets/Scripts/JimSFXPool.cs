using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JimSFXPool : MonoBehaviour
{
    public static JimSFXPool singleton;

    //Audio Clips
    [Header("Jim Clips")]
    public List<AudioClip> jimClips = new List<AudioClip>();

    [Header("Building Clips")]
    public List<AudioClip> buildingClips = new List<AudioClip>();

    [Header("Vehicle Clips")]
    public List<AudioClip> vehicleClips = new List<AudioClip>();


    private void Awake()
    {
        singleton = this;
    }
}
