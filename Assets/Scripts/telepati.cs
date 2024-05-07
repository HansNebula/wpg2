using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class telepati : MonoBehaviour
{
    public GameObject dialogBox, nextButton;
    public Text dialogText;
    public Animator anim;
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
        "Halo, dengan saya Cicero Tidewalker, narahubung telepati Seabearer Waterion Alliance, Perusahaan kapal layar terbaik di Maginesia",
        "Pengajuan dana untuk kapal Stultifera Navis? saya sudah lama tidak mendengar lagi tentang proyek itu, karena petinggi perusahaan menolak proyek ambisius itu",
        "Lautan Coralstorm terlalu berbahaya, dan perlu banyak sekali persiapan untuk menaklukannya, dan lagi S. W. A. adalah perusahaan kapal layar, bukan kapal perang",
        "Terimakasih telah menghubungi kami, saya harap informasi tadi bisa membantu"
    };

    string[] redhorn=new string[]{
        "Halo, dengan narahubung Redleaf Herbal Healt disini. ada yang bisa saya bantu?",
        "Pengajuan dana untuk renovasi gudang penyimpanan Arcane Essence? hal itu benar, kebakaran yang terjadi membuat gudang hancur dan harus segera di renovasi",
        "banyak masyarakat membutuhkan persediaan Arcane Essence sekarang, semoga tuan inspektur mau bekerja sama, terimakasih sudah menghubungi"
    };

    string[] redroot=new string[]{
        "Halo, saya Relina Viperia narahubung Redleaf Herbal Healt, apakah ada yang bisa saya bantu disini?",
        "Pengajuan dana untuk renovasi gudang yang kebakaran? kami memang mengalaminya, tapi itu masih dalam tahap investigasi dan mencari pelakunya",
        "Apalagi Arcane Essence disana beserta semua obat lain didalam gudang itu seperti sudah dipindahkan dulu sebelum kebakaran itu terjadi, itu sangatlah mencurigakan",
        "Sepertinya itu saja informasi yang bisa saya berikan tuan inspektur, jika ada perkembangan tentang kasus ini akan segera saya sampaikan, Terimakasih"
    };

    void Start(){
        n=0;
        dialogText.text="Masukan Kode Telepati untuk mencari Narahubung";
    }
    void Update(){
        if(menginformasi){
            proses();
        }else if(menunggu){
            dialogText.text = "<i>*Mencari Narahubung</i>";
        }
    }

    public void cari(Text input){
        m=0;
        n=0;
        menunggu=false;
        menginformasi=false;
        StartCoroutine(StartSearch(input));
    }

    IEnumerator StartSearch(Text input)
    {
        menunggu = true;
        float delay1=delay;
        while (delay1 > 0){
            delay1 -= Time.deltaTime;
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
        // anim.Play("aira_telepati 0");
    }


    int m=0;
    public void proses(){
        switch(n){
            case 90:
                anim.Play("default");
            break;
            case 0:
                dialogText.text="Narahubung tidak ditemukan, Masukan code dengan benar";
                anim.Play("aira_telepati 0");
                n=90;
                break;
            case 1:
                if(m<greenfangs.Length){
                    nextButton.SetActive(true);
                    dialogText.text=greenfangs[m];
                }else{
                    dialogText.text="<i>*Narahubung meninggalkan telepati</i>";
                    nextButton.SetActive(false);
                    menginformasi=false;
                    anim.Play("aira_telepati 0");
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
                    anim.Play("aira_telepati 0");
                }
                break;
            case 3:
                if(m<redhorn.Length){
                    nextButton.SetActive(true);
                    dialogText.text=redhorn[m];
                }else{
                    dialogText.text="<i>*Narahubung meninggalkan telepati</i>";
                    nextButton.SetActive(false);
                    menginformasi=false;
                    anim.Play("aira_telepati 0");
                }
                break;
            case 4:
                if(m<redroot.Length){
                    nextButton.SetActive(true);
                    dialogText.text=redroot[m];
                }else{
                    dialogText.text="<i>*Narahubung meninggalkan telepati</i>";
                    nextButton.SetActive(false);
                    menginformasi=false;
                    anim.Play("aira_telepati 0");
                }
                break;|
        }
    }

    public void next(){
        m++;
    }
}
