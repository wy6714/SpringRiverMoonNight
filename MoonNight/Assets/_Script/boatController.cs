using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class boatController : MonoBehaviour
{
    public Transform MoonPosition;
    //public GameObject cubeObj;

    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;

    public GameObject waterBridgeObj;
    public Transform waterBridgePos;
    public Transform stopPos;

    public TextMeshPro moonText;
    public float targetSize = 200f; 
    public float increaseSpeed = 80f;

    public Transform moon;
    public GameObject EndMsg;


    //public int count;

    // Start is called before the first frame update
    void Start()
    {
        //float zDis = MoonPosition.position.z - transform.position.z;
        //float xDis = Mathf.Abs(MoonPosition.position.x - transform.position.x);
        //Debug.Log("zDis: " + zDis + "; xDis: " + xDis + ".");
        waterBridgeObj.SetActive(false);
        EndMsg.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }

        //pass stop position, stop
        if(transform.position.z > stopPos.position.z)
        {
            moveSpeed = 0;
        }

        //if (count == 8)
        //{
        //    showRoad();
        //    transform.LookAt(new Vector3(MoonPosition.position.x,
        //        MoonPosition.position.y,
        //        MoonPosition.position.z));

        //}


    }
    //private void showRoad()
    //{
    //    float d = 9999999;
    //    int i = 0;
    //    while (d > 1)
    //    {
    //        Vector3 v = MoonPosition.position - transform.position;
    //        v.Normalize();
    //        Vector3 pos = transform.position + v * i;
    //        i++;
    //        d = Vector3.Distance(pos, MoonPosition.position);
    //        Instantiate(cubeObj, pos, Quaternion.identity);

    //    }
    //    count += 1;
        

    //}


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("angle before rotate: " + transform.rotation.eulerAngles);
        if (other.CompareTag("tornado"))
        {
            Debug.Log("collide with tornado");
            RotateRandamly();
            Debug.Log("angle after rotate: " + transform.rotation.eulerAngles);
        }

        if (other.CompareTag("WaterBridgeTrigger"))
        {
            waterBridgeObj.SetActive(true);
            EndMsg.SetActive(true);
            rotationSpeed = 0f;
            //moveSpeed = 0f;
            
            Vector3 directionToMoon = (moon.position - transform.position).normalized;
            transform.forward = directionToMoon;
            transform.position = waterBridgePos.position;
            transform.position = Vector3.MoveTowards(transform.position, stopPos.position, moveSpeed * Time.deltaTime);
            StartCoroutine(IncreaseTextSize());
        }

        if (other.CompareTag("AirBlock"))
        {
            moveSpeed = 0f;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("AirBlock"))
        {
            moveSpeed = 5f;
        }
    }

    public void RotateRandamly()
    {
        float randomRotationAngle = Random.Range(0f, 360f);
        Vector3 randomRotation = new Vector3(0f, randomRotationAngle, 0f);
        transform.Rotate(randomRotation);
    }

    private IEnumerator IncreaseTextSize()
    {
        while (moonText.fontSize < targetSize)
        {
            // Increase the text size gradually
            //moonText.fontSize = Mathf.Min(moonText.fontSize + increaseSpeed * Time.deltaTime, targetSize);
            moonText.fontSize = moonText.fontSize + increaseSpeed * Time.deltaTime;

            yield return null; // Wait for the next frame
        }

        // Ensure that the text size is exactly the target size
        moonText.fontSize = targetSize;

        // Optionally, you can perform additional actions here after reaching the target size
    }
}



