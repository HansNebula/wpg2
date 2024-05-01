using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogVoga : MonoBehaviour
{
    public GameObject dialogBox, handler;
    public Text nametag, dialogText;
    public GameObject opsi1, opsi2;
    string[] greetings=new string[]{
        "Saya Orchirus Voragoths dari Distrik Shadowgale di daerah Glomynesia dan menjadi perwakilan atas Yayasan Amal Voragoraths",
        "Saya ingin mengajukan Scroll Proposal untuk pendanaan, saya berharap Proposal saya bisa diterima"
    };
    string[] kop=new string[]{
        "Apakah ada kesalahan di Kop Scroll Proposal ini?",
        "Hmmm Maaf, tapi kurasa tidak ada yang salah disini"
    };

    string[] lb=new string[]{
        "Ketika warga desa Swampea sedang terlelap, Monster rawa bernama Murk Mauler menyerang desa itu. banyak orang dewasa tewas karena insiden itu, dan membuat para anak anak disana menjadi terlantar",
        "Sekitar 2 atau 3 hari lalu, maka dari itu saya sesegera mungkin mencari bantuan dana untuk membantu anak anak disana",
        "Para Orc sudah menyegel Murk Mauler lebih dari 25 tahun, sepertinya ada oknum yang merusak segel itu dan sengaja membebaskannya"
    };
    string[] dana=new string[]{
        "Dengan Batuan Darkhold, dibutuhkan untuk perlindungan bangunan dan orang didalamnya, kayu firefly digunakan karena aura hangat yang dipancarkan sangat diperlukan karena daerah dekat rawa sangat dingin",
        "Tidak ada, karena 70% dana sudah ditanggung oleh yayasan, jadi ini hanya seperti dana tambahan saja. jika pendanaan ini diterima maka Yayasan bisa membangun tempat penampungan yang lebih layak dan bagus",
        "Orc tidak memiliki budaya mencatat dan menulis rincian seperti itu, kami lebih suka mengingat ingat saja karena itu ingatan Orc sangat tajam.",
        "Namun saya usahakan akan ada tranparasi penggunaan dana tertulis untuk menghormati kerajaan yang memberi kami bantuan"
    };

    string[] stempel=new string[]{
        "Nyonya Evelyn sudah menyetujui pengajuan dana ini, karena dia juga mengecek tempat kejadian secara langsung. Jadi Stempel dan Tanda Tangan ini adalah asli"
    };

    string[] decision=new string[]{
        "Terimakasih banyak Tuan Elio, dan Nona Aira atas kerjasamanya, semoga kedepannya insiden seperti ini tidak terulang lagi",
        "Terimakasih atas waktunya, saya pamit undur diri karena saya mungkin akan meminta bantuan ke distrik lain"
    };

    public int n, m;

    void Start(){
        n=1;
        // dialogBox=GameObject.FindGameObjectWithTag("dialogBox");
        openProp();
        opsi1.SetActive(false);
        opsi2.SetActive(false);
    }
    void Update(){
        dialogManual();
        nametag.text="Orchirus Voragoths";
        handler=GameObject.FindGameObjectWithTag("GameController");
    }
    void openProp(){
        print("voga_conv :"+PlayerPrefs.GetInt("voga_conv"));
        if(PlayerPrefs.GetInt("voga_conv")==0){
            dialogBox.SetActive(true);
        }else{
            dialogBox.SetActive(false);
        }
    }

    void dialogManual(){
        switch(n){
            case 90:
                dialogBox.SetActive(false);
                m=0;
                n=0;
                break;
            case 1 : //perkenalan
                if(m>=greetings.Length){
                    n=90;
                }else{
                    dialogText.text=greetings[m];
                }
                break;
            case 2 : //jika ditanya kop surat
                if(m>=kop.Length){
                    n=90;
                }else{
                    dialogBox.SetActive(true);
                    dialogText.text=kop[m];
                }
                break;
            case 3 : //jika ditanya laterbelakang
                if(m==0){
                    dialogBox.SetActive(true);
                    dialogText.text=lb[0];
                }else if(m==1){
                    dialogBox.SetActive(false);
                    opsi1.SetActive(true);
                    // jika bertanya kapan maka ke case 6
                    // jika bertanya bagaimana maka ke case 7
                }
                break;
            case 4 : //jika ditanya pendanaan
                    opsi2.SetActive(true);
                    // jika bertanya bagaimana maka ke case 8
                    // jika bertanya apakah maka ke case 9
                    // jika bertanya transparansi maka ke case 10
                break;
            case 5 : //jika ditanya stempel
                if(m>=stempel.Length){
                    n=90;
                }else{
                    dialogBox.SetActive(true);
                    dialogText.text=stempel[m];
                }
                break;
            case 6 : //lanjutan case 3 (kapan)
                opsi1.SetActive(false);
                if(m==0){
                    dialogBox.SetActive(true);
                    dialogText.text=lb[1];
                }else if(m==1){
                    dialogBox.SetActive(false);
                }
                break;
            case 7 : //lanjutan case 3 (bagaimana)
                opsi1.SetActive(false);
                if(m==0){
                    dialogBox.SetActive(true);
                    dialogText.text=lb[2];
                }else if(m==1){
                    dialogBox.SetActive(false);
                }
                break;
            case 8 : //lanjutan case 4 (bagaimana)
                opsi2.SetActive(false);
                if(m==0){
                    dialogBox.SetActive(true);
                    dialogText.text=dana[0];
                }else if(m==1){
                    dialogBox.SetActive(false);
                }
                break;
            case 9 : //lanjutan case 4 (apakah)
                opsi2.SetActive(false);
                if(m==0){
                    dialogBox.SetActive(true);
                    dialogText.text=dana[1];
                }else if(m==1){
                    dialogBox.SetActive(false);
                }
                break;
            case 10 : //lanjutan case 4 (transparansi)
                opsi2.SetActive(false);
                if(m<dana.Length){
                    m=2;
                    dialogBox.SetActive(true);
                    dialogText.text=dana[m];
                }else {
                    dialogBox.SetActive(false);
                }
                break;

            case 20 : //jika proposal DITERIMA
                if(m==1){
                    n=90;
                    handler.GetComponent<globalEvent>().sceneProcessing();
                }else{
                    dialogBox.SetActive(true);
                    dialogText.text=decision[0];
                }
                break;
            case 30 : //jika proposal TIDAK DITERIMA
                if(m==1){
                    n=90;
                    handler.GetComponent<globalEvent>().sceneProcessing();
                }else{
                    dialogBox.SetActive(true);
                    dialogText.text=decision[1];
                }
                break;
        }
    }

    public void nextDialog(){
        m++;
    }

    public void switchToCase(int value){
        n=value;
        m=0;
    }
}
