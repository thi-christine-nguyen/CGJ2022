using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigitalClock : MonoBehaviour
{
    public TimeManager tm;
    Text display;

    public bool _24HourClock = true;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(FindObjectsOfType<TimeManager>().Length);

        display = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
            display.text = tm.Clock24Hour();
    }
}