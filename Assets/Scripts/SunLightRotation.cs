using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class SunLightRotation : MonoBehaviour
{
    private float m_factor = 40f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rotation = new Vector3(0, 0, m_factor* Time.deltaTime);
        transform.Rotate(rotation);
    }
}
