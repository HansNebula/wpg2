using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desaSwampea : MonoBehaviour
{
    public GameObject[] isi;
    int n=0;

    void Start(){
        n=0;
    }

    void Update(){
        if(n<isi.Length && n>=0){
            for(int i=0;i<isi.Length;i++){
                if(i==n){
                    isi[i].SetActive(true);
                }else if(i!=n){
                    isi[i].SetActive(false);
                }
            }
        }
        else if(n>=isi.Length) n=isi.Length-1;
        else if(n<0) n=0;
    }

    public void next(){
        n++;
    }
    public void prev(){
        n--;
    }
}
