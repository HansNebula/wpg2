using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cari : MonoBehaviour
{
    public InputField inCari;
    public string Tcari;
    public Text hintText;
    public GameObject[] content;

    void Start(){
        insertGameobject();
        hide();
        hintText.text = "";
    }
    void Update(){
        // select();
        // hint();
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

    public void hint(){
        Tcari=inCari.text.ToLower();
        // print(Tcari);
        hintText.text="";
        foreach (var item in content){
            var tagComponent = item.GetComponentInChildren<tag>();
            if (tagComponent != null){
                string itemTag = tagComponent.tags.ToLower();
                if (!string.IsNullOrEmpty(Tcari) && itemTag.Contains(Tcari)){
                    int matchStartIndex = itemTag.IndexOf(Tcari);
                    int matchLength = Tcari.Length;
                    string formattedTag = itemTag.Substring(0, matchStartIndex) +
                                          "<b>" + itemTag.Substring(matchStartIndex, matchLength) + "</b>" +
                                          itemTag.Substring(matchStartIndex + matchLength);
                    
                    hintText.text += formattedTag + "\n";
                }
            }
        }
    }

    public void hintByFront(){
        Tcari=inCari.text.ToLower();
        // print(Tcari);
        hintText.text="";
        foreach (var item in content){
            var tagComponent = item.GetComponentInChildren<tag>();
            if (tagComponent != null){
                string itemTag = tagComponent.tags.ToLower();
                if (!string.IsNullOrEmpty(Tcari) && itemTag.StartsWith(Tcari)){
                    string formattedTag = "<b>" + itemTag.Substring(0, Tcari.Length) + "</b>" + itemTag.Substring(Tcari.Length);
                    hintText.text += formattedTag + "\n";
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
