using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //Reference til blokken
    public GameObject fallendeBlokPrefab;

    //Reference til hvornår blokke skal spawn
    public float tidmellemspawn = 1;
    float nextSpawnTime;

    //representere min og max værdi, x min og y max
    public Vector2 spawnStørrelseMinMax;

    //Udregn skærmstørrelsen
    Vector2 screenHalfSizeWorldUnits;

    void Start()
    {
        //vi udregner det. Vi gør det ved at få adgang til kameraet, dens aspect, ganger det med dens orthographicsize som er halvdelen af af skærmens højde.
        screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);
    }

 
    void Update()
    {

        //hvis den nuværende tid i spillet er større end den næste spawn tid, så spawn objecktet.
        if (Time.time > nextSpawnTime)
        {
            //Så når vi kommer forbi spawntiden bliver spawntiden forøget med tiden vi ville have mellem spawnen, så her 1 sekund.  
            nextSpawnTime = Time.time + tidmellemspawn;
           //Min og maximum for blokkens størrelse, som jeg sætter inde i unity til 0.28 til 2.1
            float spawnStørrelse=Random.Range (spawnStørrelseMinMax.x, spawnStørrelseMinMax.y); 

            //hvor blokken skal spawn, vi tilføjer også halvdelen af objectets højde så de spawner over skærmen
            Vector2 spawnposition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x, screenHalfSizeWorldUnits.x), screenHalfSizeWorldUnits.y + spawnStørrelse/2f);

            //gør så den spawner og ikke rotere via. Quaternion 
            GameObject newBlock=(GameObject)Instantiate(fallendeBlokPrefab, spawnposition, Quaternion.identity);
            //Gør så blokken har en scalereing af spawnStørrelsen på x og y aksen.
            newBlock.transform.localScale = Vector3.one * spawnStørrelse;
        }
    }
}
