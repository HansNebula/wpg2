using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class triggerManager : MonoBehaviour
{
    public GameObject[] buttons;


    public void clicking(){
        for (int i = 0;i<buttons.Length;i++){
            buttons[i].SetActive(false);
        }
    }

    public void showBack(){
        for (int i = 0;i<buttons.Length;i++){
            buttons[i].SetActive(true);
        }
    }
}
