using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wheel : MonoBehaviour
{
    public GameObject handler;
    public GameObject player;
    public KeyCode interact;

    public GameObject int_button_i, int_button_e;
    public GameObject compas;

    public float rotateSpeed;

    public bool isCollide=false;
    public bool isDoing;

     //stuff
    public float globalDegree;
    public float currentDegree;

    void Start(){
        handler=GameObject.FindGameObjectWithTag("GameController");
        int_button_i.SetActive(false);
        int_button_e.SetActive(false);
        compas.SetActive(false);
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
        bool El=handler.GetComponent<handler>().isElecticOn1;
        if(Input.GetKey(interact)){
            isDoing=true;
            if(!El){
                isDoing=false;
            }
        }else if(Input.GetKeyUp(interact)){
            isDoing=false;
            compas.SetActive(false);
        }else{
            isDoing=false;
        }
    }

    void spesial(){
        if(isDoing){
            compas.SetActive(true);
            compas.GetComponent<Transform>().Rotate(Vector3.forward * -rotateSpeed);
        }
        currentDegree=compas.GetComponent<Transform>().eulerAngles.z;

        if(currentDegree >= globalDegree-3f && currentDegree <=globalDegree + 3f){
            // Debug.Log("B");
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
