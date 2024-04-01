using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
};
public class globalEvent : MonoBehaviour
{
    public npc voga_;
    public npc waterion_;
    public npc currentNpc;
    public int currentId, global_id;
    public bool kop;
    public bool lb;
    public bool dana;
    public bool stempel;

    void Start(){
        voga_.id=1;
        waterion_.id=2;
        LoadData();
        currentId=global_id;
    }

    void Update(){
        if(currentId==1){
            currentNpc=voga_;
        }else if(currentId==2){
            currentNpc=waterion_;
        }
    }

    public void StoreData(){
        //===== global =====
            PlayerPrefs.SetInt("global_id", global_id);
        //============      voga        ================================================================
            //id
            PlayerPrefs.SetInt("voga_id", voga_.id);
            //kop
            PlayerPrefs.SetBool("voga_kop_cek", voga_.kop.sudah);
            PlayerPrefs.SetBool("voga_kop_valid", voga_.kop.valid);
            PlayerPrefs.SetBool("voga_kop_tanya", voga_.kop.asked);
            //lb
            PlayerPrefs.SetBool("voga_lb_cek", voga_.lb.sudah);
            PlayerPrefs.SetBool("voga_lb_valid", voga_.lb.valid);
            PlayerPrefs.SetBool("voga_lb_tanya", voga_.lb.asked);
            //dana
            PlayerPrefs.SetBool("voga_dana_cek", voga_.dana.sudah);
            PlayerPrefs.SetBool("voga_dana_valid", voga_.dana.valid);
            PlayerPrefs.SetBool("voga_dana_tanya", voga_.dana.asked);
            //stempel
            PlayerPrefs.SetBool("voga_stempel_cek", voga_.stempel.sudah);
            PlayerPrefs.SetBool("voga_stempel_valid", voga_.stempel.valid);
            PlayerPrefs.SetBool("voga_stempel_tanya", voga_.stempel.asked);
            
            //bawah
            PlayerPrefs.SetBool("voga_check", voga_.check);
            PlayerPrefs.SetBool("voga_diterima", voga_.diterima);
        
        //============      waterion       ================================================================
            //id
            PlayerPrefs.SetInt("waterion_id", waterion_.id);
            //kop
            PlayerPrefs.SetBool("waterion_kop_cek", waterion_.kop.sudah);
            PlayerPrefs.SetBool("waterion_kop_valid", waterion_.kop.valid);
            PlayerPrefs.SetBool("waterion_kop_tanya", waterion_.kop.asked);
            //lb
            PlayerPrefs.SetBool("waterion_lb_cek", waterion_.lb.sudah);
            PlayerPrefs.SetBool("waterion_lb_valid", waterion_.lb.valid);
            PlayerPrefs.SetBool("waterion_lb_tanya", waterion_.lb.asked);
            //dana
            PlayerPrefs.SetBool("waterion_dana_cek", waterion_.dana.sudah);
            PlayerPrefs.SetBool("waterion_dana_valid", waterion_.dana.valid);
            PlayerPrefs.SetBool("waterion_dana_tanya", waterion_.dana.asked);
            //stempel
            PlayerPrefs.SetBool("waterion_stempel_cek", waterion_.stempel.sudah);
            PlayerPrefs.SetBool("waterion_stempel_valid", waterion_.stempel.valid);
            PlayerPrefs.SetBool("waterion_stempel_tanya", waterion_.stempel.asked);
            
            //bawah
            PlayerPrefs.SetBool("waterion_check", waterion_.check);
            PlayerPrefs.SetBool("waterion_diterima", waterion_.diterima);

    }

    public void LoadData(){
        //============      voga        ================================================================
            //id
            voga_.id = PlayerPrefs.GetInt("voga_id");
            //kop
            voga_.kop.sudah = PlayerPrefs.GetBool("voga_kop_cek");
            voga_.kop.valid = PlayerPrefs.GetBool("voga_kop_valid");
            voga_.kop.asked = PlayerPrefs.GetBool("voga_kop_tanya");
            //lb
            voga_.lb.sudah = PlayerPrefs.GetBool("voga_lb_cek");
            voga_.lb.valid = PlayerPrefs.GetBool("voga_lb_valid");
            voga_.lb.asked = PlayerPrefs.GetBool("voga_lb_tanya");
            //dana
            voga_.dana.sudah = PlayerPrefs.GetBool("voga_dana_cek");
            voga_.dana.valid = PlayerPrefs.GetBool("voga_dana_valid");
            voga_.dana.asked = PlayerPrefs.GetBool("voga_dana_tanya");
            //stempel
            voga_.stempel.sudah = PlayerPrefs.GetBool("voga_stempel_cek");
            voga_.stempel.valid = PlayerPrefs.GetBool("voga_stempel_valid");
            voga_.stempel.asked = PlayerPrefs.GetBool("voga_stempel_tanya");
            
            //bawah
            voga_.check = PlayerPrefs.GetBool("voga_check");
            voga_.diterima = PlayerPrefs.GetBool("voga_diterima");
        
        //============      waterion        ==============================================================
            //id
            waterion_.id = PlayerPrefs.GetInt("waterion_id");
            //kop
            waterion_.kop.sudah = PlayerPrefs.GetBool("waterion_kop_cek");
            waterion_.kop.valid = PlayerPrefs.GetBool("waterion_kop_valid");
            waterion_.kop.asked = PlayerPrefs.GetBool("waterion_kop_tanya");
            //lb
            waterion_.lb.sudah = PlayerPrefs.GetBool("waterion_lb_cek");
            waterion_.lb.valid = PlayerPrefs.GetBool("waterion_lb_valid");
            waterion_.lb.asked = PlayerPrefs.GetBool("waterion_lb_tanya");
            //dana
            waterion_.dana.sudah = PlayerPrefs.GetBool("waterion_dana_cek");
            waterion_.dana.valid = PlayerPrefs.GetBool("waterion_dana_valid");
            waterion_.dana.asked = PlayerPrefs.GetBool("waterion_dana_tanya");
            //stempel
            waterion_.stempel.sudah = PlayerPrefs.GetBool("waterion_stempel_cek");
            waterion_.stempel.valid = PlayerPrefs.GetBool("waterion_stempel_valid");
            waterion_.stempel.asked = PlayerPrefs.GetBool("waterion_stempel_tanya");
            
            //bawah
            waterion_.check = PlayerPrefs.GetBool("waterion_check");
            waterion_.diterima = PlayerPrefs.GetBool("waterion_diterima");

    }




}
