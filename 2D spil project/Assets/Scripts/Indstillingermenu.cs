using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Indstillingermenu : MonoBehaviour
{
    //Lave en refrence  til vores audiomixer

    public AudioMixer audioMixer;
   
    public void SetLyd (float volume)
    {
        audioMixer.SetFloat("Lyd", volume);
    }
}
