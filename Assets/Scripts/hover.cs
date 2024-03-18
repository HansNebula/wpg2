using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hover : MonoBehaviour
{
   public GameObject opsi;

   void Start(){
    opsi.SetActive(false);
   }

   void OnMouseOver(){
    opsi.SetActive(true);
   }

   void OnMouseExit(){
    opsi.SetActive(false);
   }
}
