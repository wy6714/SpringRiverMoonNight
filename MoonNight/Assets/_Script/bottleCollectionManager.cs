using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bottleCollectionManager : MonoBehaviour
{
    private int bottleNum = 0;
    public GameObject boat;

    //stop boat;
    //UI show message, if ID = 1, else text = "nothing on it"
    private void OnEnable()
    {
        Bottle.collectBottleHappened += trackBottleNum;
    }

    private void OnDisable()
    {
        Bottle.collectBottleHappened -= trackBottleNum;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void trackBottleNum(GameObject obj)
    {
        int bottleID = obj.GetComponent<Bottle>().bottleID;
        bottleNum += bottleID;
        Debug.Log("this bottle ID is: " + bottleID + " ,bottleNum is: " + bottleNum);
    }
}
