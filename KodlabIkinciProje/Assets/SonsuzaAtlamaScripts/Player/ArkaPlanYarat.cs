using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArkaPlanYarat : MonoBehaviour
{
    private GameObject[] arkaplanlar;
    private float sonY;

    private void Start()
    {
        SonArkaplanSonY();
    }

    void SonArkaplanSonY()
    {
        arkaplanlar = GameObject.FindGameObjectsWithTag("ArkaPlan");
        sonY = arkaplanlar[0].transform.position.y;
        for (int i = 0; i < arkaplanlar.Length ; i++)
        {
            if (sonY > arkaplanlar[i].transform.position.y)
            {
                sonY = arkaplanlar[i].transform.position.y;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "ArkaPlan")
        {
            if (collision.transform.position.y == sonY)
            {
                Vector3 depo = collision.transform.position;
                float yukseklik = ((BoxCollider2D)collision).size.y;

                for (int i = 0; i < arkaplanlar.Length; i++)
                {
                    if (!arkaplanlar[i].activeInHierarchy)
                    {
                        depo.y -= yukseklik;
                        sonY = depo.y;
                        arkaplanlar[i].transform.position = depo;
                        arkaplanlar[i].SetActive(true);
                    }
                }
            }
        }
    }



}
