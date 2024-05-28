using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioManager : MonoBehaviour
{
    // public AudioSource audio;
    public string key;
    void Start(){
        GetComponent<Slider>().value = PlayerPrefs.GetFloat(key);
    }
    void Update(){
        PlayerPrefs.SetFloat(key,GetComponent<Slider>().value);
    }
    public void storeVolume(){
        PlayerPrefs.SetFloat(key, GetComponent<Slider>().value);
        // PlayerPrefs.SetFloat("music", sfx.volume);
    }


}
