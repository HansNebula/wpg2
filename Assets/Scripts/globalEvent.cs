using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public struct ver{
    public bool valid;
    public bool asked;
    public bool sudah;
};
public struct npc{
    public int id;
    public ver kop;
    public ver lb;
    public ver dana;
    public ver stempel;
    public bool diterima;
    public bool check;
    public bool conv;
    public int presentase;
};
public class globalEvent : MonoBehaviour
{
    //==== global =====
    public bool isTutorial;
    public int global_id;

    public float audio, music;
    public Sprite pointerWand, normalwand;
    public GameObject pointer;
    public bool isClickable, buttonProp;
    public bool visited;

    public bool isEnding(){
        if(voga_.check && waterion_.check){
            return true;
        }else{
            return false;
        }
    }

    public bool goodEnding(){
        if(isEnding()){
            if(voga_.diterima && !waterion_.diterima){
                return true;
            }else{
                return false;
            }
        }else{
            return false;
        }
    }

    //=================
    public npc voga_;
    public npc waterion_;
    public npc currentNpc;
    public int currentId;
    public bool kop, kop_valid, kop_asked;
    public bool lb, lb_valid, lb_asked;
    public bool dana, dana_valid, dana_asked;
    public bool stempel, stempel_valid, stempel_asked;

    void Start(){
        LoadData();
        currentId=global_id;
    }
    void Awake(){
        pointer=GameObject.FindGameObjectWithTag("pointer");
        PlayerPrefs.SetInt("visited", 1);
        LoadData();
    }

    void Update(){
        voga_.id=1;
        waterion_.id=2;
        if(global_id==1){
            currentNpc=voga_;
        }else if(global_id==2){
            currentNpc=waterion_;
        }

        // LoadData();
        debug();
        
        globalPointer();
        raycastPointer();
    }

    void debug(){
        currentId       = currentNpc.id;

        kop             = currentNpc.kop.sudah;
        kop_valid       = currentNpc.kop.valid;
        kop_asked       = currentNpc.kop.asked;

        lb              = currentNpc.lb.sudah;
        lb_valid        = currentNpc.lb.valid;
        lb_asked        = currentNpc.lb.asked;

        dana            = currentNpc.dana.sudah;
        dana_valid      = currentNpc.dana.valid;
        dana_asked      = currentNpc.dana.asked;

        stempel         = currentNpc.stempel.sudah;
        stempel_valid   = currentNpc.stempel.valid;
        stempel_asked   = currentNpc.stempel.asked;

        if(Input.GetKeyDown(KeyCode.R)){
            ResetData();
            LoadData();
        }

        bool cekVoga=PlayerPrefs.GetInt("voga_check")==1;
        bool cekWater=PlayerPrefs.GetInt("waterion_check")==1;

        print("voga : " + voga_.check + "\tData "+cekVoga);
        print("water : " + waterion_.check +"\tData "+cekWater);
        print("isEnding : "+isEnding());
        print("good ending : "+goodEnding());
    }

