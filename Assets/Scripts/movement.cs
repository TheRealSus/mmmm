using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class movement : MonoBehaviour
{
    //variable stuff

    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed;
    [SerializeField] private float gravity = -6f;
    [SerializeField] private float velocityY;
    [SerializeField] private float jumpVelocity;
    [SerializeField] private ParticleSystem dirtParticles;
    private GameObject playerCam;

    Animator myAnimator;

    void Start()
    {
        playerCam = FindObjectOfType<cameraFollow>().gameObject;
        myAnimator = GetComponent<Animator>();
    }

    //update function
    private void Update()
    {

        Debug.Log(transform.position.y);

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

        //see is movement
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            dirtParticles.gameObject.SetActive(true);
            myAnimator.SetFloat("Speed", 3);
        }else
        {
            dirtParticles.gameObject.SetActive(false);
            myAnimator.SetFloat("Speed", 0);

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
            float targetAngle = yRot + playerCam.transform.eulerAngles.y;
            float currentAngle = Mathf.LerpAngle(transform.eulerAngles.y, targetAngle, 10 * Time.deltaTime);
            transform.rotation = Quaternion.Euler(0, currentAngle, 0);
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
