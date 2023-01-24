using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchTwoImage : MonoBehaviour
{

    public List<Sprite> spriteCollection = new List<Sprite>();
    public Image original;
    private int m_spriteIndex = 0;

    private void Start()
    {
        original.sprite = spriteCollection[m_spriteIndex];
    }

    float elapsed = 0f;
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= 1f)
        {
            if (m_spriteIndex == 0){
                m_spriteIndex = 1;
                original.sprite = spriteCollection[m_spriteIndex];
            }
            else{
                m_spriteIndex = 0;
                original.sprite = spriteCollection[m_spriteIndex];
            }
            elapsed = 0f;
        }
    }
}
