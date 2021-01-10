using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NesneKaldir : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destek" || collision.tag == "Engel")
        {
            collision.gameObject.SetActive(false);
        }
    }
}
