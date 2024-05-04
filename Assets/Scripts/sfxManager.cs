using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sfxManager : MonoBehaviour
{
    public AudioSource sfx;
    public AudioClip[] sfxClip;
    public void pickAudio(int a){
        sfx.clip=sfxClip[a];
        sfx.Play();
    }
}
