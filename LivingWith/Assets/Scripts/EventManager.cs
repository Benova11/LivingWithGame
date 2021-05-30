using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public UnityEvent Event;
    public UnityEvent Event2;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) Event.Invoke();


    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) Event2.Invoke();
    }
}
