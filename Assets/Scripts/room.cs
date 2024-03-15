using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class room : MonoBehaviour
{
    public int id;

    public float maxLevel;
    public float maxInSecond;
    public float persentage;
    
    public GameObject handler;
    public GameObject water;
    public GameObject[] doors;

    void Star(){
        
    }

    void Update(){
        handler=GameObject.FindGameObjectWithTag("GameController");
        calc();
    }
    public float n;
    void calc(){
        n=handler.GetComponent<handler>().waterLevel[id];
        Transform waterTransform = water.GetComponent<Transform>();
        if(n<maxInSecond){
            Vector3 newScale = new Vector3(waterTransform.localScale.x, theNum(n), waterTransform.localScale.z);
            waterTransform.localScale = newScale;
        }
    }

    float theNum(float n){
        float result=(maxLevel/maxInSecond)*n;
        return result;
    }
}
