using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    //variable stuff
    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed;
    [SerializeField] private float gravity = -6f;

    [SerializeField] private float velocityY;
    [SerializeField] private float jumpVelocity;

    //update function
    private void Update()
    {

        //player input
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        

        //calculate vertical speed from gravity
        if(!controller.isGrounded)
        {
            velocityY += gravity * Time.deltaTime;
        }

        //jumping
        if (Input.GetKeyDown(KeyCode.Space) && controller.isGrounded)
        {
            velocityY = jumpVelocity;
        }

        Vector3 vertical = new Vector3(0, velocityY, 0);

        //movement
        Vector3 direction = new Vector3(x, 0, z);
        Vector3 move = direction * speed + vertical;

        controller.Move(move * Time.deltaTime);


        //turn and face direction
        if (x !=0 || z !=0)
        {
            float yRot = Mathf.Atan2(x, z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, yRot, 0);
        }

    }

    private void Gravity()
    {
        if(!controller.isGrounded)
        {
            velocityY += gravity * Time.deltaTime;
        }
    }

}
