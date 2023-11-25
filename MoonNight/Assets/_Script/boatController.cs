using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class boatController : MonoBehaviour
{
    public Transform MoonPosition;
    public GameObject cubeObj;

    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;


    public int count;

    // Start is called before the first frame update
    void Start()
    {
        float zDis = MoonPosition.position.z - transform.position.z;
        float xDis = Mathf.Abs(MoonPosition.position.x - transform.position.x);
        Debug.Log("zDis: " + zDis + "; xDis: " + xDis + ".");

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

        if (count == 8)
        {
            showRoad();
            transform.LookAt(new Vector3(MoonPosition.position.x,
                MoonPosition.position.y,
                MoonPosition.position.z));

        }


    }
    private void showRoad()
    {
        float d = 9999999;
        int i = 0;
        while (d > 1)
        {
            Vector3 v = MoonPosition.position - transform.position;
            v.Normalize();
            Vector3 pos = transform.position + v * i;
            i++;
            d = Vector3.Distance(pos, MoonPosition.position);
            Instantiate(cubeObj, pos, Quaternion.identity);

        }
        count += 1;
        

    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("angle before rotate: " + transform.rotation.eulerAngles);
        if (other.CompareTag("tornado"))
        {
            Debug.Log("collide with tornado");
            RotateRandamly();
            Debug.Log("angle after rotate: " + transform.rotation.eulerAngles);
        }

    }

    public void RotateRandamly()
    {
        float randomRotationAngle = Random.Range(0f, 360f);
        Vector3 randomRotation = new Vector3(0f, randomRotationAngle, 0f);
        transform.Rotate(randomRotation);
    }
}



