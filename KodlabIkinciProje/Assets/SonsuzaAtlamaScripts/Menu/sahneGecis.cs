using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sahneGecis : MonoBehaviour
{
    public static sahneGecis ornek;

    [SerializeField]
    private GameObject fadePanel;

    [SerializeField]
    private Animator fadeAnim;

    private void Awake()
    {
        TekYap();
    }

    void TekYap()
    {
        if (ornek!= null)
        {
            Destroy(gameObject);
        }
        else
        {
            ornek = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadLevel(string bolum)
    {
        StartCoroutine(FadeInOut(bolum));
    }

    IEnumerator FadeInOut(string bolum)
    {
        fadePanel.SetActive(true);
        fadeAnim.Play("FadeIn");
        yield return StartCoroutine(YeniCoroutine.GercekZamaniBekle(1f));
        SceneManager.LoadScene(bolum);
        fadeAnim.Play("FadeOut");
        yield return StartCoroutine(YeniCoroutine.GercekZamaniBekle(.7f));
        fadePanel.SetActive(false);
    }
}
