﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public UnityEvent Event;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) Event.Invoke();


    }
}
