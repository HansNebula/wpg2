using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Engine : MonoBehaviour
{
    public GameObject handler;
    public GameObject player;

    public KeyCode interact;

    public GameObject int_button_i, int_button_e;
    public GameObject progressBar;

    public bool isCollide=false;
    public bool isDoing;
    
    // stuff
    public bool isOn;

    public float subMSpeed;
    public float fuel;
    public float inSpeedBy=1.2f;


    void Start(){
        handler=GameObject.FindGameObjectWithTag("GameController");
        int_button_i.SetActive(false);
        int_button_e.SetActive(false);
        isOn=true;
    }

    void Update(){
        appear();
        doSomething();
        spesial();
        mainActivity();
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
        isOn=handler.GetComponent<handler>().isElecticOn1;
        if(Input.GetKey(interact)){
            isDoing=true;
            if(player!=null && player.GetComponent<Player>().isBringing==false){
                isDoing=false;
            }
        }else if(Input.GetKeyUp(interact)){
            isDoing=false;
        }
    }
    public float tookTime;
    public int b;
    void spesial(){
        if(player!=null){
            if(b==0){
                tookTime=player.GetComponent<Player>().tookTime;
                b++;
            }
            if(isDoing){
                tookTime-=Time.deltaTime;
                if(isDoing && tookTime<=0){
                    player.GetComponent<Player>().isBringing=false;
                    fuel+=50;
                    b=0;
                }
        
            }else if(!isDoing && tookTime>0 && player!=null && tookTime<player.GetComponent<Player>().tookTime){
                tookTime=player.GetComponent<Player>().tookTime;
            }
        }
        subMSpeed=handler.GetComponent<handler>().submarineSpeed;
    }

    void mainActivity(){
        handler.GetComponent<handler>().fuel=fuel;
        if(isOn){
            fuel-=Time.deltaTime;
            if(fuel>0){
                handler.GetComponent<handler>().submarineSpeed+=Time.deltaTime*inSpeedBy;
            }
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
           isCollide=true;
           interact=collision.GetComponent<Player>().interactKey;
           player=collision.gameObject;
        }
    }
    
    void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
           isCollide=false;
           interact=KeyCode.None;
        }
    }
}
