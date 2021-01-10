using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nesneToplama : MonoBehaviour
{
    void Aktifken()
    {
        Invoke("PasifYap", 6f);
    }

    void PasifYap()
    {
        gameObject.SetActive(false);
    }
}
