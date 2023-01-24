using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MeteoManager : MonoBehaviour
{
    private int m_currentMeteo;
    //0 -> sunny, 1 -> rainy, 2 -> snow, 3 -> windy

    public GameObject m_RainParticles;
    public GameObject m_SnowParticles;
    public GameObject m_WindParticles;


    void Start()
    {
        m_currentMeteo = 0;
        SetWindy();
    }

    void Update()
    {

    }

    void SetMeteo(int meteo)
    {
        m_currentMeteo = meteo;
    }

    Boolean isRainy()
    {
        if (m_currentMeteo == 1)
        {
            return true;
        }
        return false;
    }

    Boolean isSunny()
    {
        if (m_currentMeteo == 0)
        {
            return true;
        }
        return false;
    }

    Boolean isWindy()
    {
        if (m_currentMeteo == 3)
        {
            return true;
        }
        return false;
    }

    Boolean isFoggy()
    {
        if (m_currentMeteo == 2)
        {
            return true;
        }
        return false;
    }

    void SetSunny()
    {
        invokeParticle("RainParticles", false);
        invokeParticle("WindParticles", false);
        invokeParticle("SnowParticles", false);

        SetGrayTime(false);
        m_currentMeteo = 0;
    }

    void SetRainy()
    {
        invokeParticle("RainParticles", true);
        invokeParticle("WindParticles", false);
        invokeParticle("SnowParticles", false);

        SetGrayTime(true);
        m_currentMeteo = 1;
    }

    void SetWindy()
    {
        invokeParticle("RainParticles", false);
        invokeParticle("WindParticles", true);
        invokeParticle("SnowParticles", false);

        SetGrayTime(false);
        m_currentMeteo = 3;
    }

    void SetSnowy()
    {
        invokeParticle("RainParticles", false);
        invokeParticle("WindParticles", false);
        invokeParticle("SnowParticles", true);

        SetGrayTime(true);
        m_currentMeteo = 2;
    }

    void invokeParticle(String tag, Boolean boolean)
    {
        if (!boolean)
        {
            GameObject[] objs = GameObject.FindGameObjectsWithTag(tag);
            if (objs.Length > 0)
            {
                foreach (GameObject obj in objs)
                {
                    GameObject.Destroy(obj);
                }
            }
        }
        else
        {
            if (GameObject.FindGameObjectWithTag(tag) == null && FindInActiveObjectByTag(tag) == null) 
            {
                if (tag.Equals("WindParticles"))
                {
                    Instantiate(m_WindParticles);
                }
                else if (tag.Equals("RainParticles"))
                {
                    Instantiate(m_RainParticles);
                }
                else if (tag.Equals("SnowParticles"))
                {
                    Instantiate(m_SnowParticles);
                }
            }
        }
    }

    GameObject FindInActiveObjectByTag(string tag)
    {

        Transform[] objs = Resources.FindObjectsOfTypeAll<Transform>() as Transform[];
        for (int i = 0; i < objs.Length; i++)
        {
            if (objs[i].hideFlags == HideFlags.None)
            {
                if (objs[i].CompareTag(tag))
                {
                    return objs[i].gameObject;
                }
            }
        }
        return null;
    }

    private void SetGrayTime(Boolean boolean)
    {
        GameObject sun = GameObject.FindGameObjectWithTag("Sun");
        if (sun == null)
        {
            sun = FindInActiveObjectByTag("Sun");
        }
        GameObject background = GameObject.FindGameObjectWithTag("SkyBackground");
        GameObject moonLight = GameObject.FindGameObjectWithTag("MoonLight");
        if (boolean)
        {//No sun, gray bg, sad moonlight
            sun.SetActive(false);
            background.GetComponent<SpriteRenderer>().color = new Color(126f / 255, 126f / 255, 126f / 255);

            moonLight.GetComponent<Light2D>().color = new Color(19f / 255, 0, 34f / 255);
        }
        else
        {//Sun, Blue bg, good moonlight
            sun.SetActive(true);
            background.GetComponent<SpriteRenderer>().color = new Color(91f / 255, 199f / 255, 221f / 255);

            moonLight.GetComponent<Light2D>().color = new Color(53f / 255, 14f / 255, 82f / 255);
        }
    }
}
