using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class handler : MonoBehaviour
{
    public bool isDesk;
    public GameObject canvasContent;

    void Start(){
        canvasContent.SetActive(true);
    }
    public void forDesk(){
        isDesk=false;
    }
    public void cek(){
        print("cek");
    }
}
