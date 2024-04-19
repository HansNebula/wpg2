using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class interactRev : MonoBehaviour 
{
    public GameObject int_icon, obj;
    public string type, dest;
    public bool isCollide;

    void Start(){
        int_icon.SetActive(false);
    }
    void Update(){
        processing();
    }

    void processing(){
        if(isCollide && Input.GetKeyDown(KeyCode.E)){
            if(type=="meja"){
                SceneManager.LoadScene(dest);
            }else{
                obj.SetActive(true);
            }
        }
    }
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            isCollide=true;
            int_icon.SetActive(true);
        }
    }
    
    void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            isCollide=false;
            int_icon.SetActive(false);
        }
    }
}