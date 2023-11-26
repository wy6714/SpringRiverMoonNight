using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBridge : MonoBehaviour
{
    public static event Action<GameObject> WaterBridgeHappened;
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
        //if (other.CompareTag("Player"))
        //{
        //    WaterBridgeHappened?.Invoke(gameObject);
        //    Destroy(gameObject);
        //    /*
        //     * 1. translate boat to water bridge. (boatActionManager)
        //     * 2. move boat to stop position. (boatActionManager)

        //     */
        //}
    }
}
