using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class bottleCollectionManager : MonoBehaviour
{
    protected float boatMoveSpeed = 10f;
    protected float boatStopSpeed = 0f;
    private int bottleNum = 0;
    public GameObject boat;

    public GameObject bottleMsgPanel;
    public TMP_Text bottleMsgText;

    public GameObject MsgPanel;
    public TMP_Text MsgText;
    public GameObject WaterBridgeTrigger;
    
    private void OnEnable()
    {
        Bottle.collectBottleHappened += trackBottleNum;
        Bottle.collectBottleHappened += showBottleMessage;
        Bottle.collectBottleHappened += showMsg;
        Bottle.collectBottleHappened += showWaterBridgeTrigger;
    }

    private void OnDisable()
    {
        Bottle.collectBottleHappened -= trackBottleNum;
        Bottle.collectBottleHappened -= showBottleMessage;
        Bottle.collectBottleHappened -= showMsg;
        Bottle.collectBottleHappened -= showWaterBridgeTrigger;
    }
    // Start is called before the first frame update
    void Start()
    {
        bottleMsgPanel.SetActive(false);
        MsgPanel.SetActive(false);
        WaterBridgeTrigger.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //press Z to close message and boat move
        if (Input.GetKeyUp(KeyCode.Z))
        {
            bottleMsgPanel.SetActive(false);
            setBoatSpeed(boatMoveSpeed);
        }
    }

    public void trackBottleNum(GameObject obj)
    {
        int bottleID = obj.GetComponent<Bottle>().bottleID;
        bottleNum += bottleID;
        Debug.Log("this bottle ID is: " + bottleID + " ,bottleNum is: " + bottleNum);
    }

    public void showBottleMessage(GameObject obj)
    {
        //stop boat
        setBoatSpeed(boatStopSpeed);
        //show message
        bottleMsgPanel.SetActive(true);
        Bottle objScript = obj.GetComponent<Bottle>();

        //UI show message, if ID = 1, else text = "nothing on it"
        if (objScript.bottleID != 0)
        {
            bottleMsgText.text = objScript.message;   
        }
        else
        {
            bottleMsgText.text = "Nothing there.";
        }

        //destory bottle
        Destroy(obj);
        
    }

    public void showMsg(GameObject obj)//if collect 3 bottle 
    {
        if (bottleNum == 3)
        {
            MsgPanel.SetActive(true);
            MsgText.text = "who the moon is waiting for? \n\nBack where you start ask this question. You may have answer.";
        }
        
    }

    public void setBoatSpeed(float speed) => boat.GetComponent<boatController>().moveSpeed = speed;

    public void showWaterBridgeTrigger(GameObject obj)
    {
        if (bottleNum == 3)
        {
            WaterBridgeTrigger.SetActive(true);
        }
        
    }
}
