using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatActionManager : MonoBehaviour
{
    public GameObject boat;
    private float boatNormalSpeed = 5f;
    private float boatInBushSpeed = 2f;
    private void OnEnable()
    {
        Bush.collideBushHappened += CollideBushAction;
        
    }

    private void OnDisable()
    {
        Bush.collideBushHappened += CollideBushAction;
    }

    public void CollideBushAction(bool enterBush)
    {
        if (enterBush) { boat.GetComponent<boatController>().moveSpeed = boatInBushSpeed; }
        else { boat.GetComponent<boatController>().moveSpeed = boatNormalSpeed; }
        
    }
}
