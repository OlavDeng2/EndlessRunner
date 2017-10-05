using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Declare variables for the jumping of the car
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

    //For Pickup sound
    AudioSource PickupAudio;

    // Use this for initialization
    void Start ()
    {
        CarPosition = transform.position;

        PickupAudio = GetComponent<AudioSource>();
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

        if (Input.GetButtonDown("Jump") && !IsJumping)
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


    //Do the jump
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

    private void OnTriggerEnter(Collider Collision)
    {
        //check if the object that hits the Pickup is the player
        //Also checks if is jumping or not as a workaround due to a bug
        if (Collision.gameObject.tag == "Pickups" && !IsJumping)
        {
            //Destroy the Pickup and update the score
            GameObject.Destroy(Collision.gameObject);
            GameController.Score += 1;
            //GameObject.Find("GameController").GetComponent<GameController>().Score += 1;

            //Play the sound for the pickup
            PickupAudio.Play();
        }

        //check if enemy collided with the player
        //Also checks if is jumping or not as a workaround due to a bug
        if (Collision.gameObject.tag == "Enemies" && !IsJumping)
        {
            //if the enemy collided with the player end game
            GameObject.Destroy(gameObject);
            GameObject.Find("GameController").GetComponent<GameController>().GameOver();
        }
    }
}
