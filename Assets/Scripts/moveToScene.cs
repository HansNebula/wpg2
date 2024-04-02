using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveToScene : MonoBehaviour
{
    void Update(){
       
    }
   public void pindah(string namaScene){
        SceneManager.LoadScene(namaScene);
   }

   public void quit(){
     Application.Quit();
   }
}
