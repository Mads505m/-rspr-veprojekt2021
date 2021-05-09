using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Det her script skal ikke høre til nogen objekter i scenen, der skal bare være ude for scenen, den skal bare kunne bare tilgænlig for alle classes der har brug for informationen, derfor er den static
public static class Sværdhedsgrad{
    
    //Maksimum sværhedsgrad opnået
    static float sekundertilmaksimumsværhedsgrad = 60;

    public static float Fåsværhedsgradprocent()
    {
        //Tager bare den nuværende tid divideret med tiden til den makse sværhedsgrad, hvor vi bruger mathf til udregningen
        return Mathf.Clamp01(Time.timeSinceLevelLoad / sekundertilmaksimumsværhedsgrad);
    }
       
}
