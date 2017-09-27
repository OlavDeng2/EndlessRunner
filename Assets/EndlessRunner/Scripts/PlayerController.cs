using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AnimationCurve CarJump;
    public float JumpHeight;

    float JumpTime;
    float CurvedValue;
    Vector3 EndPos;
    bool IsJumping = false;

    //Floats for the car speeds
    public float StrafeSpeed = 5f;
    
    //Float for the car position
    Vector3 CarPosition = new Vector3(0 ,0, 0);

    // Use this for initialization
    void Start ()
    {
        CarPosition = transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButtonDown("Left") && transform.position.x != -5)
        {
            CarPosition.x -= StrafeSpeed;
            // turn left
        }

        if (Input.GetButtonDown("Right") && transform.position.x != 5)
        {
            CarPosition.x += StrafeSpeed;
            //Turn Right
        }

        if (Input.GetButtonDown("Jump"))
        {
            JumpTime = 0f;
            IsJumping = true;
        }

        if(IsJumping)
        {
            Jump();
        }
    }


    //update is called at fixed intervals
    private void FixedUpdate()
    {
        MoveCar();
    }


    //Move the car forwards at a fixed speed
    private void MoveCar()
    {
        transform.position = CarPosition;
    }



    private void Jump()
    {
        EndPos = new Vector3(CarPosition.x, JumpHeight, 1);
        JumpTime += Time.deltaTime;
        CurvedValue = CarJump.Evaluate(JumpTime);
        transform.position = Vector3.Lerp(CarPosition, EndPos, CurvedValue);

        if(JumpTime > 1f)
        {
            IsJumping = false;
        }
    }
}
