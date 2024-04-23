using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class peta : MonoBehaviour
{
   public GameObject mainMap;
   public GameObject subMap;
   public Sprite[] subMapSprites;

   public GameObject[] buttons;

   void Start(){
      mainMap.SetActive(false);
      subMap.SetActive(false);
   }
   public void showMain(){
    mainMap.SetActive(true);
   }

   public void showSubMap(int n){
      subMap.SetActive(true);
      subMap.GetComponent<SpriteRenderer>().sprite = subMapSprites[n];
      for(int i = 0; i < buttons.Length;i++){
         buttons[i].SetActive(false);
      }
   }

   public void hideMain(){
    mainMap.SetActive(false);
   }

   public void backToMain(){
      for(int i = 0; i < buttons.Length;i++){
         buttons[i].SetActive(true);
      }
   }
}
