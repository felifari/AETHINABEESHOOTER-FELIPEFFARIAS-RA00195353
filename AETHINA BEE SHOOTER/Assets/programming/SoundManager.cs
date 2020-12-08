using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    //Controlador de sons e musica

    public static AudioClip BeetleDeathSound, BeetleHitSound, BeetleShotSound, EnemyDeathSound, EnemyHitSound, EnemyShotSound, HighscoreSound, JellyGetSound;
    static AudioSource audioSrc;
    void Start()
    {
        BeetleDeathSound = Resources.Load<AudioClip>("BeetleDeath");
        BeetleHitSound = Resources.Load<AudioClip>("BeetleHit");
        BeetleShotSound = Resources.Load<AudioClip>("BeetleShot");
        EnemyDeathSound = Resources.Load<AudioClip>("EnemyDeath");
        EnemyHitSound = Resources.Load<AudioClip>("EnemyHit");
        EnemyShotSound = Resources.Load<AudioClip>("EnemyShot");
        JellyGetSound = Resources.Load<AudioClip>("JellyGet");

        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "BeetleDeath":
                audioSrc.PlayOneShot(BeetleDeathSound);
                break;
            case "BeetleHit":
                audioSrc.PlayOneShot(BeetleHitSound);
                break;
            case "BeetleShot":
                audioSrc.PlayOneShot(BeetleShotSound);
                break;
            case "EnemyDeath":
                audioSrc.PlayOneShot(EnemyDeathSound);
                break;
            case "EnemyHit":
                audioSrc.PlayOneShot(EnemyHitSound);
                break;
            case "EnemyShot":
                audioSrc.PlayOneShot(EnemyShotSound);
                break;
            case "JellyGet":
                audioSrc.PlayOneShot(JellyGetSound);
                break;


        }


    }

}
