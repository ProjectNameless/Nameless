using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firstpersoncamera : MonoBehaviour
{

    public float mouseSensitivity;

    public float horizontal;

    public float vertical;

    public GameObject player_go;

    public float playerspeed;

    public Camera cam;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Mouse X") * mouseSensitivity;
        vertical -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        vertical = Mathf.Clamp(vertical, -90, 90);

        player_go.transform.Rotate(0, horizontal, 0);
        Camera.main.transform.localRotation = Quaternion.Euler(vertical, 0, 0);


        if (Input.GetKey("w"))
        {
            player_go.transform.Translate(Vector3.forward * playerspeed * Time.deltaTime, Space.Self);

        }

        if (Input.GetKey("s"))
        {
            player_go.transform.Translate(Vector3.back * playerspeed * Time.deltaTime, Space.Self);

        }

        if (Input.GetKey("a"))
        {
            player_go.transform.Translate(Vector3.left * playerspeed * Time.deltaTime, Space.Self);

        }

        if (Input.GetKey("d"))
        {
            player_go.transform.Translate(Vector3.right * playerspeed * Time.deltaTime, Space.Self);

        }

        if (Input.GetKeyDown("space"))
        {
            player_go.GetComponent<Rigidbody>().AddForce(0, 300, 0);
        }
    }
}



            



