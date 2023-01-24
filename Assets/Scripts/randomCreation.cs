using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomCreation : MonoBehaviour
{
    public GameObject prefab;

    public float xmin;
    public float xmax;
    public float ymin;
    public float ymax;

    private GameObject prefab1;
    private GameObject prefab2;
    private GameObject prefab3;
    private GameObject prefab4;
    private GameObject prefab5;

    // Start is called before the first frame update
    void Start()
    {
            var position1 = new Vector3(Random.Range(-7, -9), Random.Range(ymin, ymax), 0);
            prefab1 = Instantiate(prefab, position1, Quaternion.identity);

            var position2 = new Vector3(Random.Range(-8, -12), Random.Range(ymin, ymax), 0);
            prefab2 = Instantiate(prefab, position2, Quaternion.identity);

            var position3 = new Vector3(Random.Range(-12, -16), Random.Range(ymin, ymax), 0);
            prefab3 = Instantiate(prefab, position3, Quaternion.identity);

            var position4 = new Vector3(Random.Range(-16, -20), Random.Range(ymin, ymax), 0);
            prefab4 = Instantiate(prefab, position4, Quaternion.identity);

            var position5 = new Vector3(Random.Range(-20, -26), Random.Range(ymin, ymax), 0);
            prefab5 = Instantiate(prefab, position5, Quaternion.identity);

    }

    // Update is called once per frame
    void Update()
    {

        if (prefab1 != null)
        {
            float valueX1 = prefab1.transform.position.x;
            prefab1.transform.position = new Vector3(valueX1 + 0.001f, prefab1.transform.position.y, prefab1.transform.position.z);

            if (prefab1.transform.position.x > 8f)
            {
                Destroy(prefab1);

                var position1 = new Vector3(Random.Range(-7, -9), Random.Range(ymin, ymax), 0);
                prefab1 = Instantiate(prefab, position1, Quaternion.identity);

                float valueX2 = prefab1.transform.position.x;
                prefab1.transform.position = new Vector3(valueX2 + 0.001f, prefab1.transform.position.y, prefab1.transform.position.z);

            }

        }

        if (prefab2 != null)
        {
            float valueX1 = prefab2.transform.position.x;
            prefab2.transform.position = new Vector3(valueX1 + 0.001f, prefab2.transform.position.y, prefab2.transform.position.z);

            if (prefab2.transform.position.x > 8f)
            {
                Destroy(prefab2);

                var position2 = new Vector3(Random.Range (-8, -12), Random.Range(ymin, ymax), 0);
                prefab2 = Instantiate(prefab, position2, Quaternion.identity);

                float valueX2 = prefab2.transform.position.x;
                prefab2.transform.position = new Vector3(valueX2 + 0.001f, prefab2.transform.position.y, prefab2.transform.position.z);

            }

        }

        if (prefab3 != null)
        {
            float valueX1 = prefab3.transform.position.x;
            prefab3.transform.position = new Vector3(valueX1 + 0.001f, prefab3.transform.position.y, prefab3.transform.position.z);

            if (prefab3.transform.position.x > 8f)
            {
                Destroy(prefab3);

                var position1 = new Vector3(Random.Range(-12, -16), Random.Range(ymin, ymax), 0);
                prefab3 = Instantiate(prefab, position1, Quaternion.identity);

                float valueX2 = prefab3.transform.position.x;
                prefab3.transform.position = new Vector3(valueX2 + 0.001f, prefab3.transform.position.y, prefab3.transform.position.z);

            }

        }

        if (prefab4 != null)
        {
            float valueX1 = prefab4.transform.position.x;
            prefab4.transform.position = new Vector3(valueX1 + 0.001f, prefab4.transform.position.y, prefab4.transform.position.z);

            if (prefab4.transform.position.x > 8f)
            {
                Destroy(prefab4);

                var position1 = new Vector3(Random.Range(-16, -20), Random.Range(ymin, ymax), 0);
                prefab4 = Instantiate(prefab, position1, Quaternion.identity);

                float valueX2 = prefab4.transform.position.x;
                prefab4.transform.position = new Vector3(valueX2 + 0.001f, prefab4.transform.position.y, prefab4.transform.position.z);

            }

        }

        if (prefab5 != null)
        {
            float valueX1 = prefab5.transform.position.x;
            prefab5.transform.position = new Vector3(valueX1 + 0.001f, prefab5.transform.position.y, prefab5.transform.position.z);

            if (prefab5.transform.position.x > 8f)
            {
                Destroy(prefab5);

                var position1 = new Vector3(Random.Range(-20, -26), Random.Range(ymin, ymax), 0);
                prefab5 = Instantiate(prefab, position1, Quaternion.identity);

                float valueX2 = prefab5.transform.position.x;
                prefab5.transform.position = new Vector3(valueX2 + 0.001f, prefab5.transform.position.y, prefab5.transform.position.z);

            }

        }

    }


}
