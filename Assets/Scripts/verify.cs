using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class verify : MonoBehaviour
{
   public bool isCek, formal, isTanya;
   public GameObject handler, tombolTanya;
    
    void Start(){
        handler=GameObject.FindGameObjectWithTag("GameController");
    }
    void Update(){
        Tombtanya();
    }
    public void valid(){
        handler.GetComponent<forScroll>().presentase+=25;
        isCek=true;
    }
    public void ragu(){
        isTanya=true;
        handler.GetComponent<forScroll>().upSroll();
    }
    public void tidakValid(){
        handler.GetComponent<forScroll>().presentase+=0;
        isCek=true;
    }
    void Tombtanya(){
        if(!formal){
            if(isTanya){
                tombolTanya.SetActive(false);
            }else{
                tombolTanya.SetActive(true);
            }
        }else{
            tombolTanya.SetActive(false);
        }

    }
}
