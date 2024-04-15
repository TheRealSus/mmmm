using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 22, -15);

    // Update is called once per frame
    void Update()
    {
        //makes the camera follow the vehicle
        transform.position = player.transform.position + offset;
    }
}