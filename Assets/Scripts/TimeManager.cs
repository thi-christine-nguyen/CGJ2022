using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Slider hour;
    public Slider minute;

    private void Start()
    {
        hour.value = 10; 
        minute.value = 30;

    }
    public float GetHour()
    {
        return hour.value;
    }

    public float GetMinutes()
    {
        return minute.value;
    }

    public string Clock24Hour()
    {
        //00:00
        return Mathf.FloorToInt(GetHour()).ToString("00") + ":" + Mathf.FloorToInt(GetMinutes()).ToString("00");
    }
}
