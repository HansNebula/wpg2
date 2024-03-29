﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class peta : MonoBehaviour
{
   public GameObject mainMap;
   public GameObject[] subMap;

   void Start(){
      mainMap.SetActive(false);
      for(int i=0;i<subMap.Length;i++){
         subMap[i].SetActive(false);
      }
   }
   public void showMain(){
    mainMap.SetActive(true);
   }

   public void showSubMap(int n){
    subMap[n].SetActive(true);
   }

   public void hideMain(){
    mainMap.SetActive(false);
   }

   public void hideSubMap(int n){
    subMap[n].SetActive(false);
   }
}
