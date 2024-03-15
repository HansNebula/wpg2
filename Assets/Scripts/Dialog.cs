using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    int n=0;
    public Text dialogText, opsi1, opsi2;
    public GameObject dialogObj, opsiObj;
    string[] greetings, layer2, layer3, opsi;
    bool isColliding, isEnd;

    void Update(){
        dialogManual();
    }

    void dialogManual(){

        if(!isEnd)dialogObj.SetActive(isColliding);
        if(isEnd) ending();
        greetings=new string[]{
            "Halo, Astronot. Aku sudah lama tidak berjumpa astronot lain...", 
            "Apakah kamu astronot dari planet Bumi?"
        };
        opsi=new string[]{
            "Iya, Aku berasal Bumi",
            "Tidak, Aku berasal dari planet lain",
            "Mars",
            "Aku dari planet jauh"
        };
        layer2=new string[]{
            "Wah,\nKita dari planet yang sama",
            "Sungguh?\nDari planet mana kam berasal?",
            "Wah,\nSenang bisa bertemu dengan penduduk Mars",
            "Perjalananmu pasti sangat jauh dan lama."
        };
        if(n<2){
            dialogText.text=greetings[n];
            opsiObj.SetActive(false);
            key();
        }
        switch(n){
            case 2:
                opsiObj.SetActive(true);
                opsi1.text=opsi[0];
                opsi2.text=opsi[1];
                if(Input.GetKeyDown(KeyCode.Alpha1)){
                    dialogText.text=layer2[0];
                    opsiObj.SetActive(false);
                    isEnd=true;
                }else if(Input.GetKeyDown(KeyCode.Alpha2)){
                    opsiObj.SetActive(false);
                    n=3;
                }
                break;
            case 3:
                dialogText.text=layer2[1];
                opsiObj.SetActive(true);
                opsi1.text=opsi[2];
                opsi2.text=opsi[3];
                if(Input.GetKeyDown(KeyCode.Alpha1)){
                    dialogText.text=layer2[2];
                    opsiObj.SetActive(false);
                    isEnd=true;
                }else if(Input.GetKeyDown(KeyCode.Alpha2)){
                    dialogText.text=layer2[3];
                    opsiObj.SetActive(false);
                    isEnd=true;
                }
                break;
        }
    }

    void key(){
        if(Input.GetKeyDown(KeyCode.N)){
            n++;
        }
    }

    float time=3f;
    void ending(){
        n=5;
        if(isEnd){
            if(time>0){
                time-=Time.deltaTime;
                // print(time);
            }else if(time<=0){
                isEnd=false;
                isColliding=false;
                dialogObj.SetActive(false);
                time=3;
            }
        }

    }
    void OnTriggerEnter2D(Collider2D coll){
        if(coll.CompareTag("Player")){
            n=0;
            isColliding=true;
            isEnd=false;
        }
    }
    void OnTriggerExit2D(Collider2D coll){
        if(coll.CompareTag("Player")){
            n=0;
            isColliding=false;
        }
    }
}
