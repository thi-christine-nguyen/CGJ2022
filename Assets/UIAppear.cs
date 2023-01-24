using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIAppear : MonoBehaviour
{
    [SerializeField] private Canvas Message;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Message.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            Message.enabled = false;
        }
    }
}
