using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float karakterHizi = 8f , maxSurat = 4f;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    private void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        KlavyeHareketleri();
    }

    void KlavyeHareketleri()
    {
        float Xdurdur = 0f;
        float surat = Mathf.Abs(myRigidbody.velocity.x);
        float yatay = Input.GetAxis("Horizontal");

        if(yatay > 0)
        {
            if(surat < maxSurat)
                Xdurdur = karakterHizi;
            
            Vector3 yon = transform.localScale;
            yon.x = 0.3f;
            transform.localScale = yon;
            myAnimator.SetBool("run", true);
        }

        else if (yatay < 0)
        {
            if (surat < maxSurat)
                Xdurdur = -karakterHizi;

            Vector3 yon = transform.localScale;
            yon.x = -0.3f;
            transform.localScale = yon;
            myAnimator.SetBool("run", true);
        }

        else
        {
            myAnimator.SetBool("run", false);
            myRigidbody.velocity = Vector2.zero;
        }

        myRigidbody.AddForce(new Vector2(Xdurdur, 0));
    }
}
