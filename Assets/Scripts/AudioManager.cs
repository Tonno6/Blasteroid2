using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource sfx;

    public void PlaySound(AudioClip clip)
    {
        this.sfx.PlayOneShot(clip);
    }
}
