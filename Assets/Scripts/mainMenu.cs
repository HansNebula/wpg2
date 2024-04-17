using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMenu : MonoBehaviour
{
    void Awake(){
        gameObject.GetComponent<globalEvent>().ResetData();
        // ResetGlobal();
        Debug.Log("reset");
    }

    void ResetGlobal(){
        PlayerPrefs.SetInt("visited", 0);
        PlayerPrefs.SetInt("global_id", 0);
    }
}
