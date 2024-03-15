using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wire : MonoBehaviour
{
    public GameObject handler;
    public GameObject player;
    public KeyCode interact;

    public GameObject int_button_i, int_button_e;
    public GameObject progressBar;

    public bool isCollide=false;
    public bool isDoing;

    // stuff
    public int id;
    public float timeTook; 

    void Start(){
        handler=GameObject.FindGameObjectWithTag("GameController");
        int_button_i.SetActive(false);
        int_button_e.SetActive(false);
        n=timeTook;
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
        // handler.GetComponent<handler>().waterLevel[id]+=.5f;
        if(Input.GetKey(interact)){
            isDoing=true;
        }else if(Input.GetKeyUp(interact)){
            isDoing=false;
            
        }
    }

    void spesial(){
        if(isDoing){
            fixing();
        }else{
            n=timeTook;
        }
    }

    public float n;
    void fixing(){
        n-=Time.deltaTime;
        if(n<=0){
            this.gameObject.SetActive(false);
        }
    }
    
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
           isCollide=true;
           interact=collision.GetComponent<Player>().interactKey;
        }
    }
    
    void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
           isCollide=false;
           interact=KeyCode.None;
        }
    }
}
