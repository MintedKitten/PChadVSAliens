using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip click;
    public AudioClip clothrip;
    public static AudioManager instance; 
    private AudioSource audiosource;
    private void Awake()
    {
        instance = this;
        audiosource = gameObject.AddComponent<AudioSource>();
    }
    
    public void PlaySound(AudioClip clip)
    {
        audiosource.PlayOneShot(clip);
    }
    public void PlayClick()
    {
        PlaySound(click);
    }
    public void PlayClothRip()
    {
        PlaySound(clothrip);
    }
}
