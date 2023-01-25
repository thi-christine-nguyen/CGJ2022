using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMusic : MonoBehaviour
{
    public AudioClip clipSun;
    public AudioClip clipRain;
    public AudioClip clipNeige;
    public AudioClip clipWind;

    private MeteoManager meteo;
    public AudioSource audio;

    bool isMusicSunActive = false;
    bool isMusicRainActive = false;
    bool isMusicNeigeActive = false;
    bool isMusicWindActive = false;

    void Start()
    {
        meteo = GameObject.FindGameObjectWithTag("MeteoManager").GetComponent<MeteoManager>();

        /*audio.loop = true;
        audio.Play();*/

    }


    void Update()
    {
        if (meteo.isSunny() && !isMusicSunActive)
        {
            audio.clip = clipSun;
            audio.loop = true;
            audio.Play();
            isMusicSunActive = true;

            isMusicRainActive = false;
            isMusicNeigeActive = false;
            isMusicWindActive = false;
        }

        else if (meteo.isRainy() && !isMusicRainActive)
        {
            audio.clip = clipRain;
            audio.loop = true;
            audio.Play();
            isMusicRainActive = true;

            isMusicSunActive = false;
            isMusicNeigeActive = false;
            isMusicWindActive = false;
        }

        else if (meteo.isSnowy() && !isMusicNeigeActive)
        {
            audio.clip = clipNeige;
            audio.loop = true;
            audio.Play();
            isMusicNeigeActive = true;

            isMusicSunActive = false;
            isMusicRainActive = false;
            isMusicWindActive = false;
        }

        else if (meteo.isWindy() && !isMusicWindActive)
        {
            audio.clip = clipWind;
            audio.loop = true;
            audio.Play();
            isMusicWindActive = true;

            isMusicSunActive = false;
            isMusicRainActive = false;
            isMusicNeigeActive = false;
        }
    }
}
