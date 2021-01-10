using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    private float hiz = 1f;
    private float hizlanma = 0.2f;
    private float maxHiz = 3.2f;

    private float kolayHiz = 2.6f;
    private float normalHiz = 3.2f;
    private float zorHiz = 4.2f;

    [HideInInspector]
    public bool hareketliKamera;

    void Start()
    {
        if (OyunTercihleri.GetirKolayZorlukDurumu() == 1)
        {
            maxHiz = kolayHiz;
        }

        if (OyunTercihleri.GetirNormalZorlukDurumu() == 1)
        {
            maxHiz = normalHiz;
        }

        if (OyunTercihleri.GetirYuksekZorlukDurumu() == 1)
        {
            maxHiz = zorHiz;
        }

        hareketliKamera = true;
    }

   
    void Update()
    {
        if (hareketliKamera)
        {
            HareketliKamera();
        }
    }

    void HareketliKamera()
    {
        Vector3 depo = transform.position;
        float eskiY = depo.y;
        float yeniY = depo.y - (hiz * Time.deltaTime);
        depo.y = Mathf.Clamp(depo.y, eskiY, yeniY);
        transform.position = depo;
        hiz += hizlanma * Time.deltaTime;
        if (hiz > maxHiz)
            hiz = maxHiz;
    }

}
