using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    //variable stuff
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed;
    [SerializeField] private float gravity = -6.8f;

    [SerializeField] private bool grounded;
    [SerializeField] private float velocityY;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private float val;

    //update function
    private void Update()
    {
        if(grounded == true)
        {
            val = 1;
        }
        if(grounded == false)
        {
            val = 0;
        }

        //player input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //jumping
        if(Input.GetKeyDown(KeyCode.Space) && grounded == true)
        {
            velocityY = jumpVelocity;
        }

        //calculate vertical speed from gravity
        if(!grounded)
        {
            velocityY += gravity * Time.deltaTime;
        }

        Vector3 vertical = new Vector3(0, velocityY, 0);

        //movement
        Vector3 direction = new Vector3(x, 0, z);
        Vector3 move = direction + vertical;
        controller.Move(move * speed * Time.deltaTime);

        //turn and face direction
        if (x !=0 || z !=0)
        {
            float yRot = Mathf.Atan2(x, z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, yRot, 0);
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if(collider.gameObject.layer == 6)
        {
            grounded = false;
        }
    }

    private void OnTriggerStay(Collider collider)
    {
       if(collider.gameObject.layer == 6)
        {
            velocityY = 0;
            grounded = true;
        }
    }

    private void Gravity()
    {
        if(!grounded)
        {
            velocityY += gravity * Time.deltaTime;
        }
    }

}