    public void StoreData(){
        //===== global =====
            PlayerPrefs.SetInt("visited", visited ? 1 : 0);
            // PlayerPrefs.SetInt("goodEnding", goodEnding ? 1 : 0);
            PlayerPrefs.SetInt("global_id", global_id);
        //============      voga        ================================================================
            //id
            PlayerPrefs.SetInt("voga_id", voga_.id);
            //kop
            PlayerPrefs.SetInt("voga_kop_cek", (voga_.kop.sudah ? 1 : 0));
            PlayerPrefs.SetInt("voga_kop_valid", (voga_.kop.valid ? 1 : 0));
            PlayerPrefs.SetInt("voga_kop_tanya", (voga_.kop.asked ? 1 : 0));
            //lb
            PlayerPrefs.SetInt("voga_lb_cek", (voga_.lb.sudah ? 1 : 0));
            PlayerPrefs.SetInt("voga_lb_valid", (voga_.lb.valid ? 1 : 0));
            PlayerPrefs.SetInt("voga_lb_tanya", (voga_.lb.asked ? 1 : 0));
            //dana
            PlayerPrefs.SetInt("voga_dana_cek", (voga_.dana.sudah ? 1 : 0));
            PlayerPrefs.SetInt("voga_dana_valid", (voga_.dana.valid ? 1 : 0));
            PlayerPrefs.SetInt("voga_dana_tanya", (voga_.dana.asked ? 1 : 0));
            //stempel
            PlayerPrefs.SetInt("voga_stempel_cek", (voga_.stempel.sudah ? 1 : 0));
            PlayerPrefs.SetInt("voga_stempel_valid", (voga_.stempel.valid ? 1 : 0));
            PlayerPrefs.SetInt("voga_stempel_tanya", (voga_.stempel.asked ? 1 : 0));
            //cek apakah sudah membuka proposal
            PlayerPrefs.SetInt("voga_conv", voga_.conv ? 1 : 0);
            //persentase
            PlayerPrefs.SetInt("voga_persentase", voga_.presentase);
            
            //bawah
            PlayerPrefs.SetInt("voga_check", (voga_.check ? 1 : 0));
            PlayerPrefs.SetInt("voga_diterima", (voga_.diterima ? 1 : 0));
        
        //============      waterion       ================================================================
            //id
            PlayerPrefs.SetInt("waterion_id", waterion_.id);
            //kop
            PlayerPrefs.SetInt("waterion_kop_cek", (waterion_.kop.sudah ? 1 : 0));
            PlayerPrefs.SetInt("waterion_kop_valid", (waterion_.kop.valid ? 1 : 0));
            PlayerPrefs.SetInt("waterion_kop_tanya", (waterion_.kop.asked ? 1 : 0));
            //lb
            PlayerPrefs.SetInt("waterion_lb_cek", (waterion_.lb.sudah ? 1 : 0));
            PlayerPrefs.SetInt("waterion_lb_valid", (waterion_.lb.valid ? 1 : 0));
            PlayerPrefs.SetInt("waterion_lb_tanya", (waterion_.lb.asked ? 1 : 0));
            //dana
            PlayerPrefs.SetInt("waterion_dana_cek", (waterion_.dana.sudah ? 1 : 0));
            PlayerPrefs.SetInt("waterion_dana_valid", (waterion_.dana.valid ? 1 : 0));
            PlayerPrefs.SetInt("waterion_dana_tanya", (waterion_.dana.asked ? 1 : 0));
            //stempel
            PlayerPrefs.SetInt("waterion_stempel_cek", (waterion_.stempel.sudah ? 1 : 0));
            PlayerPrefs.SetInt("waterion_stempel_valid", (waterion_.stempel.valid ? 1 : 0));
            PlayerPrefs.SetInt("waterion_stempel_tanya", (waterion_.stempel.asked ? 1 : 0));
            //cek apakah sudah membuka proposal
            PlayerPrefs.SetInt("waterion_conv", waterion_.conv ? 1 : 0);
            //persentase
            PlayerPrefs.SetInt("waterion_persentase", waterion_.presentase);
            
            //bawah
            PlayerPrefs.SetInt("waterion_check", (waterion_.check ? 1 : 0));
            PlayerPrefs.SetInt("waterion_diterima", (waterion_.diterima ? 1 : 0));

    }

