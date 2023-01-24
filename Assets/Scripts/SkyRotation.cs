using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyRotation : MonoBehaviour
{
    private Transform m_rotationCenter;

    private float m_posX;
    private float m_posY;
    private float m_angle = 0;

    //-------------------------------

    private float m_angularSpeed = 0.2f;
    public float m_rotationRadius = -9f;

    public TimeManager tm;


    // Start is called before the first frame update
    void Start()
    {
        tm = FindObjectOfType<TimeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rotationCenter = GameObject.FindGameObjectWithTag("Sky").transform;   
        transform.position = m_rotationCenter.position;
        TimeManager Time = GameObject.FindGameObjectWithTag("TimeManager").GetComponent<TimeManager>();
        m_angle = -((Mathf.PI/12f) * Time.GetHour() + (Mathf.PI / 12f) *Time.GetMinutes()/60) + 3*Mathf.PI/7 +Mathf.PI/12;

        m_posX = m_rotationCenter.position.x + Mathf.Cos(m_angle) * m_rotationRadius;
        m_posY = m_rotationCenter.position.y + Mathf.Sin(m_angle) * m_rotationRadius;

        transform.position = new Vector2(m_posX, m_posY);
        //m_angle += Time.deltaTime * -m_angularSpeed;

        if (m_angle >= 360)
        {
            m_angle = 0;
        }
    }
}
