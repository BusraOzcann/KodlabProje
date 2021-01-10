using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private PlayerKontrol playerHareket;

    private void Start()
    {
        playerHareket = GameObject.Find("Player").GetComponent<PlayerKontrol>();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        if(gameObject.name == "SolBtn")
        {
            playerHareket.AyarlaSolaGit(true);
        }
        else
        {
            playerHareket.AyarlaSolaGit(false);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        playerHareket.HareketiDurdur();
    }
}
