using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boatController : MonoBehaviour
{
    public Transform MoonPosition;
    public GameObject cubeObj;
    public float speed = 0.5f;
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
        //Vector3 direction = (transform.position - MoonPosition.position).normalized;
        ////direction.y = 0f;
        //transform.position = Vector3.Lerp(transform.position, MoonPosition.position, speed * Time.deltaTime);

        for (int z = 0; z < 380; z++)
        {
            GameObject cube = Instantiate(cubeObj, new Vector3(MoonPosition.position.x-10f, 0, (transform.position.z + 10f)+1f*z), Quaternion.identity);
            Instantiate(cubeObj, new Vector3(MoonPosition.position.x + 10f, 0, (transform.position.z + 10f) + 1f * z), Quaternion.identity);
        }
        
    }
}
