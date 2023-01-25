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

    void Start()
    {
        meteo = GameObject.FindGameObjectWithTag("MeteoManager").GetComponent<MeteoManager>();

        audio.loop = true;
        audio.Play();

    }


    void Update()
    {
        if (meteo.isSunny())
        {
            audio.clip = clipSun;
            audio.loop = true;
            audio.Play();
        }

        else if (meteo.isRainy())
        {
            audio.clip = clipRain;
            audio.loop = true;
            audio.Play();
        }

        else if (meteo.isSnowy())
        {
            audio.clip = clipNeige;
            audio.loop = true;
            audio.Play();
        }

        else if (meteo.isWindy())
        {
            audio.clip = clipWind;
        audio.loop = true;
            audio.Play();
        }
    }
}
