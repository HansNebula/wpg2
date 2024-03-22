using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class objectCari : MonoBehaviour
{
   public GameObject find, listObject;
    public bool visible=false;

    void Update(){
        find.SetActive(visible);
        listObject.SetActive(visible);
    }
    public void toggleVisible(){
        visible=!visible;
    }
}