using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzikKontrol : MonoBehaviour
{
    public static MuzikKontrol ornek;
    private AudioSource sesKaynagi;

    private void Awake()
    {
        TekYap();
        sesKaynagi = GetComponent<AudioSource>();
    }

    void TekYap()
    {
        if(ornek != null)
        {
            Destroy(gameObject);
        }
        else
        {
            ornek = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void MuzikOynat(bool oynat)
    {
        if (oynat)
        {
            if (!sesKaynagi.isPlaying)
            {
                sesKaynagi.Play();
            }
            
        }
        else
        {
            if (sesKaynagi.isPlaying)
            {
                sesKaynagi.Stop();
            }
        }
    }

}
