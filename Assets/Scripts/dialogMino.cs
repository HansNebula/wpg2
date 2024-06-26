using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dialogMino : MonoBehaviour
{
    public GameObject dialogBox, handler;
    public Animator anim;
    public Text nametag, dialogText;
    public GameObject opsi1, opsi2;
    string[] greetings=new string[]{//nyoba
        "Saya Mino Taurinus, bendahara dari Redleaf Herbal Healt. kepentingan saya di sini adalah mengikuti peraturan baru raja yaitu mengajukan Scroll pengajuan dana proyek"
    };
    string[] kop=new string[]{
        "Kesalahan pada bagian KOP Scroll pengajuan dana ini? Hmmm kurasa tidak ada yang salah disini"
    };

    string[] lb=new string[]{
        "Kebakaran terjadi tanpa sebab yang jelas, penyidikan juga masih berlangsung. Saya mengajukan ini agar renovasi gudang obat herbal segera bisa dilakukan.",
        "itu terjadi 3 hari yang lalu, kemungkinan saat malam hari karena gudang terbakar saat ada dalam keberadaan kosong",
        "Untuk sekarang sepertinya belum karena bukti di lokasi kejadian sangatlah sedikit, namun jika ada perkembangan akan segera saya sampaikan pada anda tuan"
    };
    string[] dana=new string[]{
        "Tentu saja, kristal frostglow memancarkan aura dingin yang pas untuk menyimpan obat, dan kayu winterpine dapat menahan suhu dingin itu agar tidak tersebar",
        "Sepertinya akan ada tuan, guna memberikan pengamanan ekstra agar kejadian serupa tidak terjadi lagi kedepannya. saya harap tuan Elions mau bekerja sama lagi nantinya",
        "Hmmm... Saya ragu untuk menjawabnya, namun biasanya nyonya Kalsia akan memberikannya dari dana darurat, jika ada insiden yang terjadi di apotek."
    };

    string[] stempel=new string[]{
        "Tidak ada tanda tangan dari pemimpin daerah? Ah maaf saya sepertinya lupa, setelah Scroll ini kalian terima, saya akan meminta tanda tangan tuan Luxius."
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
        nametag.text="Mino Taurinus";
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
                StopCoroutine(talking(0));
                anim.Play("voga_idle");
                m=0;
                n=0;
                break;
            case 1 : //perkenalan
                if(m>=greetings.Length){
                    n=90;
                }else{
                    dialogText.text=greetings[m];
                    StartCoroutine(talking(2f));
                }
                break;
            case 2 : //jika ditanya kop surat
                if(m>=kop.Length){
                    n=90;
                }else{
                    dialogBox.SetActive(true);
                    dialogText.text=kop[m];
                    StartCoroutine(talking(2f));
                }
                break;
            case 3 : //jika ditanya laterbelakang
                if(m==0){
                    dialogBox.SetActive(true);
                    dialogText.text=lb[0];
                    StartCoroutine(talking(2f));
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
                    StartCoroutine(talking(2f));
                }
                break;
            case 6 : //lanjutan case 3 (kapan)
                opsi1.SetActive(false);
                if(m==0){
                    dialogBox.SetActive(true);
                    dialogText.text=lb[1];
                    StartCoroutine(talking(2f));
                }else if(m==1){
                    dialogBox.SetActive(false);
                }
                break;
            case 7 : //lanjutan case 3 (bagaimana)
                opsi1.SetActive(false);
                if(m==0){
                    dialogBox.SetActive(true);
                    dialogText.text=lb[2];
                    StartCoroutine(talking(2f));
                }else if(m==1){
                    dialogBox.SetActive(false);
                }
                break;
            case 8 : //lanjutan case 4 (bagaimana)
                opsi2.SetActive(false);
                if(m==0){
                    dialogBox.SetActive(true);
                    dialogText.text=dana[0];
                    StartCoroutine(talking(2f));
                }else if(m==1){
                    dialogBox.SetActive(false);
                }
                break;
            case 9 : //lanjutan case 4 (apakah)
                opsi2.SetActive(false);
                if(m==0){
                    dialogBox.SetActive(true);
                    dialogText.text=dana[1];
                    StartCoroutine(talking(2f));
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
                    StartCoroutine(talking(2f));
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
                    StartCoroutine(talking(2f));
                }
                break;
            case 30 : //jika proposal TIDAK DITERIMA
                if(m==1){
                    n=90;
                    handler.GetComponent<globalEvent>().sceneProcessing();
                }else{
                    dialogBox.SetActive(true);
                    dialogText.text=decision[1];
                    StartCoroutine(talking(2f));
                }
                break;
        }
    }

    public void nextDialog(){
        m++;
        isTalking=false;
    }

    public void switchToCase(int value){
        n=value;
        m=0;
    }
    bool isTalking=false;
    public IEnumerator talking(float dur){
        float dur2 = dur;
        while(0<dur2 && !isTalking){
            dur2 -= Time.deltaTime;
            anim.Play("voga_talk");
            yield return null;
        }
        isTalking=true;
        anim.Play("voga_idle");
    }
}
