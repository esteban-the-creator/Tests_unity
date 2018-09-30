using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Camera_movement : MonoBehaviour {

    // Use this for initialization
    public float speed = 7.0f;
    public float rotatespeed = 5.0f;
    CharacterController controller;
    public GameObject cam;
    public float rot_x;
    public float jumpSpeed = 8.0f;
    public float gravity = 9.0f;

    private Vector3 moveDirection = Vector3.zero; //zero es igual que escribir (0,0,0)

    void Start () {
        controller = GetComponent<CharacterController>();
        controller.stepOffset = 0.9f;
	}
	
	// Update is called once per frame
	void Update () {

        Movimiento();
        
	}

    public void Movimiento()

    {
        if (controller.isGrounded )
        {
            //moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            //moveDirection *= speed; NO ACTIVEN ESTA MONDA; CRASHEA MUY FEO

            if  (Input.GetButton("Jump"))
            { 
             moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        controller.Move(moveDirection * Time.deltaTime);

        transform.Rotate(0, Input.GetAxis("Mouse X") * rotatespeed, 0);
        rot_x += (Input.GetAxis("Mouse Y") * -1) * rotatespeed;

        if (rot_x > 0 && rot_x < 60)
        {
            cam.transform.localRotation = Quaternion.Euler(rot_x, 0, 0);
        }
        if (rot_x < 0 && rot_x > -60)
        {
            cam.transform.localRotation = Quaternion.Euler(rot_x, 0, 0);
        }
        if (rot_x > 60 )
        {
            rot_x = 60; 
        }
        if (rot_x < -60)
        {
            rot_x = -60;
        }
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float CurSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * CurSpeed);

        transform.Rotate(0, Input.GetAxis("Horizontal") * rotatespeed, 0);

    }
}
