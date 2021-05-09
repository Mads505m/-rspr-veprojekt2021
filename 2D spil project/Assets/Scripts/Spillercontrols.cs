using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spillercontrols : MonoBehaviour
{
    //her definere vi værdien via float.
    public float speed = 7;
    //laver en event. Events er noget der bliver brugt til user actions
    public event System.Action SpillerDød;

    //Måling af halvdelen af skærmen er i det man kalder WorldUnits
    float screenHalfWidthInWorldUnits;

    void Start()
    {
        float halfPlayerWidth = transform.localScale.x / 2f;
        //Udregner værdien af variablen. Her vælger vi Main camera, som den hedder i Unity og vores HalfPlayerWidth, som gør vi at vi også tager bredden a spilleren med.
        //Hvis vi ikke tager spillerens bredd, så skifter spillerne siden når den kun er halvdelen ude af skærmen ca.
        screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
    }


    void Update()
    {
        //få inputtet i x aksen, gør det i den vandrette retning og få den til at bevæge sig
        float inputX = Input.GetAxisRaw("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        //Hvis spilleren ar gået ud af venstre side, så bliver man sendt ind i skærmen igen, fra højre side af. Y værdien forbliver det samme som før, det gør vi i slutningen af linje 29.
        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);
        }
        //Her er det det samme, bare i højre side af skærmen
        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);
        }
    }
    //En metode til at detekte collisionen (metoden bliver automatisk "Kaldt" på af 2d phycics engine, så den skal hade det.)
    void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        //Hvis den collidere med den falleden blok, bliver spilleren destroerede 
        if(triggerCollider.tag== "Fallende Blok")
        {
            //til eventen
            if (SpillerDød != null)
            {
                SpillerDød();
            }
            //destroere blokken
            Destroy(gameObject);
        }
    }
}

    
