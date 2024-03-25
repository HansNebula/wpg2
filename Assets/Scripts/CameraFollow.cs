using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
	public float selisih, limitCamera;
	
	void Update(){
		if(target){
			Vector3 to = transform.position;
            to.x = target.position.x;
            if(to.x<=limitCamera && to.x>=-limitCamera){
                transform.position = Vector3.Lerp(transform.position, to, selisih * Time.deltaTime);
            }
		}
	}
			
}