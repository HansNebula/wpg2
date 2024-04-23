﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class telepati : MonoBehaviour
{
    public GameObject dialogBox, nextButton;
    public Text dialogText;
    public int n;
    public float delay;
    public bool menunggu, menginformasi;
    public string[] kataKunci;

    string[] greenfangs=new string[]{
        "Dengan Oriana Voragoraths disini, saya adalah narahubung telepati dari Yayasan Amal Voragoraths",
        "Pengajuan dana untuk membangun tempat penampungan dan perawatan di desa Swampea? Iya hal itu benar adanya, ketua kami sendiri yang datang untuk mengajukan dana",
        "Terimakasih telah menghubungi kami, saya harap pengajuan dana itu bisa diterima dengan baik"
    };

    string[] aquarush=new string[]{
        "belum",
        "ada",
        "dialognya"
    };

    void Start(){
        n=0;
    }
    void Update(){
        if(menginformasi){
            proses();
        }else if(menunggu){
            dialogText.text = "<i>*Mencari Narahubung</i>";
        }
    }

    public void cari(Text input){
        StartCoroutine(StartSearch(input));
    }

    IEnumerator StartSearch(Text input)
    {
        menunggu = true;
        while (delay > 0){
            delay -= Time.deltaTime;
            yield return null;
        }
        for (int i = 0; i < kataKunci.Length; i++){
            if (input.text.ToLower() == kataKunci[i].ToLower()){
                n = i + 1;
                break; // Exit the loop once a match is found
            }
        }
        menunggu = false;
        menginformasi = true;
    }


    int m=0;
    public void proses(){
        switch(n){
            case 0:
                dialogText.text="Narahubung tidak ditemukan, Masukan code dengan benar";
                break;
            case 1:
                if(m<greenfangs.Length){
                    nextButton.SetActive(true);
                    dialogText.text=greenfangs[m];
                }else{
                    dialogText.text="<i>*Narahubung meninggalkan telepati</i>";
                    nextButton.SetActive(false);
                    menginformasi=false;
                }
                break;
            case 2:
                if(m<aquarush.Length){
                    nextButton.SetActive(true);
                    dialogText.text=aquarush[m];
                }else{
                    dialogText.text="<i>*Narahubung meninggalkan telepati</i>";
                    nextButton.SetActive(false);
                    menginformasi=false;
                }
                break;
        }
    }

    public void next(){
        m++;
    }
}
