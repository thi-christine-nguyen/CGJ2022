using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIAppear : MonoBehaviour
{
    [SerializeField] private Canvas Message;

    private bool isColid = false;

    public AudioSource audio;
    public AudioClip appearance;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isColid = true;
        }

        audio.clip = appearance;
        audio.volume = 0.5f;
        audio.Play();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            isColid = false;
        }
    }

    private void Update()
    {
        if (isColid)
        {
            if(Message.transform.position.y < 500){
                Message.transform.position = Message.transform.position + new Vector3(0,3,0);
            }
        }
        else{
            if (Message.transform.position.y > -150){
                Message.transform.position = Message.transform.position - new Vector3(0,3,0);
            }
        }
    }
}
