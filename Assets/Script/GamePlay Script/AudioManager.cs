using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip click;
    public AudioClip clothrip;
    public AudioClip BossDeath;
    public AudioClip BossAttack;
    public AudioClip BossSlam;
    public AudioClip PlayerAttack;

    public AudioClip Explosion;

    public AudioClip noice;
    public AudioClip charge;
    public AudioClip take_hit;
    public AudioClip blat_em;
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
    public void PLayBossDeath()
    {
        PlaySound(BossDeath);
    }
        public void PLayBossAttack()
    {
        PlaySound(BossAttack);
    }
    public void PlayBossSlam()
    {
        PlaySound(BossSlam);
    }
    public void Playplayerattack()
    {
        PlaySound(PlayerAttack);
    }

    public void PlayExplosion()
    {
        PlaySound(Explosion);
    }

    public void PlayNoice()
    {
        PlaySound(noice);
    }
    public void PlayTakeHit()
    {
        PlaySound(take_hit);
    }

    public void PLayCharge()
    {
        PlaySound(charge);
    }
    public void PlayBlast()
    {
        PlaySound(blat_em);
    }
}
