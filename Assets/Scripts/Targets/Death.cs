using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    public AudioSource deathSound1;

    public void PlayDeathSound1()
    {
        deathSound1.Play();
    }
}
