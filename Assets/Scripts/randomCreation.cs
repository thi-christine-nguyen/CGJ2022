using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomCreation : MonoBehaviour
{
    public GameObject prefab;
    public int nbMax;
    public float xmin;
    public float xmax;
    public float ymin;
    public float ymax;

    private List<GameObject> listeGO;

    // Start is called before the first frame update
    void Start()
    {
        listeGO = new List<GameObject>();

        while (nbMax != 0)
        {
            var position = new Vector3(Random.Range(xmin, xmax), Random.Range(ymin, ymax), 0);
            GameObject go = Instantiate(prefab, position, Quaternion.identity);

            listeGO.Add(go);

            //Debug.Log(position.x);
            //Debug.Log(go.transform.position.x);

            nbMax--;
        }
    }

    // Update is called once per frame
    void Update()
    {

        foreach (GameObject go in listeGO)
        {
 
            float valueX = go.transform.position.x;
            go.transform.position = new Vector3(valueX + 0.001f, go.transform.position.y, go.transform.position.z);

            if (go.transform.position.x > 10)
            {
                Destroy(go);
                //listeGO.Remove(go);
            }


        }

    }

}
