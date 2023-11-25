using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour
{
    public static event Action<GameObject> collectBottleHappened;
    public string message="";
    public int bottleID; //0->no words; 1 -> has words

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collectBottleHappened?.Invoke(gameObject);
        }
    }
}
