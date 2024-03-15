using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cari : MonoBehaviour
{
    public InputField inCari;
    public string Tcari;

    public GameObject[] content;

    void Update(){
        // select();
    }
    public void select(){
        Tcari=inCari.text.ToLower();
        for(int i=0;i<content.Length;i++){
            if(inCari.text==""){
                content[i].SetActive(false);
            }else{
                if(content[i].GetComponentInChildren<Text>().text.ToLower().Contains(Tcari)){
                    content[i].SetActive(true);
                }else{
                    content[i].SetActive(false);
                }
            }
        }
    }
}
