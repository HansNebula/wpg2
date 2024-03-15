using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class handler : MonoBehaviour
{
    // public GameObject int_button_i, int_button_e;
    public float randRotate;
    public float submarineSpeed;
    public float countRotate;
    public float countLeak;
    public float countWire;
    public float limRot, limLeak, limWire;

    public int inLeak, inWire; 

    public bool isElecticOn1, isElecticOn2;

    public bool isDesk;

    public GameObject lvr1, lvr2;  
    // public GameObject compas;
    public GameObject[] wires, leaks;
    public float[] waterLevel=new float[9];
    public float maxWaterLevel;

    void Start(){
        maxWaterLevel=12f; 
        hide();
        // isElecticOn1=true;
        // isElecticOn2=true;
        countRotate=countLeak=countWire=20f;
        limLeak=limRot=limWire=65f;

    }

    void Update(){
        // isElecticOn1=lvr1.GetComponent<Lever>().isOn;
        // isElecticOn2=lvr2.GetComponent<Lever>().isOn;
        randomize();
        limitation();
    }
    void generateDegree(){
        randRotate=Random.Range(10f, 60f);
    }

    void hide(){
        foreach(var item in wires){
            item.SetActive(false);
        }
        foreach(var item in leaks){
            item.SetActive(false);
        }
    }

    void limitation(){
        // if(submarineSpeed>=40){
        //     submarineSpeed=40;
        // }
        // if(submarineSpeed<=0){
        //     submarineSpeed=0;
        // }
        // for (int i = 0; i < waterLevel.Length; i++) {
        //     if (waterLevel[i] > maxWaterLevel) {
        //         waterLevel[i] = maxWaterLevel + 0.1f;
        //     }else if (waterLevel[i] <= 0) {
        //         waterLevel[i] = 0;
        //     }
        // }
    }

    void randomize(){
        // countLeak-=Time.deltaTime*1;
        // countWire-=Time.deltaTime*1;
        // countRotate-=Time.deltaTime*1;

        // if(countLeak<=0){
        //     countLeak=Random.Range(5f, limLeak);
        //     inLeak=Random.Range(0, 8);
        //     leaks[inLeak].SetActive(true);
        //     if(limLeak>=10){
        //         limLeak-=10;
        //     }
        // }
        // if(countWire<=0){
        //     countWire=Random.Range(5f, limWire);
        //     inWire=Random.Range(0, 8);
        //     wires[inWire].SetActive(true);
        //      if(limWire>=10){
        //         limWire-=10;
        //     }
        // }
        // if(countRotate<=0){
        //     countRotate=Random.Range(5f, limRot);
        //     generateDegree();
        //      if(limRot>=15){
        //         limRot-=10;
        //     }
        // }
    }
    
    public float fuel;
    public float jarakTempuh;
    void status(){
        // if(fuel<=0 || !isElecticOn1){
        //     submarineSpeed-=Time.deltaTime;
        // }
        // if(submarineSpeed<=0){
        //     Time.timeScale=0;
        // }

    }

    public void pumping(){
        for(int i=0;i<waterLevel.Length;i++){
            waterLevel[i]-=Time.deltaTime*2.5f;
        }
    }

    public void forDesk(){
        isDesk=false;
    }
}
