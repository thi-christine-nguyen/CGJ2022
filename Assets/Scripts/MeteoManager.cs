using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MeteoManager : MonoBehaviour
{
    private int m_currentMeteo;
    private TimeManager m_timeManager;
    //0 -> sunny, 1 -> rainy, 2 -> snow, 3 -> windy

    public GameObject m_RainParticles;
    public GameObject m_SnowParticles;
    public GameObject m_WindParticles;

    private float m_delay;
    private int m_delayMax = 2;


    void Start()
    {
        m_delay = 0;
        m_currentMeteo = 0;
        SetSunny();
        m_timeManager = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
    }

    void Update()
    {
        if (m_timeManager.GetHour() == 16 && m_timeManager.GetMinutes() == 15 && !isRainy())
        {
            m_delay += Time.deltaTime;
            if (m_delay >= m_delayMax)
            {
                SetRainy();
                Debug.Log("rain");
            }
            else
            {
                m_delay += Time.deltaTime;
            }
        }
        else if (m_timeManager.GetHour() == 5 && m_timeManager.GetMinutes() == 43 && !isSnowy())
        {
            m_delay += Time.deltaTime;
            if (m_delay >= m_delayMax)
            {
                SetSnowy();
                Debug.Log("snow");
            }
            else
            {
                m_delay += Time.deltaTime;
            }
        }
        else if (m_timeManager.GetHour() == 11 && m_timeManager.GetMinutes() == 27 && !isSunny())
        {
            m_delay += Time.deltaTime;
            if (m_delay >= m_delayMax)
            {
                SetSunny();
                Debug.Log("sun");
            }
            else
            {
                m_delay += Time.deltaTime;
            }
        }
        else if (m_timeManager.GetHour() == 23 && m_timeManager.GetMinutes() == 7 && !isWindy())
        {
            m_delay += Time.deltaTime;
            if (m_delay >= m_delayMax)
            {
                SetWindy();
                Debug.Log("wind");
            }
            else
            {
                m_delay += Time.deltaTime;
            }
        }
        else
        {
            m_delay = 0;
        }
    }

    void SetMeteo(int meteo)
    {
        m_currentMeteo = meteo;
    }

    public Boolean isRainy()
    {
        if (m_currentMeteo == 1)
        {
            return true;
        }
        return false;
    }

    public Boolean isSunny()
    {
        if (m_currentMeteo == 0)
        {
            return true;
        }
        return false;
    }

    public Boolean isWindy()
    {
        if (m_currentMeteo == 3)
        {
            return true;
        }
        return false;
    }

    public Boolean isSnowy()
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
            if (GameObject.FindGameObjectWithTag(tag) != null || FindInActiveObjectByTag(tag) != null) 
            {
                if (tag.Equals("WindParticles"))
                {
                    GameObject obj = Instantiate(m_WindParticles);
                    obj.transform.parent = gameObject.transform;
                    obj.transform.position = transform.position;
                }
                else if (tag.Equals("RainParticles"))
                {
                    GameObject obj = Instantiate(m_RainParticles);
                    obj.transform.parent = gameObject.transform;
                    obj.transform.position = transform.position;
                }
                else if (tag.Equals("SnowParticles"))
                {
                    GameObject obj = Instantiate(m_SnowParticles);
                    obj.transform.parent = gameObject.transform;
                    obj.transform.position = transform.position;
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
