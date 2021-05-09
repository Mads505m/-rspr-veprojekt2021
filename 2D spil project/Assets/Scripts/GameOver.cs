using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// vi skal bruge det her til at bruge teksten vi har lavet i unity
using UnityEngine.UI;
//før vi kan reload scenen skal vi have adgang til min Dutabtemangager, så vi skal adde dette
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    //reference til Dutabteskærm objectet
    public GameObject Dutabteskærm;
    //reference 
    public Text sekunderoverlevetUI;

    bool Dutabte;



    void Start()
    {
        FindObjectOfType<Spillercontrols>().SpillerDød += OnGameover;
    }

  
    void Update()
    {
        if (Dutabte)
        {
            //Hvis man taber, kan man trykke mellemrum for at restart
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(1);
            }
        }
    }
    //Nu skal vi vide hvornår spillet er over, det gør vi med koden her
     void OnGameover()
    {

        //Når metoden er kaldt. De slår objectet til kan man sige
        Dutabteskærm.SetActive(true);
        //her sætter vi det til den mænge tid der har gået, som skal sættets til et string. Og time.time... gør så at den ikke husker tiden  fra før og plusser det sammen
        sekunderoverlevetUI.text = Time.timeSinceLevelLoad.ToString();
        Dutabte = true;

    }
}
