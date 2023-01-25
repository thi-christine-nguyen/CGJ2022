using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MistAppear : MonoBehaviour
{
    [SerializeField] private Image Mist;

    private bool isColid = false;

    private int temp = 0;

    public MeteoManager mt;

    public GameObject MistWall;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isColid = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            isColid = false;
        }
    }

    private void Update()
    {
        if (mt.isWindy()) { MistWall.SetActive(false); isColid = false; }
        if (mt.isWindy() && Mist.color.a == 0) { Mist.enabled = false; }
        temp++;
        if (isColid && temp == 50)
        {
            if(Mist.color.a < 1)
            {
                Mist.color += new Color(0,0,0,0.1f);
            }
            temp = 0;
        }
        else if (!isColid && temp == 50){
            if (Mist.color.a > 0)
            {
                Mist.color -= new Color(0,0,0,0.1f);
            }
            temp = 0;
        }
    }
}
