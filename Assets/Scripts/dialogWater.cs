using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogWater : MonoBehaviour
{
    public GameObject dialogBox;
    public Text nametag, dialogText;
    public GameObject opsi1, opsi2, handler;
    string[] greetings=new string[]{
        "Selamat siang tuan Elio dan nona Aira yang terhormat, saya adalah perwakilan dari Seabearer Waterion Alliance, Vierro Waterion",
        "Kerajaan Maginesia pasti sudah sering mendengar tentang perusahaan kami yang menciptakan kapal kapal hebat yang sudah mengarungi banyak samudra",
        "Disini perusahaan kami membutuhkan pendanaan untuk membuat sebuah mahakarya, jadi izinkan saya mengajukan Scroll Proposal ini"
    };
    string[] kop=new string[]{
        "Alamat ini sudah pasti sesuai dan tidak mungkin salah, karena saya adalah salah satu direktur di perusahaan ini.",
        "Jadi sepertinya tidak ada kesalahan disini"
    };

    string[] lb=new string[]{
        "Dalam catatan sejarah, belum pernah ada satupun orang yang dapat menaklukan Perairan Coralstorm lalu menemukan tentang legenda lautan Everblue...",
        "Maka dari itu saya sangat ingin membuat sebuah kapal yang dapat mewujudkan mimpi itu dan mengungkap misteri yang ada",

        "Tentu saja, jika Perairan Coralstorm bisa ditaklukan maka pihak maritim bisa segera meneliti dan mengambil sumber daya alam yang ada disana. ",
        "Hal itu mungkin akan sangat menguntungkan bagi banyak pihak saya rasa...",

        "Selain itu mungkin hanyalah bahaya sepele untuk kapal semegah dan sehebat ‘Stultivera Navis’ hahaha, Tuan Elio tidak perlu khawatir"
    };
    string[] dana=new string[]{
        "Dengan memanfaatkan kekuatan Batuan Pyrosius ditambahkan dengan teknologi meriam perak yang destruktif, sepertinya akan mampu untuk memberikan serangan fatal pada Coral Colosus",
        "Jika kemungkinan ditengah produksi kapal terdapat bahan yang kurang, saya mohon agar kerajaan pusat berkenan untuk memberikan dana lebih untuk melengkapi bahan baku yang kurang",
        "Tentu saja tuan, anda tidak perlu khawatir soal transparasi dana proyek ini, perusahaan kami sudah memiliki nama besar dan tidak akan mengecewakan anda",
        "Namun saya usahakan akan ada tranparasi penggunaan dana tertulis untuk menghormati kerajaan yang memberi kami bantuan"
    };

    string[] stempel=new string[]{
        "Tuan Vasco awalnya menentang keras proyek ini karena dirasa Perairan Coralstorm untuk saat ini tidak perlu untuk dijelajah karena tingkat bahaya yang sangat tinggi juga",
        "Namun setelah berdiskusi lagi beliau pun akhirnya melembut dan menyetujui proyek besar ini, dan membuka dunia baru bagi banyak orang"
    };

    string[] decision=new string[]{
        "Terimakasih banyak Tuan Elio, dan Nona Aira atas kerjasamanya, semoga kedepannya insiden seperti ini tidak terulang lagi",
        "Terimakasih atas waktunya, saya pamit undur diri karena saya mungkin akan meminta bantuan ke distrik lain"
    };

    public int n, m;

    void Start(){
        n=1;
        // dialogBox=GameObject.FindGameObjectWithTag("dialogBox");
        dialogBox.SetActive(true);
        openProp();
        opsi1.SetActive(false);
        opsi2.SetActive(false);
    }
    void openProp(){
        if(PlayerPrefs.GetInt("water_conv")==0){
            dialogBox.SetActive(true);
        }else{
            dialogBox.SetActive(false);
        }
    }
    void Update(){
        dialogManual();
        nametag.text="Vierro Waterion";
        handler=GameObject.FindGameObjectWithTag("GameController");
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
                if(m<2){
                    dialogBox.SetActive(true);
                    dialogText.text=lb[0];
                }else{
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
                m=2;
                if(m<4){
                    dialogBox.SetActive(true);
                    dialogText.text=lb[1];
                }else {
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
