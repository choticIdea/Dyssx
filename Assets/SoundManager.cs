using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public List<AudioClip> pianoSounds;
    public static SoundManager singleton;
    public List<AudioClip> sfx;

    private void Awake()
    {
        if(singleton == null)
        {
            singleton = this;
        }
    }
    public void PlayPianoTone(int index) {
        GetComponents<AudioSource>()[0].Stop();
        GetComponents<AudioSource>()[0].clip = pianoSounds[index];
        GetComponents<AudioSource>()[0].Play();
    }
    public void PlaySFX(int index)
    {
        GetComponents<AudioSource>()[0].Stop();
        GetComponents<AudioSource>()[0].clip = sfx[index];
        GetComponents<AudioSource>()[0].Play();
    }
}
