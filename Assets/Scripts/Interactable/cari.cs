using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cari : MonoBehaviour
{
    public InputField inCari;
    public string Tcari;

    public GameObject[] content;

    void Start(){
        insertGameobject();
        hide();
    }
    void Update(){
        // select();
    }

    void insertGameobject(){
        Transform parentTransform = transform; // Or use GetComponent<Transform>() if the script is not attached to the parent GameObject

        // Create an array to store the child GameObjects
        content = new GameObject[parentTransform.childCount];

        // Loop through each child and store them in the array
        for (int i = 0; i < parentTransform.childCount; i++)
        {
            content[i] = parentTransform.GetChild(i).gameObject;
        }
    }
    public void select(){
        Tcari=inCari.text.ToLower();
        for(int i=0;i<content.Length;i++){
            if(inCari.text==""){
                content[i].SetActive(false);
            }else{
                if(/*content[i].GetComponentInChildren<tag>().tags.ToLower().Contains(Tcari) ||*/ content[i].GetComponentInChildren<tag>().tags.ToLower() == Tcari){
                    content[i].SetActive(true);
                }else{
                    content[i].SetActive(false);
                }
            }
        }
    }

    void hide(){
        for(int i=0;i<content.Length;i++){
            content[i].SetActive(false);
        }
    }
}
