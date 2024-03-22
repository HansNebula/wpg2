using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hover : MonoBehaviour
{
   public GameObject opsi;
   public bool isCek;
   void Start(){
      opsi.SetActive(false);
   }

   void Update(){
      isCek=gameObject.GetComponent<verify>().isCek;
      if(isCek) opsi.SetActive(false);
   }

   void OnMouseOver(){
      if(!isCek)
         opsi.SetActive(true);
   }

   void OnMouseExit(){
      if(!isCek)
         opsi.SetActive(false);
   }

   public void cek(){
      print("cek");
   }
}
