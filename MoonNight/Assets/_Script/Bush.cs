using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bush : MonoBehaviour
{
    //public GameObject boat;
    public static event Action<bool> collideBushHappened;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //SetBoatSpeed(0);
            collideBushHappened?.Invoke(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //SetBoatSpeed(5);
            collideBushHappened?.Invoke(false);
        }
    }
    //public void SetBoatSpeed(int speed)
    //{
    //    boat.GetComponent<boatController>().moveSpeed = speed;
    //}
}
