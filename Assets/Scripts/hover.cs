using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hover : MonoBehaviour
{
   public GameObject opsi, label;
   public bool isCek, isHovButton;
   void Start(){
      opsi.SetActive(false);
      label.SetActive(false);
   }

   void Update(){
      isCek=gameObject.GetComponent<verify>().isCek;
      if(isCek) opsi.SetActive(false);
   }

   void OnMouseOver(){
      label.SetActive(true);
      if(!isCek)
         opsi.SetActive(true);
   }

   void OnMouseExit(){
      label.SetActive(false);
      opsi.SetActive(false);
   }

   public void cek(){
      print("cek");
   }
}