    public void LoadData(){
        //===== global =====
            visited = PlayerPrefs.GetInt("visited")==1;
            // goodEnding() = PlayerPrefs.GetInt("goodEnding")==1;
            global_id=PlayerPrefs.GetInt("global_id"); 
        //============      voga        ================================================================
            //id
            voga_.id = PlayerPrefs.GetInt("voga_id");
            //kop
            voga_.kop.sudah = PlayerPrefs.GetInt("voga_kop_cek")==1;
            voga_.kop.valid = PlayerPrefs.GetInt("voga_kop_valid")==1;
            voga_.kop.asked = PlayerPrefs.GetInt("voga_kop_tanya")==1;
            //lb
            voga_.lb.sudah = PlayerPrefs.GetInt("voga_lb_cek")==1;
            voga_.lb.valid = PlayerPrefs.GetInt("voga_lb_valid")==1;
            voga_.lb.asked = PlayerPrefs.GetInt("voga_lb_tanya")==1;
            //dana
            voga_.dana.sudah = PlayerPrefs.GetInt("voga_dana_cek")==1;
            voga_.dana.valid = PlayerPrefs.GetInt("voga_dana_valid")==1;
            voga_.dana.asked = PlayerPrefs.GetInt("voga_dana_tanya")==1;
            //stempel
            voga_.stempel.sudah = PlayerPrefs.GetInt("voga_stempel_cek")==1;
            voga_.stempel.valid = PlayerPrefs.GetInt("voga_stempel_valid")==1;
            voga_.stempel.asked = PlayerPrefs.GetInt("voga_stempel_tanya")==1;
            //cek prop
            voga_.conv = PlayerPrefs.GetInt("voga_conv")==1;
            //persentase
            voga_.presentase = PlayerPrefs.GetInt("voga_persentase");
            
            //bawah
            voga_.check = PlayerPrefs.GetInt("voga_check")==1;
            voga_.diterima = PlayerPrefs.GetInt("voga_diterima")==1;
        
        //============      waterion        ==============================================================
            //id
            waterion_.id = PlayerPrefs.GetInt("waterion_id");
            //kop
            waterion_.kop.sudah = PlayerPrefs.GetInt("waterion_kop_cek")==1;
            waterion_.kop.valid = PlayerPrefs.GetInt("waterion_kop_valid")==1;
            waterion_.kop.asked = PlayerPrefs.GetInt("waterion_kop_tanya")==1;
            //lb
            waterion_.lb.sudah = PlayerPrefs.GetInt("waterion_lb_cek")==1;
            waterion_.lb.valid = PlayerPrefs.GetInt("waterion_lb_valid")==1;
            waterion_.lb.asked = PlayerPrefs.GetInt("waterion_lb_tanya")==1;
            //dana
            waterion_.dana.sudah = PlayerPrefs.GetInt("waterion_dana_cek")==1;
            waterion_.dana.valid = PlayerPrefs.GetInt("waterion_dana_valid")==1;
            waterion_.dana.asked = PlayerPrefs.GetInt("waterion_dana_tanya")==1;
            //stempel
            waterion_.stempel.sudah = PlayerPrefs.GetInt("waterion_stempel_cek")==1;
            waterion_.stempel.valid = PlayerPrefs.GetInt("waterion_stempel_valid")==1;
            waterion_.stempel.asked = PlayerPrefs.GetInt("waterion_stempel_tanya")==1;
            //cek prop
            waterion_.conv = PlayerPrefs.GetInt("waterion_conv")==1;
            //persentase
            waterion_.presentase = PlayerPrefs.GetInt("waterion_persentase");
            
            //bawah
            waterion_.check = PlayerPrefs.GetInt("waterion_check")==1;
            waterion_.diterima = PlayerPrefs.GetInt("waterion_diterima")==1;

    }

