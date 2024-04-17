using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kantor : MonoBehaviour
{
    public GameObject scroll;
    public GameObject char_;
    
    void Update(){
        visible();
    }
    void visible(){
        var global=gameObject.GetComponent<globalEvent>();
        scroll.SetActive(global.visited);
        char_.SetActive(global.visited);
    }
}
