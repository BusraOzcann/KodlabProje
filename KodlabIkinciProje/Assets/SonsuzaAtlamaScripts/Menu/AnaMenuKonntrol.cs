using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnaMenuKonntrol : MonoBehaviour
{
    [SerializeField]
    private Button muzikBtn;

    [SerializeField]
    private Sprite[] muzikAcikKapali;

    private void Start()
    {
        KontrolMuzik();
    }

    void KontrolMuzik()
    {
        if (OyunTercihleri.GetirMuzikDurumu() == 1)
        {
            MuzikKontrol.ornek.MuzikOynat(true);
            muzikBtn.image.sprite = muzikAcikKapali[1];
        }
        else if(OyunTercihleri.GetirMuzikDurumu() == 0)
        {
            MuzikKontrol.ornek.MuzikOynat(false);
            muzikBtn.image.sprite = muzikAcikKapali[0];
        }
    }       

    public void OyunuBaslat()
    {
        OyunYoneticisi.ornek.oyunAnaMenudenBaslatildi = true;
        sahneGecis.ornek.LoadLevel("level1");
    }

    public void HighSkor()
    {
        SceneManager.LoadScene("YuksekSkor");
    }

    public void Options()
    {
        SceneManager.LoadScene("Ayarlar");
    }

    public void OyunuKapat()
    {
        Application.Quit();
    }

    public void MuzikButton()
    {
        if (OyunTercihleri.GetirMuzikDurumu() == 0)
        {
            OyunTercihleri.AyarlaMuzikDurumu(1);
            MuzikKontrol.ornek.MuzikOynat(true);
            muzikBtn.image.sprite = muzikAcikKapali[1];
        }

        else if (OyunTercihleri.GetirMuzikDurumu() == 1)
        {
            OyunTercihleri.AyarlaMuzikDurumu(0);
            MuzikKontrol.ornek.MuzikOynat(false);
            muzikBtn.image.sprite = muzikAcikKapali[0];
        }
    }

}