    public void ResetData(){
        //===== global =====
            PlayerPrefs.SetInt("visited", 0);
            PlayerPrefs.SetInt("global_id", 1);

            //posisi
            PlayerPrefs.DeleteKey("posX");
            PlayerPrefs.DeleteKey("posY");
        //============      voga        ================================================================
            //id
            PlayerPrefs.SetInt("voga_id", 1);
            //kop
            PlayerPrefs.SetInt("voga_kop_cek", 0);
            PlayerPrefs.SetInt("voga_kop_valid", 0);
            PlayerPrefs.SetInt("voga_kop_tanya", 0);
            //lb
            PlayerPrefs.SetInt("voga_lb_cek", 0);
            PlayerPrefs.SetInt("voga_lb_valid", 0);
            PlayerPrefs.SetInt("voga_lb_tanya", 0);
            //dana
            PlayerPrefs.SetInt("voga_dana_cek", 0);
            PlayerPrefs.SetInt("voga_dana_valid", 0);
            PlayerPrefs.SetInt("voga_dana_tanya", 0);
            //stempel
            PlayerPrefs.SetInt("voga_stempel_cek", 0);
            PlayerPrefs.SetInt("voga_stempel_valid", 0);
            PlayerPrefs.SetInt("voga_stempel_tanya", 0);
            //cek apakah sudah membuka proposal
            PlayerPrefs.SetInt("voga_conv", 0);
            //persentase
            PlayerPrefs.SetInt("voga_persentase", 0);
            
            //bawah
            PlayerPrefs.SetInt("voga_check", 0);
            PlayerPrefs.SetInt("voga_diterima", 0);
        
        //============      waterion       ================================================================
            //id
            PlayerPrefs.SetInt("waterion_id", 2);
            //kop
            PlayerPrefs.SetInt("waterion_kop_cek", 0);
            PlayerPrefs.SetInt("waterion_kop_valid", 0);
            PlayerPrefs.SetInt("waterion_kop_tanya", 0);
            //lb
            PlayerPrefs.SetInt("waterion_lb_cek", 0);
            PlayerPrefs.SetInt("waterion_lb_valid", 0);
            PlayerPrefs.SetInt("waterion_lb_tanya", 0);
            //dana
            PlayerPrefs.SetInt("waterion_dana_cek", 0);
            PlayerPrefs.SetInt("waterion_dana_valid", 0);
            PlayerPrefs.SetInt("waterion_dana_tanya", 0);
            //stempel
            PlayerPrefs.SetInt("waterion_stempel_cek", 0);
            PlayerPrefs.SetInt("waterion_stempel_valid", 0);
            PlayerPrefs.SetInt("waterion_stempel_tanya", 0);
            //cek apakah sudah membuka proposal
            PlayerPrefs.SetInt("waterion_conv", 0);
            //persentase
            PlayerPrefs.SetInt("waterion_persentase", 0);
            
            //bawah
            PlayerPrefs.SetInt("waterion_check", 0);
            PlayerPrefs.SetInt("waterion_diterima", 0);
    }

    public void setGlobalId(){
        global_id=1;
    } 

    public void visiting(){
        PlayerPrefs.SetInt("visited", 1);
    }

    public void setPlayerPos(float x){
        PlayerPrefs.SetFloat("posX", x);
        // PlayerPrefs.SetFloat("posY", 0.09315658f);
    }

    public void openProp(){
        if(global_id==1){
            voga_.conv=true;
        }else if(global_id==1){
            waterion_.conv=true;
        }
    }

    public void globalPointer(){
        Cursor.visible=false;
        if(!isClickable){
            pointer.GetComponent<SpriteRenderer>().sprite=normalwand;
        }else if(isClickable){
            pointer.GetComponent<SpriteRenderer>().sprite=pointerWand;
        }
    }

   
    public void raycastPointer(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane gamePlane = new Plane(Vector3.forward, 0);
        RaycastHit2D hit;

        if (gamePlane.Raycast(ray, out float distance)){
            Vector3 hitPoint = ray.GetPoint(distance);
            pointer.transform.position = hitPoint;

            hit = Physics2D.Raycast(hitPoint, Vector2.zero);
        }
        else{
            pointer.transform.position = Vector3.zero;
            hit = new RaycastHit2D();
        }

        if (hit.collider != null){
            isClickable = hit.collider.CompareTag("clickable") || hit.collider.CompareTag("ButtonProp");
            // GameObject parentObject = hit.collider.gameObject.transform.parent.gameObject.transform.parent.gameObject;
            // parentObject.GetComponent<hover>().isHovButton=true;
        }
        else{
            isClickable = false;
        }
    }



    public void sceneProcessing(){
        if(isEnding()){
            SceneManager.LoadScene("ending");
        }else{
            SceneManager.LoadScene("Cutscene");
        }
    }
}
