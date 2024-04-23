using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class prekognisi : MonoBehaviour 
{
    public GameObject handler,warning, opsi;
    public Text opsiText;

    globalEvent globalEvent;

    void Start(){
        handler=GameObject.FindGameObjectWithTag("GameController");
        warning.SetActive(false);
        opsi.SetActive(false);
    }

    void Update(){
        globalEvent=handler.GetComponent<globalEvent>();
    }

    public void prekognisiFunc(){
        print(globalEvent.voga_.kop.sudah+" "+globalEvent.voga_.lb.sudah+" "+globalEvent.voga_.dana.sudah+" "+globalEvent.voga_.stempel.sudah);
        switch(globalEvent.global_id){
            case 1:
                if(globalEvent.voga_.kop.sudah && globalEvent.voga_.lb.sudah && globalEvent.voga_.dana.sudah && globalEvent.voga_.stempel.sudah){
                    opsi.SetActive(true);
                    opsiText.text="Apakah anda ingin melihat masa lalu Orchirus Voragoraths?";
                }else{
                    opsi.SetActive(false);
                    warning.SetActive(true);
                }
                break;
            case 2: 
                if(globalEvent.waterion_.kop.sudah && globalEvent.waterion_.lb.sudah && globalEvent.waterion_.dana.sudah && globalEvent.waterion_.stempel.sudah){
                    opsiText.text="Apakah anda ingin melihat masa lalu Vierro Waterion?";
                    opsi.SetActive(true);
                }else{
                    opsi.SetActive(false);
                    warning.SetActive(true);
                }
                break;
        }
    }
}