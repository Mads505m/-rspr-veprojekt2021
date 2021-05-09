using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//For at ændre scener
using UnityEngine.SceneManagement; 

public class Hovedmenu : MonoBehaviour

{
    //funktion der bliver brugt, når man trykker på start knappen
    //før vi vi kan "kalde" funktionen når vi trykker på knappen skal vi lave metoden public
    //Det er void fordi det ikke skal retunere noget
    public void PlayGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }
    //Det samme til Afslutsknappen
    public void QuitGame ()
    {
        //Besked for at tjekke om det virker
        Debug.Log("QUIT!");
        //For at få programmer til at lukke ned
        Application.Quit();
    }

}
