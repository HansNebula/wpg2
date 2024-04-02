using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newInteractable : MonoBehaviour
{
    public GameObject handler;
    public GameObject player;
    public KeyCode interactKey;

    public GameObject  int_button_e;
    public GameObject seacrh;
    

    // public float rotateSpeed;

    public bool isCollide=false;
    public bool isDoing;

     //stuff
   
    void Start(){
        handler=GameObject.FindGameObjectWithTag("GameController");
        // int_button_i.SetActive(false);
        int_button_e.SetActive(false);
        seacrh.SetActive(false);
    }

    void Update(){
        appear();
        doSomething();
        
    }

    void appear(){
        if(isCollide){
            int_button_e.SetActive(true);
        }else {
            // int_button_i.SetActive(false);
            int_button_e.SetActive(false);
        }

    }

    void doSomething(){
        // bool El=handler.GetComponent<handler>().isElecticOn1;
       
        if(Input.GetKey(interactKey)){
            isDoing=true;
            seacrh.SetActive(true);
            // if(!El){
            //     isDoing=false;
            // }
        }
    }

   
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
           isCollide=true;
           interactKey=collision.GetComponent<Player>().interactKey;
        }
    }
    
    void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
           isCollide=false;
           interactKey=KeyCode.None;
           seacrh.SetActive(false);
        }
    }
}
