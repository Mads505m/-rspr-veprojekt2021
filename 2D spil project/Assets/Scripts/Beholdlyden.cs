using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beholdlyden : MonoBehaviour
{
void Awake()
    {
        //Vi gør så den ikke destroere vores lyd
        DontDestroyOnLoad(transform.gameObject);
    }
}
