using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeAnimation : MonoBehaviour
{
    private MeteoManager meteo;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        meteo = GameObject.FindGameObjectWithTag("MeteoManager").GetComponent<MeteoManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (meteo.isRainy())
        {
            anim.SetBool("isGrowing", true);
        }
        else
        {
            anim.SetBool("isGrowing", false);
        }
    }
}
