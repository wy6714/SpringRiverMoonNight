using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatController : MonoBehaviour
{
    public Transform MoonPosition;
    public GameObject cubeObj;
    public float speed = 5f;
    public float rotateSpeed = 45f;
    private float RotateValue;
    public float RotateAmount = 100f;
    private CharacterController characterController;


    public int count;
    // Start is called before the first frame update
    void Start()
    {
        float zDis = MoonPosition.position.z - transform.position.z;
        float xDis = Mathf.Abs(MoonPosition.position.x - transform.position.x);
        Debug.Log("zDis: " + zDis + "; xDis: " + xDis + ".");


        characterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(hInput, 0, vInput);
        //Vector3 move = new Vector3(hInput, 0, 0);
        move.Normalize();

        //rotate
        RotateValue += hInput * RotateAmount * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(Vector3.up * RotateValue);

        characterController.Move(move * speed * Time.deltaTime);

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



