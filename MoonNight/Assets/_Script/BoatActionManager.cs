using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoatActionManager : MonoBehaviour
{
    public GameObject boat;
    public GameObject airBlock;
    private float boatNormalSpeed = 20f;
    private float boatInBushSpeed = 5f;
    //private float boatAutoMoveSpeed = 10f;
    //public Transform targetPosition;

    private void OnEnable()
    {
        Bush.collideBushHappened += CollideBushAction;
        //WaterBridge.WaterBridgeHappened += MovetoMoon;
        
        
    }

    private void OnDisable()
    {
        Bush.collideBushHappened -= CollideBushAction;
        //WaterBridge.WaterBridgeHappened -= MovetoMoon;
    }

    public void CollideBushAction(bool enterBush)
    {
        if (enterBush) { boat.GetComponent<boatController>().moveSpeed = boatInBushSpeed; }
        else { boat.GetComponent<boatController>().moveSpeed = boatNormalSpeed; }
        
    }

    //public void MovetoMoon(GameObject obj)//obj is water bridge
    //{
    //    //disable air block
    //    airBlock.SetActive(false);
    //    //translate to water bridge
    //    boat.transform.position = obj.transform.position;
    //    Debug.Log("set boat posirion to obj's");
        
    //    boatController boatScript = obj.GetComponent<boatController>();

    //    //disable boat controller
    //    boatScript.rotationSpeed = 0f;
    //    boatScript.moveSpeed = 0f;

    //    //move boat to target
    //    //transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, boatAutoMoveSpeed * Time.deltaTime);
    //    Vector3 direction = targetPosition.position - transform.position;
    //    direction.Normalize();

    //    // Move towards the target
    //    //transform.Translate(direction * boatAutoMoveSpeed * Time.deltaTime);

    //}
}
