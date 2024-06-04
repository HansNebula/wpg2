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
    public Animator animBuku, animBola, animPeta;
    bool isTalking=true;
    string[] kantor=new string[]{
        "Gunakan tombol '<b>D</b>' untuk bergerak ke kanan dan '<b>A</b>' untuk bergerak ke kiri",
        "<b>Meja Inspeksi</b> berada di sebelah kanan, Tuan Elio",
        "Tekan tombol '<b>E</b>' untuk masuk ke meja",
        "<b>Meja sihir</b> berada di sebelah kiri",
        "Hampiri Aira untuk melakukan <b>Telepati</b>",
        "Kembali ke <b>Meja Inspeksi</b>",
        "Hampiri <b>Meja Sihir</b> untuk mengaktifkan <b>Kristal Prekognisi</b>",
        "Kembali ke <b>Meja Inspeksi</b> untuk mengambil keputusan proposal"
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
        "Bagian terakhri adalah <b>‘Tanda tangan dan Stempel resmi’</b> yang berisikan gambar stempel resmi milik daerah bersangkutan dan tanda tangan sah dari pemimpin daerah",
        "Setelah itu kau bisa menginspeksi tiap bagian ini setelah kau baca dan mencari informasi seputar data yang ada dalam proposal itu",
        "Nantinya jika kau merasa datanya sesuai maka <b>‘Terima’</b> kan bagian itu, jika kau merasa ada <b>‘manipulasi data’</b> maka <b>‘Tolak’</b>. dan jika kamu merasa ragu, kamu bisa bertanya pada pengirim Scroll"
    };

    string[] tahap3=new string[]{
        "Baik sekarang akan kujelaskan padamu satu per satu tentang benda sihir yang sudah kusiapkan untuk membantu inspeksi",
        "Pertama adalah <b>‘Codex Search’</b> buku ini adalah sebuah artefak sihir legendaris miliki keluarga Magicius yang diwariskan turun temurun",
        "Buku ini memiliki kemampuan magis yaitu dia akan memberi anda informasi tentang apapun yang anda tuliskan disana, namun tetap ada batasan dan tidak segalanya dia tau",
        "Sekarang cobalah tuliskan <b>‘Arcane Essence’</b> disana, karena Tuan Mino menuliskan hal itu dalam Scroll pengajuan dananya",
        "Jadi setelah anda mendapatkan informasi seputar benda yang dicari, dan datanya cocok dengan yang ada di Scroll proposal, maka berarti datanya sesuai dengan fakta",
        "Lalu berikutnya adalah <b>Peta Maginesia</b>, ini memang hanya terlihat seperti biasa, namun didalam peta itu sudah kuberi sebuah sihir, coba kau sentuh petanya",
        "Jadi kau akan mendapatkan informasi dari setiap daerah yang kamu sentuh, informasi itu akan langsung muncul didalam pikiranmu. hehe keren kan sihir milikku",
        "Jadi kau bisa mencocokan antara data yang ada di daerah dengan yang ada di Scroll, terutama pada bagian <b>‘Stempel dan tanda tangan resmi’</b> pada tiap daerahnya.",
        "Terakhir adalah <b>‘Kristal Prekognisi’</b> benda ini dapat melihat kilasan masa lalu dari seseorang, anda hanya perlu meletakan tangan anda diatasnya, dan menyebutkan nama orangnya.",
        "Namun kilasan tersebut acak dan aku tidak bisa mengaturnya, satu hal yang aku tau adalah, Kilas masa lalu yang muncul merupakan momentum penting yang terjadi di hidup orang itu",
        "Untuk saat ini Kristal Prekognisi belum bisa digunakan, jika sudah bisa aku akan segera mengabari anda, jadi sekarang mari kembali menginspeksi semua bagian Scroll dahulu",
        "Oh iya tuan Elions, ada satu hal lagi yang ingin kusampaikan padamu sebelum kamu kembali ke meja inspeksi, mendekatlah padaku"
    };
    string[] tahap3_tele=new string[]{
        "Telepatiku ini juga bisa digunakan untuk mengubungi orang bersangkutan yang tertulis di <b>Scroll</b>, anda hanya perlu memberitahu saya <b>‘Code Telepati’</b> yang tertulis disana",
        "Sekarang masukan kode telepati yang tertulis di proposal itu",
        "jika anda lupa, kodenya adalah <b>Redhorn</b>",
        "Oke sekarang anda bisa kembali ke Meja Inspeksi, Tuan Elions\nTanyakan terkait proposal kepada Tuan Mino"
    };

    string[] tahap3_teleEnd=new string[]{
        "Baiklah. Sepertinya semua panduan menjadi inspektur sudah saya sampaikan, sekarang anda harus mencoba semuanya sendiri tuan Elions",
        "Tenang saya akan tetap ada disini menemani anda selalu, saya hanya ingin fokus untuk mengaktifkan kristal Prekognisi ini agar bisa digunakan"
    };

    string[] tahap4=new string[]{
        "Tuan Elions, sepertinya <b>Kristal Prekognisi</b> sudah siap untuk digunakan, sekarang ayo coba sentuh kristalnya dan sebutkan nama tuan Mino Taurinus dipikiran anda",
        "Silakan menuju <b>Meja Sihir</b>"
    };

    string[] tahap4_kristal=new string[]{
        "Gunakan <b>Kristal Prekognisi</b>",
        "Setelah melihat kilas balik tadi, silakan kembali ke <b>Meja Inspeksi</b>",
        "Dari kilas balik tadi, saya rasa kita bisa menyimpulkan bahwa proposal yang diajukan ini harus kita tolak"
    };

    string[] tahap5=new string[]{
        "Buka proposal dan pilih tolak"
    };

    void Start(){
        if(PlayerPrefs.GetInt("global_id")==0){
            Scene currentScene=SceneManager.GetActiveScene();
            nametag.text = "Aira Magisius";
            dialogText.text = "";
            isTalking=false;
            dialogBox.SetActive(false);
            print(currentScene.name);
            m=0;
            if(currentScene.name=="tutorial1"){
                n=0;
            }else if(currentScene.name=="kantor"){
                n=10;
            }else if(currentScene.name=="SceneMeja"){
                n=20;
            }else if(currentScene.name=="MejaSihir"){
                n=30;
            }else if(currentScene.name=="Telepati"){
                n=40;
                PlayerPrefs.SetInt("tele_d", 0);
            }
        }
    }
    void Update(){
        // handler=GameObject.FindGameObjectWithTag("GameController");
        if(handler.GetComponent<globalEvent>().isTutorial()){
            print("tahap :"+PlayerPrefs.GetInt("tahap")+"\tn: "+n);

            if (!isTalking){
                dialogManual();
            }
        }else{
            this.enabled = false;
            dialogKepala.SetActive(false);
        }
    }

    void forPropColl(){
        var fs = GetComponent<forScroll>();
        GameObject[] propComp = new GameObject[]{
            fs.kop,
            fs.latarBelakang,
            fs.dana,
            fs.instansi
        };
        for(int i=0;i<propComp.Length;i++){
            if(PlayerPrefs.GetInt("tahap")<4){
                propComp[i].GetComponent<Collider2D>().enabled = false;
            }else{
                propComp[i].GetComponent<Collider2D>().enabled = true;
            }
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
                    PlayerPrefs.SetInt("tahap", 2);
                }else if(PlayerPrefs.GetInt("visited")==1){
                    dialogBox.SetActive(false);
                    if(PlayerPrefs.GetInt("tahap")==3){
                        n=29;
                        m=3;
                    }else if(PlayerPrefs.GetInt("tahap")==4){
                        n=39;
                        m=4;
                    }else if(PlayerPrefs.GetInt("tahap")==5){
                        n=49;
                        m=5;
                    }else if(PlayerPrefs.GetInt("tahap")==6){
                        n=59;
                        m=6;
                    }else if(PlayerPrefs.GetInt("tahap")==7 || PlayerPrefs.GetInt("tahap")==8){
                        n=69;
                        m=7;
                    }
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
                forPropColl();
                if(m==0){
                    dialogBox.SetActive(true);
                    StartCoroutine(TypeText(tahap2_mino[m], dialogText));
                    nametag.text="Mino Taurinus";
                }else{
                    dialogBox.SetActive(false);
                    m=0;
                    if(PlayerPrefs.GetInt("tahap")==5){
                        n=50;
                        m=0;
                    }else if(PlayerPrefs.GetInt("tahap")==7 || PlayerPrefs.GetInt("tahap")==8){
                        n=70;
                    }else{
                        n=21;
                    }
                }
                break;
            case 21: 
                if(PlayerPrefs.GetInt("tahap")<6){  
                    if(m==0){
                        dialogKepala.SetActive(true);
                        StartCoroutine(TypeText(tahap2[0], textKepala));
                        
                    }else if(m==1){
                        dialogKepala.SetActive(false);
                        prop.GetComponent<Animator>().Play("prop");
                        // prop.GetComponent<Animator>().Play("New State");
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
                }else{
                    n=50;
                }
                break;
            case 22:
                back.GetComponent<Animator>().Play("Highlight");
                PlayerPrefs.SetInt("tahap", 3);
                break;
            case 29://instruksi untuk ke meja sihir
                if(m==3){
                    dialogBox.SetActive(true);
                    StartCoroutine(TypeText(kantor[m], dialogText)); 
                }else{
                    dialogBox.SetActive(false);
                }
                break;
            case 30://meja sihir
                if(PlayerPrefs.GetInt("tahap")<5){
                    if(m<tahap3.Length){
                        dialogKepala.SetActive(true);
                        StartCoroutine(TypeText(tahap3[m], textKepala));
                        if(m==1){
                            animBuku.Play("poping");//animasi buku
                        }else if(m==2){
                            animBuku.Play("New State");
                        }else if(m==3){
                            animBuku.Play("poping");//animasi buku
                        }else if(m==5){
                            animPeta.Play("petaPop");//animasi peta
                        }else if(m==8){
                            animBola.Play("bolaPop");//animasi bola sihir
                        }
                    }else{
                        dialogKepala.SetActive(false);
                        n=31;
                        m=0;
                    }
                }else if(PlayerPrefs.GetInt("tahap")==6){
                    n=60;
                    m=0;
                }else if(PlayerPrefs.GetInt("tahap")==7){
                    n=61;
                    m=1;
                }else{
                    dialogKepala.SetActive(false);
                }
                break;
            case 31:
                back.GetComponent<Animator>().Play("Highlight");
                PlayerPrefs.SetInt("tahap", 4);
                break;
            case 39:
                if(m==4){
                    dialogBox.SetActive(true);
                    StartCoroutine(TypeText(kantor[m], dialogText)); 
                }else{
                    dialogBox.SetActive(false);
                }
                break;
            case 40://tele
                if(m<tahap3_tele.Length-1){
                    // dialogBox.SetActive(true);
                    StartCoroutine(TypeText(tahap3_tele[m], dialogText));
                }else{
                    dialogBox.SetActive(false);
                    nextButton.SetActive(false);
                    n=41;
                    m=0;
                    PlayerPrefs.SetInt("tele_d", 0);
                }
                break;
            case 41:
                if(PlayerPrefs.GetInt("tele_d")==1){
                    StartCoroutine(TypeText(tahap3_tele[3], dialogText));
                    PlayerPrefs.SetInt("tahap", 5);
                    n=42;
                    m=0;
                }
                break;
            case 42: 
                if(m<tahap3_teleEnd.Length){
                    StartCoroutine(TypeText(tahap3_teleEnd[m-1], dialogText));
                    if(m==2){
                        back.GetComponent<Animator>().Play("Highlight");
                    }
                }else {
                    back.GetComponent<Animator>().Play("Highlight");
                }
                break;
            case 49://di kantor menuju meja inspeksi
                if(m==5){
                    dialogBox.SetActive(true);
                    StartCoroutine(TypeText(kantor[m], dialogText)); 
                }else{
                    dialogBox.SetActive(false);
                }
                break;
            case 50://kembali di meja proposal
                var globalEvent=handler.GetComponent<globalEvent>();
                if(globalEvent.mino_.kop.sudah && globalEvent.mino_.lb.sudah && globalEvent.mino_.dana.sudah && globalEvent.mino_.stempel.sudah){
                    dialogKepala.SetActive(true);
                    handler.GetComponent<forScroll>().scroll.SetActive(false);
                    if(PlayerPrefs.GetInt("tahap")==5){
                        m=0;
                        n=51;
                    }else if(PlayerPrefs.GetInt("tahap")==8){
                        n=70;
                        m=0;
                    }
                }
                break;
            case 51:
                if(m<tahap4.Length){
                        StartCoroutine(TypeText(tahap4[m], textKepala));
                        PlayerPrefs.SetInt("tahap", 6);
                    }else{
                        //animasi tombol keluar
                    }
                break;
            case 59://kantor ke meja sihir
                if(m==6){
                    dialogBox.SetActive(true);
                    StartCoroutine(TypeText(kantor[m], dialogText)); 
                }else{
                    dialogBox.SetActive(false);
                }
            
               break;
            case 60:
                if(m==0){
                    dialogKepala.SetActive(true);
                    StartCoroutine(TypeText(tahap4_kristal[m], textKepala));
                }else{
                    dialogKepala.SetActive(false);
                }
                break;
            case 61:
                if(m<tahap4_kristal.Length){
                    dialogKepala.SetActive(true);
                    StartCoroutine(TypeText(tahap4_kristal[m], textKepala));
                }else{
                    dialogKepala.SetActive(false);
                    PlayerPrefs.SetInt("tahap", 8);
                }
                break;
            case 69: //kantor ke meja inspeksi dari m sihir
                if(m==7){
                    dialogBox.SetActive(true);
                    StartCoroutine(TypeText(kantor[m], dialogText)); 
                }else{
                    dialogBox.SetActive(false);
                }
                break;
            case 70:
                // if(m==0){
                //     dialogKepala.SetActive(true);
                //     StartCoroutine(TypeText(tahap4_kristal[m], textKepala));
                // }else{
                //     dialogKepala.SetActive(false);
                // }
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
