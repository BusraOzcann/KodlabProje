using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkor : MonoBehaviour
{
    [SerializeField]
    private AudioClip altinSes, canSes;

    private Kamera kameraScript;

    private Vector3 oncekiKonum;

    private bool skorDurum;

    public static int skor;
    public static int canSayisi = 2;
    public static int altinSayisi;

    private void Awake()
    {
        kameraScript = Camera.main.GetComponent<Kamera>();
    }

    private void Start()
    {
        oncekiKonum = transform.position;
        skorDurum = true;
    }

    private void Update()
    {
        Skor();
    }

    void Skor()
    {
        if (skorDurum)
        {
            if (transform.position.y < oncekiKonum.y)
            {
                skor++;
            }
            oncekiKonum = transform.position;
            OynanabilirlikKontrol.ornek.SkorHesapla(skor);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Altin")
        {
            altinSayisi++;
            skor += 200;
            OynanabilirlikKontrol.ornek.SkorHesapla(skor);
            OynanabilirlikKontrol.ornek.AltinHesapla(altinSayisi);
            AudioSource.PlayClipAtPoint(altinSes, transform.position);
            collision.gameObject.SetActive(false);
        }

        if (collision.tag == "Can")
        {
            canSayisi++;
            skor += 300;
            OynanabilirlikKontrol.ornek.SkorHesapla(skor);
            OynanabilirlikKontrol.ornek.CanHesapla(canSayisi);
            AudioSource.PlayClipAtPoint(canSes, transform.position);
            collision.gameObject.SetActive(false);
        }

        if (collision.tag == "Sinirlar")
        {
            kameraScript.hareketliKamera = false;
            skorDurum = false;
            canSayisi--;
            transform.position = new Vector3(500, 500, 0);
            OyunYoneticisi.ornek.OyunDurumunuKontrolEt(skor, altinSayisi, canSayisi);
            
        }

        if (collision.tag == "Engel")
        {
            kameraScript.hareketliKamera = false;
            skorDurum = false;
            transform.position = new Vector3(500, 500, 0);
            canSayisi--;
            OyunYoneticisi.ornek.OyunDurumunuKontrolEt(skor, altinSayisi, canSayisi);

        }

    }
}
