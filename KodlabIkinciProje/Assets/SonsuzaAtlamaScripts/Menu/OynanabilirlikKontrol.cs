using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OynanabilirlikKontrol : MonoBehaviour
{
    [SerializeField]
    private GameObject durdurPanel, oyunSonuPanel;

    [SerializeField]
    private Text skorText, altinText, canText, oyunSonuSkorText, oyunSonuAltinText;

    [SerializeField]
    private GameObject hazirBtn;

    public static OynanabilirlikKontrol ornek;

    private void Awake()
    {
        OrnekYap();
    }


    private void Start()
    {
        Time.timeScale = 0f;
    }
    void OrnekYap()
    {
        if (ornek == null)
        {
            ornek = this;
        }
    }

    public void OyunuDurdur()
    {
        Time.timeScale = 0f;
        durdurPanel.SetActive(true);
    }

    public void OyunuSurdur()
    {
        Time.timeScale = 1f;
        durdurPanel.SetActive(false);
    }

    public void OyunuKapat()
    {
        Time.timeScale = 1f;
        sahneGecis.ornek.LoadLevel("MainMenu");
    }

    public void SkorHesapla(int skor)
    {
        skorText.text = "x" + skor;
    }

    public void AltinHesapla(int altinSkor)
    {
        altinText.text = "x" + altinSkor;
    }

    public void CanHesapla(int canSkor)
    {
        canText.text = "x" + canSkor;
    }

    public void oyunSonuPanelAc(int sonSkor, int sonAltin)
    {
        oyunSonuPanel.SetActive(true);
        oyunSonuSkorText.text = sonSkor.ToString();
        oyunSonuAltinText.text = sonAltin.ToString();
        StartCoroutine(OyunSonuPanelYukle());
    }

    IEnumerator OyunSonuPanelYukle()
    {
        yield return new WaitForSeconds(3f);
        sahneGecis.ornek.LoadLevel("MainMenu");
    }

    public void OyunuBaslat()
    {
        Time.timeScale = 1f;
        hazirBtn.SetActive(false);
    }

    public void KarakterOlunceOyunuYenidenBaslat()
    {
        StartCoroutine(KarakterOlunceYenidenBaslat());
    }

    IEnumerator KarakterOlunceYenidenBaslat()
    {
        yield return new WaitForSeconds(1f);
        sahneGecis.ornek.LoadLevel("level1");
    }
}
