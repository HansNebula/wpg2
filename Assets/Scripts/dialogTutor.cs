using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class dialogTutor : MonoBehaviour
{
    public GameObject dialogBox, dialogKepala, handler, nextButton;
    // public Animator anim;
    public Text nametag, dialogText, textKepala;
    public GameObject back, pause, prop;
    public int n, m;
    bool isTalking=true;
    string[] kantor=new string[]{
        "Gunakan tombol '<b>D</b>' untuk bergerak ke kanan dan '<b>A</b>' untuk bergerak ke kiri",
        "Meja kerja Anda di sebelah kanan, Tuan Elio",
        "Tekan tombol '<b>E</b>' untuk masuk ke meja kerja anda"
    };
    string[] kantor2=new string[]{
        "Selamat Anda telah menguasai kendali dasar pertama Anda",
        "Sekarang mari temui pengaju proposal pertama hari ini, orang itu telah menunggu di meja kerja Anda",
        "Meja kerja Anda di sebelah kanan, Tuan Elio"
    };

    string[] tahap1=new string[]{
        "Selamat pagi tuan Elions, perkenalkan saya adalah Aira Magicius, penyihir dari Akademi Sihir Kerajaan Maginesia yang akan menjadi pemandu anda disini",
        "Saya peringatkan anda ya tuan Elions yang terhormat, jangan lewatkan apapun arahan saya, agar pekerjaan anda berjalan baik dan anda tidak kebingungan",
        "Baik sebelumnya saya ucapkan selamat, anda telah terpilih untuk menjadi Inspektur utama di D' Scroll Inspector, ya walau ini hanya kantor cabang saja sih hehe",
        "Namun tetap, Integritas dan kejujuran akan menjadi kewajiban kita selama bekerja disini",
        "Baiklah, disini saya akan menjadi Asisten anda tuan Elions, saya akan membantu proses inspeksi dengan sihir dan peralatan sihir yang sudah saya siapkan",
        "Ngomong ngomong, aku merasakan aura kedatangan seseorang, sepertinya waktunya kita untuk bekerja",
        "Tenang, aku akan memandumu dengan sihir telepati milikku agar semuanya lancar. semoga hari pertamamu lancar Tuan Elions"
    };
    string[] tahap2_mino=new string[]{
        "Saya Mino Taurinus, bendahara dari Redleaf Herbal Healt. kepentingan saya disini adalah mengikuti peraturan baru raja yaitu mengajukan Scroll pengajuan dana proyek"
    };
    string[] tahap2=new string[]{   
        "Oke sekarang tuan Elions buka Scroll pengajuan dana itu",
        "Di tiap Scrolll akan ada 4 bagian yang akan Tuan Elions Inpeksi, yaitu pertama bagian <b>‘Kop’</b> yang berisi identitas perusahaan yang mengirim scroll ini",
        "Bagian kedua adalah <b>‘Isi’</b> yang berisi latar belakang dan tujuan dari dibuatnya Scroll pengajuan dana ini",
        "Bagian ketiga adalah <b>‘Rincian Dana’</b> yang berisi detail dana yang akan digunakan untuk proyek yang diajukan",
        "Di sini juga ada <b>Refrensi harga</b> rata rata untuk tiap produk yang di dalam Scroll, jadi anda bisa menghitungnya sendiri nanti, apakah rincian dana nya benar atau tidak",
        "Bagian terakhri adalah </b>‘Tanda tangan dan Stempel resmi’</b> yang berisikan gambar stempel resmi milik daerah bersangkutan dan tanda tangan sah dari pemimpin daerah",
        "Setelah itu kau bisa menginspeksi tiap bagian ini setelah kau baca dan mencari informasi seputar data yang ada dalam proposal itu",
        "Nantinya jika kau merasa datanya sesuai maka <b>‘Terima’</b> kan bagian itu, jika kau merasa ada <b>‘manipulasi data’</b> maka <b>‘Tolak’</b>. dan jika kamu merasa ragu, kamu bisa bertanya pada pengirim Scroll"
    };

    void Start(){
        Scene currentScene=SceneManager.GetActiveScene();
        nametag.text = "Aira Magisius";
        dialogText.text = "";
        isTalking=false;
        m=0;
        if(currentScene.name=="tutorial1"){
            n=0;
        }else if(currentScene.name=="kantor"){
            n=10;
        }else if(currentScene.name=="SceneMeja"){
            n=20;
        }
        
    }
    void Update(){
        handler=GameObject.FindGameObjectWithTag("GameController");
        if (!isTalking){
            dialogManual();
        }
    }

    public void dialogManual(){
        switch(n){
            case 90:
                dialogBox.SetActive(false);
                m=0;
                break;
            case 0:
                if(m<tahap1.Length){
                    dialogBox.SetActive(true);
                    StartCoroutine(TypeText(tahap1[m], dialogText)); 
                }else{
                    n=1;
                    dialogBox.SetActive(false);
                }
                break;
            case 1: back.GetComponent<Animator>().Play("button"); break;
            case 10://Kantor
                if(m<2 && PlayerPrefs.GetInt("visited")==0){
                    dialogBox.SetActive(true);
                    StartCoroutine(TypeText(kantor[m], dialogText)); 
                }else{
                    n=90;
                }
                break;
            case 11: 
                if(m==0){
                    dialogText.text="";
                    StartCoroutine(TypeText(kantor[1], dialogText)); 
                    dialogBox.SetActive(true);
                }else{
                    dialogBox.SetActive(false);
                }
                break;
            case 12: 
                if(m==0){
                    dialogText.text="";
                    StartCoroutine(TypeText(kantor[2], dialogText)); 
                    dialogBox.SetActive(true); 
                }else{
                    dialogBox.SetActive(false);
                }
                break;
            case 20://meja inspeksi
                if(m==0){
                    dialogBox.SetActive(true);
                    StartCoroutine(TypeText(tahap2_mino[m], dialogText));
                    nametag.text="Mino Taurinus";
                }else{
                    dialogBox.SetActive(false);
                    n=21;
                    m=0;
                }
                break;
            case 21: 
                if(m==0){
                    dialogKepala.SetActive(true);
                    StartCoroutine(TypeText(tahap2[0], textKepala));
                    
                }else if(m==1){
                    dialogKepala.SetActive(false);
                    //animasi untuk buka proposal di sini
                }else if(m==2){
                    dialogKepala.SetActive(true);
                    StartCoroutine(TypeText(tahap2[m-1], textKepala));
                    //highlight kop
                }else if(m==3){
                    dialogKepala.SetActive(true);
                    StartCoroutine(TypeText(tahap2[m-1], textKepala));
                    //highlight isi
                }else if(m==4){
                    dialogKepala.SetActive(true);
                    StartCoroutine(TypeText(tahap2[m-1], textKepala));
                    //highlight dana
                }else if(m==5){
                    dialogKepala.SetActive(true);
                    StartCoroutine(TypeText(tahap2[m-1], textKepala));
                    //highlight harga
                }else if(m==6){
                    dialogKepala.SetActive(true);
                    StartCoroutine(TypeText(tahap2[m-1], textKepala));
                    //highlight stempel
                }else if(m==7 || m==8){
                    dialogKepala.SetActive(true);
                    StartCoroutine(TypeText(tahap2[m-1], textKepala));
                }else{
                    dialogKepala.SetActive(false);
                    n=22;
                    m=0;
                }
                break;
            case 22:
                PlayerPrefs.SetInt("tahap2", 1);
                break;
            
        }
    }
    float delay=0.03f;
    IEnumerator TypeText(string fullText, Text dialog)
    {
        isTalking = true;
        dialog.text = "";
        foreach (char letter in fullText)
        {
            nextButton.SetActive(false);
            dialog.text += letter;
            yield return null; // Yielding null waits for the next frame
        }
        // isTalking = false;
        nextButton.SetActive(true);
        
    }
    
    public void nextDialog(){
        m++;
        isTalking=false;
    }
    public void forProp(){
        if(handler.GetComponent<globalEvent>().global_id==0){
            nextDialog();
        }
    }
}
