using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    //Vector3 direction = (transform.position - MoonPosition.position).normalized;
    ////direction.y = 0f;
    //transform.position = Vector3.Lerp(transform.position, MoonPosition.position, speed * Time.deltaTime);

    //for (int z = 0; z < 380; z++)
    //{
    //    GameObject cube = Instantiate(cubeObj, new Vector3(MoonPosition.position.x-10f, 0, (transform.position.z + 10f)+1f*z), Quaternion.identity);
    //    Instantiate(cubeObj, new Vector3(MoonPosition.position.x + 10f, 0, (transform.position.z + 10f) + 1f * z), Quaternion.identity);
    //}


    //control boat movement
}



