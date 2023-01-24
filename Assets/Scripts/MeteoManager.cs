using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoManager : MonoBehaviour
{
    private int m_currentMeteo;
    //0 -> sunny, 1 -> rainy, 2 -> foggy, 3 -> windy


    void Start()
    {
        m_currentMeteo = 0;
    }

    void Update()
    {
        if (isSunny())
        {

        }
        else if (isRainy())
        {

        }
        else if (isFoggy())
        {

        }
        else if (isWindy())
        {

        }
    }

    void SetMeteo(int meteo)
    {
        m_currentMeteo = meteo;
    }

    int GetMeteo()
    {
        return m_currentMeteo;
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
}
