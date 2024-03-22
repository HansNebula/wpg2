using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class meja : MonoBehaviour
{
    public GameObject handler;
    public GameObject player;
    public KeyCode interactKey;

    public GameObject int_button_e;
  
    public bool isCollide=false;
    public bool isDoing;

    public string namaScene;

  
    
    void Start(){
        handler=GameObject.FindGameObjectWithTag("GameController");
        // int_button_i.SetActive(false);
        int_button_e.SetActive(false);
    }

    void Update(){
        appear();
        doSomething();
        spesial();
    }

    void appear(){
        if(isCollide && !isDoing){
            if(interactKey==KeyCode.I){
                // int_button_i.SetActive(true);
            }
            if(interactKey==KeyCode.E){
                int_button_e.SetActive(true);
            }
        }else {
            // int_button_i.SetActive(false);
            int_button_e.SetActive(false);
        }

    }

    void doSomething(){
       
       
        if(Input.GetKey(interactKey)){
            isDoing=true;
            handler.GetComponent<handler>().isDesk=true;
            SceneManager.LoadScene(namaScene);
           
        }else if(Input.GetKeyUp(interactKey)){
            
        }
        else{
            isDoing=false;
        }
    }

    void spesial(){
        if(isDoing){
           
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
        }
    }
}
