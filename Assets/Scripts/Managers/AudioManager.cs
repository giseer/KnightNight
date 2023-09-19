using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] sonidos;
    private AudioSource AS;

    private void Start()
    {
        AS= GetComponent<AudioSource>();
    }

    public void DieSound()
    {
        AS.clip = sonidos[0];
        AS.loop = false;
        AS.Play();
    }

    public void LooseSound() 
    { 
        AS.clip= sonidos[1];
        AS.loop= false;
        AS.Play(); 
    }
    public void DoorSound()
    {
        AS.clip = sonidos[2];
        AS.loop = false;
        AS.Play();
    }
    public void WinSound()
    {
        AS.clip = sonidos[3];
        AS.loop = false;
        AS.Play();
    }


}
