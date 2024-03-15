using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coal : MonoBehaviour
{
    public GameObject handler;
    public GameObject player;
    public KeyCode interact;

    public GameObject int_button_i, int_button_e;
    public GameObject progressBar;

    public bool isCollide=false;
    public bool isDoing;

    // stuff
    public float tookTime;

    void Start(){
        handler=GameObject.FindGameObjectWithTag("GameController");
        int_button_i.SetActive(false);
        int_button_e.SetActive(false);
    }

    void Update(){
        appear();
        doSomething();
        spesial();
    }

    void appear(){
        if(isCollide && !isDoing){
            if(interact==KeyCode.I){
                int_button_i.SetActive(true);
            }
            if(interact==KeyCode.E){
                int_button_e.SetActive(true);
            }
        }else {
            int_button_i.SetActive(false);
            int_button_e.SetActive(false);
        }

    }

    void doSomething(){
        bool isOn=handler.GetComponent<handler>().isElecticOn2;
        if(Input.GetKey(interact) && tookTime>0 && isOn){
            isDoing=true;
        }else if(Input.GetKeyUp(interact)){
            isDoing=false;
        }else{
            isDoing=false;
        }
    }

    void spesial(){
        if(isDoing){
            tookTime-=Time.deltaTime;
        }
        if(tookTime<=0 && player!=null){
            player.GetComponent<Player>().isBringing=true;
        }else if(!isDoing && tookTime>0 && player!=null && tookTime<player.GetComponent<Player>().tookTime){
            tookTime=player.GetComponent<Player>().tookTime;
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
           isCollide=true;
           player=collision.gameObject;
           interact=collision.GetComponent<Player>().interactKey;
           tookTime=collision.GetComponent<Player>().tookTime;
        }
    }
    
    void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
           isCollide=false;
           interact=KeyCode.None;
           player=null;
        }
    }
}
