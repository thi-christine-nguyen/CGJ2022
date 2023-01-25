using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterScript : MonoBehaviour
{
    private float opacity = 0;
    public float opacitySpeed = 0.5f;

    private MeteoManager meteoManager;
    // Start is called before the first frame update
    void Start()
    {
        meteoManager = GameObject.FindGameObjectWithTag("MeteoManager").GetComponent<MeteoManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (meteoManager.isRainy() ||meteoManager.isSnowy())
        {
            if (opacity < 1)
            {
                opacity += Time.deltaTime* opacitySpeed;
            }
        }
        if (meteoManager.isSunny())
        {
            if (opacity > 0)
            {
                opacity -= Time.deltaTime * opacitySpeed;
            }
        }


        if (meteoManager.isSnowy())
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, opacity);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(155f/255, 246f/255, 1, opacity);
        }
    }
}
