using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visitTrigger : MonoBehaviour
{
    void Start(){
        gameObject.GetComponent<globalEvent>().visiting();
        Debug.Log("visit");
    }
}
