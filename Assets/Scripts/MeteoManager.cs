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
            }
            else
            {
                m_delay += Time.deltaTime;
            }
        }
        else if (m_timeManager.GetHour() == 0 && m_timeManager.GetMinutes() == 7 && !isSnowy())
        {
            m_delay += Time.deltaTime;
            if (m_delay >= m_delayMax)
            {
                SetSnowy();
            }
            else
            {
                m_delay += Time.deltaTime;
            }
        }
        else if (m_timeManager.GetHour() == 11 && m_timeManager.GetMinutes() == 38 && !isSunny())
        {
            m_delay += Time.deltaTime;
            if (m_delay >= m_delayMax)
            {
                SetSunny();
            }
            else
            {
                m_delay += Time.deltaTime;
            }
        }
        else if (m_timeManager.GetHour() == 1 && m_timeManager.GetMinutes() == 12 && !isWindy())
        {
            m_delay += Time.deltaTime;
            if (m_delay >= m_delayMax)
            {
                SetWindy();
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

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("water"))
        {
            foreach (BoxCollider2D box in obj.GetComponents<BoxCollider2D>())
            {
                box.isTrigger = true;
            }
        }
    }

    void SetRainy()
    {
        invokeParticle("RainParticles", true);
        invokeParticle("WindParticles", false);
        invokeParticle("SnowParticles", false);

        SetGrayTime(true);
        m_currentMeteo = 1;

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("water"))
        {
            foreach (BoxCollider2D box in obj.GetComponents<BoxCollider2D>())
            {//big box : 2.257206  || water hitbox : -0.09666926
                box.isTrigger = false;
            }
        }
    }

    void SetWindy()
    {
        invokeParticle("RainParticles", false);
        invokeParticle("WindParticles", true);
        invokeParticle("SnowParticles", false);

        SetGrayTime(false);
        m_currentMeteo = 3;

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("water"))
        {
            foreach (BoxCollider2D box in obj.GetComponents<BoxCollider2D>())
            {//big box : 2.257206  || water hitbox : -0.09666926
                box.isTrigger = false;
            }
        }
    }

    void SetSnowy()
    {
        invokeParticle("RainParticles", false);
        invokeParticle("WindParticles", false);
        invokeParticle("SnowParticles", true);

        SetGrayTime(true);
        m_currentMeteo = 2;

        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("water"))
        {
            foreach (BoxCollider2D box in obj.GetComponents<BoxCollider2D>())
            {
                if (((int)box.offset.y) == 2)
                {
                    box.isTrigger = true;
                }
                else
                {
                    box.isTrigger = false;
                }
            }
        }
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
