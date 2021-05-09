using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modstander : MonoBehaviour
{
    //hastigheden
    public Vector2 hastighedMinMax;
    float Hastighed;
    //laver en float varible
    float synligehøjde;

    void Start()
    {
       // Jeg bruger classesne fra det tidligere jeg har lavet.
        Hastighed = Mathf.Lerp (hastighedMinMax.x, hastighedMinMax.y, Sværdhedsgrad.Fåsværhedsgradprocent());

        // Her gør vi så den ved hvad den synlige højde fra skærmen er
        synligehøjde = -Camera.main.orthographicSize - transform.localScale.y;
    }


    void Update()
    {
        //Vector representere en retning og størrelsorden/magnitude som velocity og acceleration. Vector 2 er 2d og vector3 er 3d
        //Her gør vi så blokken falder ned ad
        transform.Translate(Vector3.down * Hastighed * Time.deltaTime);

        //Den ødelægger blokkene når de er ud fra den synligthøjde
        if (transform.position.y < synligehøjde)
        {
            Destroy(gameObject);
        }
    }
}
